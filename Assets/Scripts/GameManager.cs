using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instnace;
    public static GameManager Instance {
        get {
            return instnace;
        }
    }

    [SerializeField] private float timingObstacles;
    [SerializeField] private float timingMoreSpeed;
    [SerializeField] private float obstacleSpeed;
    [SerializeField] private int maxObstacle;
    [SerializeField] private int obstaclesCount;
    [SerializeField] private float speedToSpaawn;
    [SerializeField] private float score;
    [SerializeField] private float multiplier = 1;
    private float minMultiplier = 1;
    private float maxMultiplier = 30;

    private void Awake () {
        if (instnace == null) {
            instnace = this;
        } else {
            Destroy (this.gameObject);
        }
    }

    private void Start () {
        SpeedToSpaawn = 0;
        multiplier = minMultiplier;
    }

    private void Update () {
        timingObstacles += Time.deltaTime;
        timingMoreSpeed += Time.deltaTime;
        ObstaculesSpawn ();
        IncreaseObstacleSpeed ();
        IncreaseScore ();
        DecreaseMultiplier ();
    }

    private void ObstaculesSpawn () {
        SpeedToSpaawn = 1 / (Time.timeSinceLevelLoad * 0.08f); //parameterize
        if (timingObstacles > SpeedToSpaawn && ObstaclesCount < MaxObstacle) {
            ObstacleSpawn.Instance.NewObstacle ();
            timingObstacles = 0;
            ObstaclesCount++;
        }
    }

    private void IncreaseObstacleSpeed () {
        if (timingMoreSpeed > 5) {
            ObstacleSpeed -= 30;
            timingMoreSpeed = 0;
        }
    }

    public void GameOver () {
        CanvasManager.Instance.GameOverActivate ();
    }

    public void IncreaseScore () {
        Score += Time.deltaTime * Multiplier;
    }

    public void IncreaseMultiplier (float amount) {
        Multiplier += amount;

        if (Multiplier >= maxMultiplier)
            Multiplier = maxMultiplier;
    }

    public void DecreaseMultiplier () {
        Multiplier -= Time.deltaTime * 0.05f;

        if (Multiplier <= minMultiplier)
            multiplier = minMultiplier;
    }

    #region GetAndSet

    public float ObstacleSpeed {
        get {
            return obstacleSpeed;
        }

        set {
            obstacleSpeed = value;
        }
    }

    public float SpeedToSpaawn {
        get {
            return speedToSpaawn;
        }

        set {
            speedToSpaawn = value;
        }
    }

    public int MaxObstacle {
        get {
            return maxObstacle;
        }

        set {
            maxObstacle = value;
        }
    }

    public float Score {
        get {
            return score;
        }

        set {
            score = value;
        }
    }

    public float Multiplier {
        get {
            return multiplier;
        }
        set {
            multiplier = value;
        }
    }

    public int ObstaclesCount {
        get {
            return obstaclesCount;
        }

        set {
            obstaclesCount = value;
        }
    }

    #endregion

}