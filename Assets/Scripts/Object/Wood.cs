using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField]
    private GameObject _move_tile_2;
    private BoxCollider2D _collider;
    private bool _isPlayerOn = false;
    public GameObject invisibleWall;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        woodDisappear();
    }

    private void woodDisappear()
    {
        if (_move_tile_2.transform.position.y < -1f )
        {
            _collider.enabled = true;
        }
        else
        {
            if (_isPlayerOn)
            {
                _collider.enabled = true;
                invisibleWall.SetActive(false);
            }
            else
            {
                _collider.enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isPlayerOn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isPlayerOn = false;
        }
    }

}
