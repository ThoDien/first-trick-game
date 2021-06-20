using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;
    public static int _deaths = 0;
    public GameObject completePanel;
    public GameObject EscPanel;
    private Treasure_Chest _ts;

    // Start is called before the first frame update
    private void Start()
    {
        _ts = GameObject.Find("treasure_chest").GetComponent<Treasure_Chest>();
        if (_ts == null)
        {
            Debug.Log("Treasure Chest Reference is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGameOver)
        {
            StartCoroutine(delayBeforeLoadScene());   
        }

         if (_ts.completeGame && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Restart");
            completePanel.SetActive(false);
            SceneManager.LoadScene("Game");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscPanel.SetActive(!EscPanel.gameObject.activeSelf);
        }

    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    IEnumerator delayBeforeLoadScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Game");
    }

    public int IncreaseDeath()
    {
        _deaths ++;
        return _deaths;
    }

}
