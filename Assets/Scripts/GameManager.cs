using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    private float timingObstacles;
    [SerializeField]
    private float timingMoreSpeed;
    [SerializeField]
    private float obstacleSpeed;

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
        timingObstacles += Time.deltaTime;
        timingMoreSpeed += Time.deltaTime;
        ObstaculesSpawn();
        IncreaseObstacleSpeed();

    }

    private void ObstaculesSpawn()
    {
        if (timingObstacles > 3)
        {
            ObstacleSpawn.Instance.NewObstacle();
            timingObstacles = 0;
        }

    }

    private void IncreaseObstacleSpeed()
    {
        if (timingMoreSpeed > 20)
        {
            ObstacleSpeed -= 30;
            timingMoreSpeed = 0;
        }

    }

    public void GameOver()
    {
        CanvasManager.Instance.GameOverActivate();
    }
    
    public void NextLevel()
    {

    }

    #region GetAndSet
    public float ObstacleSpeed
    {
        get
        {
            return obstacleSpeed;
        }

        set
        {
            obstacleSpeed = value;
        }
    }

    #endregion

}
