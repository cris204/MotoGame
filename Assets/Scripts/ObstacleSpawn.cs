using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {

    private static ObstacleSpawn instance;
    public static ObstacleSpawn Instance
    {
        get
        {
            return instance;
        }
    }

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

    public void NewObstacle()
    {
            ObstaclePool.Instance.GetObstacles();
    }
}
