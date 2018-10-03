using UnityEngine;
using System.Collections.Generic;

public class ObstaclePool : MonoBehaviour
{

    private static ObstaclePool instance;

    public static ObstaclePool Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField]
    private Rigidbody2D obstaclePrefab;

    [SerializeField]
    private int size;

    private List<Rigidbody2D> obstacles;
    Rigidbody2D instanceObstacle;
    Rigidbody2D obstacleObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            PrepareObstacles();
        }
        else
            Destroy(gameObject);
    }

    private void PrepareObstacles()
    {
        obstacles = new List<Rigidbody2D>();
        for (int i = 0; i < size; i++)
            AddObstacles();
    }

    public Rigidbody2D GetObstacles()
    {
        if (obstacles.Count == 0)
            AddObstacles();
        return AllocateObstacle();
    }

    public void ReleaseObstacles(Rigidbody2D obstacle)
    {
        obstacle.velocity = (Vector3.zero);
        obstacle.gameObject.SetActive(false);

        obstacles.Add(obstacle);

    }

    private void AddObstacles()
    {
        instanceObstacle = Instantiate(obstaclePrefab);
        instanceObstacle.gameObject.SetActive(false);
        obstacles.Add(instanceObstacle);
    }

    private Rigidbody2D AllocateObstacle()
    {
        obstacleObject = obstacles[obstacles.Count - 1];
        obstacles.RemoveAt(obstacles.Count - 1);
        obstacleObject.gameObject.SetActive(true);
        return obstacleObject;
    }
}