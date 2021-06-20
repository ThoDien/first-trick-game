using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Tile_1 : Moving_Tile
{
    private Rigidbody2D _rb;

    protected override void Init()
    {
        base.Init();
        _rb = GetComponent<Rigidbody2D>();

    }

    protected override void MoveTile()
    {
        if (transform.position == _position_A.position)
        {
            currentTarget = _position_B.position;
        }
        else if (transform.position == _position_B.position)
        {
            //check if child is Player
            if (transform.childCount > 2)
            {
                _rb.bodyType = RigidbodyType2D.Dynamic;
                _rb.gravityScale = 3.0f;
            }
            else
            {
                currentTarget = _position_A.position;
            }
            
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, Time.deltaTime * speed);

    }



}
