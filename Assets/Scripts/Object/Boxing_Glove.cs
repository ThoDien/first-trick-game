using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxing_Glove : Moving_Tile
{
    private Player _player;

    [SerializeField]
    private float speed_to_A = 15;
    [SerializeField]
    private float speed_to_B = 2;
    private float _distance;

    protected override void Init()
    {
        base.Init();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    protected override void MoveTile()
    {

        //only move when detect player - distance with player and player on ground
        _distance = Mathf.Abs(_player.transform.position.x - transform.position.x);

        if(_distance < 2.7)
        {
            if (transform.position == _position_A.position)
            {
                currentTarget = _position_B.position;
            }
            else if (transform.position == _position_B.position)
            {
                currentTarget = _position_A.position;
            }
            if (currentTarget == _position_B.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget, Time.deltaTime * speed_to_A);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget, Time.deltaTime * speed_to_B);
            }
        }
    }


}
