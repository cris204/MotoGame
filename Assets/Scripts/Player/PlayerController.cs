using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header ("Player")]
    [SerializeField]
    private Rigidbody2D rb;

    [Header ("General"), SerializeField] private float speed = 100;
    private float h;
    private float deltaSpeed;
    private Vector2 speedMove;

    [SerializeField] private LayerMask obstaclesLayer;

    void Awake () {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update () {
        if (Input.GetKeyDown (KeyCode.K)) {
            ObstaclePool.Instance.GetObstacles ();
        }
        InputMovement ();
        deltaSpeed = Time.deltaTime * speed;

        Raycasting ();
    }

    private void FixedUpdate () {
        Movement ();
    }

    void InputMovement () {
        h = Input.GetAxis ("Horizontal");
        speedMove.x = h * deltaSpeed;
    }

    void Movement () {
        rb.velocity = speedMove;
    }

    void Raycasting () {
        Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, 0.5f, obstaclesLayer);
        // if (colliders.Length > 0) {
        for (int i = 0; i < colliders.Length; i++) {
            GameManager.Instance.IncreaseMultiplier (0.02f);
            Debug.Log (colliders[i].name);
        }
    }

    private void OnDrawGizmos () {
        Gizmos.DrawWireSphere (transform.position, 0.5f);
    }
}