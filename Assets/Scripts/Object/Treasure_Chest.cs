using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_Chest : MonoBehaviour
{
    private Animator _anim;
    [SerializeField]
    private GameObject _key;
    private bool _isKeyCreated = false;
    public bool completeGame = false;
    public GameObject completePanel;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            _anim.SetBool("Open", true);
            if (!_isKeyCreated)
            {
                StartCoroutine(delay(1));
                Instantiate(_key, transform.position + new Vector3(0f, 0.6f, 0f), Quaternion.identity);
                _isKeyCreated = true;
                completeGame = true;
                completePanel.SetActive(true);
            }

        }

    }

    IEnumerator delay(float second)
    {
        yield return new WaitForSeconds(second);
    }
}
