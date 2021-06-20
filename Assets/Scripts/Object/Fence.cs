using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    private Player _player;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CloseFence();
    }

    private void CloseFence()
    {
        if (_player.transform.position.x > 47)
        {
            _anim.SetBool("Close", true);
        }
    }

}
