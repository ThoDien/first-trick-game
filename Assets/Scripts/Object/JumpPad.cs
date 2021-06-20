using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    //global handler
    private Player _player;
    private bool _isHit = false;

    //private handler
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!_isHit)
            {
                _anim.SetTrigger("hitPlayer");
                _player.onJumpPad();
                _isHit = true;
            }


        }
    }

}
