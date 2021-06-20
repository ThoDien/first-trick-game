using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Spike : Spike
{
    private Rigidbody2D _rigid;
    public AudioSource falling;

    public override void Init()
    {
        base.Init();
    }

    public override void Start()
    {
        Init();
        _rigid = GetComponent<Rigidbody2D>();
    }

    public override void Update()
    {
        Falling();
    }

    private void Falling()
    {
        float disToPlayer = Mathf.Abs(transform.position.x - player.transform.position.x);

        if (disToPlayer < 1.0f)
        {
            falling.Play();
            _rigid.gravityScale = 2.0f;
            
        }
    }

}
