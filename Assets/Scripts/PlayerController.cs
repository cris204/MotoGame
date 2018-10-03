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
    private float v;
    private float deltaSpeed;
    private Vector2 speedMove;



	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
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
        v = Input.GetAxis("Vertical");
        speedMove.x = h*deltaSpeed;
        speedMove.y = v*deltaSpeed;
    }

    void Movement()
    {
        rb.velocity = speedMove;
    }
}