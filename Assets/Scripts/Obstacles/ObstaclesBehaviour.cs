using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBehaviour : MonoBehaviour {
    //Control shift M para ver metodos

    private Rigidbody2D rb;
    [SerializeField]
    private float speed=-50;
    private Vector2 speedVector;


    [SerializeField]
    public Obstacle obstacle;

    [SerializeField]
    private int damage;

    void Awake () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = obstacle.artObstacle;
        damage = obstacle.damage;
    }

    private void OnEnable()
    {
        speedVector.x = 0;
        speedVector.y = speed * Time.deltaTime;
        rb.velocity = speedVector;
        speed -= 30;
    }

    private void OnBecameInvisible()
    {
        ObstaclePool.Instance.ReleaseObstacles(rb);
    }

    #region GettersAndSetters

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    #endregion
}
