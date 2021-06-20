using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Moving_Tile : MonoBehaviour
{
    protected Player player;

    [SerializeField]
    protected Transform _position_A;
    [SerializeField]
    protected Transform _position_B;
    [SerializeField]
    protected float speed = 2f;
    protected Vector3 currentTarget;

    // Start is called before the first frame update
    protected virtual void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Start()
    {
        Init();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        MoveTile();
    }

    protected virtual void MoveTile()
    {
        if (transform.position == _position_A.position)
        {
            currentTarget = _position_B.position;
        }else if (transform.position == _position_B.position)
        {
            currentTarget = _position_A.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }




}
