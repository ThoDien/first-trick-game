using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spike : MonoBehaviour
{
    protected Player player;

    public virtual void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.Die();
        }
    }

}
