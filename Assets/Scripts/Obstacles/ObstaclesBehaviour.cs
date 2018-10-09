using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBehaviour : MonoBehaviour {
    //Control shift M para ver metodos

    private Rigidbody2D rb;
    [SerializeField]
    private float speed=-50;
    private Vector2 speedVector;
    public string id;
    public Obstacle obstacle;

    [SerializeField]
    private int damage;

    void Awake () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void Start()
    {
        speedVector.x = 0;
        GetComponent<SpriteRenderer>().sprite = obstacle.artObstacle;
        damage = obstacle.damage;
        PlayerCollision.OnDamaged += DamageDone;
    }

    private void OnEnable()
    {
        //speed = GameManager.Instance.ObstacleSpeed;
    }

    private void FixedUpdate()
    {
        speedVector.y = speed * Time.deltaTime;
        rb.velocity = speedVector;
    }

    private void OnBecameInvisible()
    {
        ObstaclePool.Instance.ReleaseObstacles(rb);
        PlayerCollision.OnDamaged -= DamageDone;
    }

    public void DamageDone(string id)
    {
        PlayerStats.Instance.Damage(id,Damage);
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
