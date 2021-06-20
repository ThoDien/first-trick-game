using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    private Player _player;
    public void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        moveCamera();
    }
    public void cameraMove(float step)
    {
        
        transform.position = Vector3.Lerp(transform.position, new Vector3(19 * step, 0, -10), 1f);
    }

    public void moveCamera()
    {
        if (_player.transform.position.x < 9)
        {
            cameraMove(0);
        }
        else if (_player.transform.position.x >= 9 && _player.transform.position.x < 28)
        {
            cameraMove(1);
        }
        else if (_player.transform.position.x >= 28 && _player.transform.position.x < 45)
        {
            cameraMove(2);
        }else if (_player.transform.position.x >= 45)
        {
            cameraMove(2.8f);
        }
    }

}
