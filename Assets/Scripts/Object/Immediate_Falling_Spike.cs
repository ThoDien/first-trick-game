using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immediate_Falling_Spike : Spike
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

        if (disToPlayer < 0.1f)
        {
            AudioSource falling = GetComponent<AudioSource>();
            falling.Play();
            _rigid.gravityScale = 2.0f;
        }
    }
}
