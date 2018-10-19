using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBehaviour : MonoBehaviour {
    //Control shift M para ver metodos

    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector2 speedVector;

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
        speedVector.x = 0;
    }

    private void Update()
    {
        speed = GameManager.Instance.ObstacleSpeed;
        speedVector.y = GameManager.Instance.ObstacleSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rb.velocity = speedVector;
    }


    private void OnBecameInvisible()
    {
        ObstaclePool.Instance.ReleaseObstacles(rb);
        GameManager.Instance.ObstaclesCount--;
    }

    void DamageDone()
    {
        PlayerStats.Instance.Damage(Damage);
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
