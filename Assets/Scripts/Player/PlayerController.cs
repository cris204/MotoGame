using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Player")]
    [SerializeField]
    private Rigidbody2D rb;

    [Header("General")]
    [SerializeField]
    private float speed=100;
    private float h;
    private float deltaSpeed;
    private Vector2 speedMove;


	void Awake () {
        rb = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ObstaclePool.Instance.GetObstacles();
        }
        InputMovement();
        deltaSpeed = Time.deltaTime * speed;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void InputMovement()
    {
        h = Input.GetAxis("Horizontal");
        speedMove.x = h*deltaSpeed;
    }

    void Movement()
    {
        rb.velocity = speedMove;
    }
}