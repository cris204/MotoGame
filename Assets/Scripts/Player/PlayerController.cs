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
    [SerializeField]
    Collider2D[] colliders;

    [SerializeField] private LayerMask obstaclesLayer;

    void Awake () {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update () {
        if (Input.GetKeyDown (KeyCode.K)) {
            ObstaclePool.Instance.GetObstacles ();
        }
        deltaSpeed = Time.deltaTime * speed;

        Raycasting ();
    }

    private void FixedUpdate () {

    }


    void Raycasting () {
        colliders = Physics2D.OverlapCircleAll (transform.position, 0.5f, obstaclesLayer);
        for (int i = 0; i < colliders.Length; i++) {
            GameManager.Instance.IncreaseMultiplier (0.02f);
            Debug.Log (colliders[i].name);
        }
        
    }

    public void TurnLeftButton () {
        rb.velocity = new Vector2 (-deltaSpeed, 0);
    }

    public void TurnRightButton () {
        rb.velocity = new Vector2 (deltaSpeed, 0);
    }

    public void SetVelocityZero () {
        rb.velocity = Vector2.zero;
    }

    private void OnDrawGizmos () {
        Gizmos.DrawWireSphere (transform.position, 0.5f);
    }
}