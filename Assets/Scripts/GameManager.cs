﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static GameManager instnace;
    public static GameManager Instance
    {
        get
        {
            return instnace;
        }
    }

    [SerializeField]
    private int score;
    [SerializeField]
    private Text scoreTxt;
    [SerializeField]
    private float timing;

    private void Awake()
    {
        if (instnace == null)
        {
            instnace = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        timing += Time.deltaTime;
        if (timing > 3)
        {
            ObstaculesSpawn();
        }
    }

    private void ObstaculesSpawn()
    {
        ObstacleSpawn.Instance.NewObstacle();
    }

    private void UpdateScore()
    {
        scoreTxt.text = string.Format("Score:{0}", score.ToString());
    }

    public void GameOver()
    {

    }
    
    public void NextLevel()
    {

    }
}
