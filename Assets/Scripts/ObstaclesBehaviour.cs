using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBehaviour : MonoBehaviour {
    //Control shift M para ver metodos
    private Rigidbody2D rb;
    private float speed=-50;
    [SerializeField]
    private Transform initialPosition;
    private Vector2 newPosition;
    private Vector2 speedVector;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void OnEnable()
    {
        speedVector.x = 0;
        speedVector.y = speed * Time.deltaTime;
        rb.velocity = speedVector;
        speed -= 30;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObstaclePool.Instance.ReleaseObstacles(rb);
    }

    private void OnBecameInvisible()
    {
        
    }
}
