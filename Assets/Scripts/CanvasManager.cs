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
    private float score;
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
        Score += Time.deltaTime;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreTxt.text = string.Format("Score: {0}", Score.ToString("F0"));
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
    public float Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

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
