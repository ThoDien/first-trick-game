using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("UI Manager is NULL");
            }
            return _instance;
        }     
    }

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _instance = this;
    }

    public Text deathCount;
    public TextMesh hitRestart;
    public void updateDeathCount(int death)
    {
        deathCount.text = "Death: " + death;
    }

}
