using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Handler
    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _sprite;
    private GameManager _gameManager;
    private UIManager _UIManager;
    private BoxCollider2D _boxcollider2d;


    //Variable
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private float _jumpHeight = 4.0f;
    [SerializeField]
    private float _onJumppadHeight = 4.0f;
    private bool _isPlayerDeath = false;
    private float _hangTime = 0.2f;
    private float _hangCounter;

    //SoundTrack
    public AudioSource jumpSound;
    public AudioSource dieSound;



    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.Log("Game manager = NULL");
        }
        _UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (_UIManager == null)
        {
            Debug.Log("UI Manager is Null");
        }
        _boxcollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPlayerDeath)
        {
            Movement();
        }
        Falling();
    }


    public void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //flip sprite when left, or right
        if (horizontalInput > 0)
        {
            _anim.SetTrigger("Walk");
            _sprite.flipX = false;
        }
        else if(horizontalInput <0)
        {
            _anim.SetTrigger("Walk");
            _sprite.flipX = true;
        }

        if (isGround())
        {
            _hangCounter = _hangTime;
        }
        else
        {
            _hangCounter -= Time.deltaTime; 
        }


        if (Input.GetKeyDown(KeyCode.Space) && _hangCounter > 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x,_jumpHeight);
            jumpSound.Play();
            
        }

        if (Input.GetKeyUp(KeyCode.Space) && _rb.velocity.y > 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x,_rb.velocity.y * 0.5f);
        }


        _rb.velocity = new Vector2(horizontalInput * _speed, _rb.velocity.y);
    }

    public bool isGround()
    {
        float heightGround = 0.5f;
        RaycastHit2D hit = Physics2D.BoxCast(_boxcollider2d.bounds.center, _boxcollider2d.bounds.size,0f,Vector2.down, heightGround, 1<<8);
        //
        Debug.DrawRay(_boxcollider2d.bounds.center + new Vector3(_boxcollider2d.bounds.extents.x,0), Vector2.down, Color.green, heightGround);
        Debug.DrawRay(_boxcollider2d.bounds.center - new Vector3(_boxcollider2d.bounds.extents.x,0), Vector2.down, Color.green, heightGround);
        Debug.DrawRay(_boxcollider2d.bounds.center + new Vector3(0,_boxcollider2d.bounds.extents.y), Vector2.down, Color.green, heightGround);
        Debug.DrawRay(_boxcollider2d.bounds.center - new Vector3(0,_boxcollider2d.bounds.extents.y), Vector2.down, Color.green, heightGround);

        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    public void onJumpPad()
    {
        _rb.velocity = new Vector2(0f, _onJumppadHeight);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Moving_Platform")
        {
            transform.parent = other.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Moving_Platform")
        {
            transform.parent = null;
        }
    }

    public void Die()
    {
        
        if (_isPlayerDeath == false)
        {
            dieSound.Play();
            _anim.SetTrigger("Die");
            _UIManager.updateDeathCount(_gameManager.IncreaseDeath());
            _isPlayerDeath = true;
            _gameManager.GameOver(); //set GameOver = true
        }
    }

    public void Falling()
    {
        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public bool playerDie()
    {
        _isPlayerDeath = true;
        return _isPlayerDeath;
    }


}
