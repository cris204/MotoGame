using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CanvasManager : MonoBehaviour {

    private static CanvasManager instance;
    public static CanvasManager Instance
    {
        get
        {
            return instance;
        }
    }


    [SerializeField]
    private Text scoreTxt;

    [SerializeField]
    private GameObject gameOver;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update () {
        
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreTxt.text = string.Format("Score: {0}", GameManager.Instance.Score.ToString("F0"));
    }

    public void GameOverActivate()
    {
       
        GameOver.SetActive(true);
    }

    public void ReStart(string name)
    {
        SceneManager.LoadScene(name);
    }

    #region GetAndSet


    public GameObject GameOver
    {
        get
        {
            return gameOver;
        }

        set
        {
            gameOver = value;
        }
    }


    #endregion
}
