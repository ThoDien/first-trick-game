using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _wall;
    private Player _player;
    private bool _isCreated = false;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnInvisiableWall();
    }

    private void spawnInvisiableWall()
    {
        Vector3 position = new Vector3(14.5f, -2.03f, 0);
        if(_player.transform.position.x > 15 && !_isCreated)
        {
            Instantiate(_wall, position, Quaternion.identity);
            _isCreated = true;
        }
    }



}
