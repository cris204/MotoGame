using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header ("Player")]
    [SerializeField]
    private Rigidbody2D rb;

    [Header ("General"), SerializeField] private float speed = 100;
    [SerializeField] private Transform frontLimit;
    [SerializeField] private Transform rearLimit;
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
        RaycastHit2D frontHitRight = Physics2D.Raycast (frontLimit.position, Vector2.right);
        RaycastHit2D frontHitLeft = Physics2D.Raycast (frontLimit.position, Vector2.left);
        RaycastHit2D rearHitRight = Physics2D.Raycast (rearLimit.position, Vector2.right);
        RaycastHit2D rearHitLeft = Physics2D.Raycast (rearLimit.position, Vector2.left);

        if (frontHitRight.collider != null) {
            if (frontHitRight.collider.gameObject.layer == LayerMask.NameToLayer ("Obstacles") ||
                frontHitRight.collider.gameObject.layer == LayerMask.NameToLayer ("Limits")) {
                float distance = Mathf.Abs (frontHitRight.point.x - transform.position.x);
                if (distance <= 1)
                    Debug.Log (frontHitRight.collider.name + "enter");
            }
        }
        if (frontHitLeft.collider != null) {
            if (frontHitLeft.collider.gameObject.layer == LayerMask.NameToLayer ("Obstacles") ||
                frontHitLeft.collider.gameObject.layer == LayerMask.NameToLayer ("Limits")) {
                float distance = Mathf.Abs (frontHitLeft.point.x - transform.position.x);
                if (distance <= 1 && frontHitLeft.collider.gameObject.layer == obstaclesLayer)
                    Debug.Log (frontHitLeft.collider.name + "enter");
            }
        }
        if (rearHitRight.collider != null) {
            if (rearHitRight.collider.gameObject.layer == LayerMask.NameToLayer ("Obstacles") ||
                rearHitRight.collider.gameObject.layer == LayerMask.NameToLayer ("Limits")) {
                float distance = Mathf.Abs (rearHitRight.point.x - transform.position.x);
                if (distance <= 1 && rearHitRight.collider.gameObject.layer == obstaclesLayer)
                    Debug.Log ("exit");
            }
        }
        if (rearHitLeft.collider != null) {
            if (rearHitLeft.collider.gameObject.layer == LayerMask.NameToLayer ("Obstacles") ||
                rearHitLeft.collider.gameObject.layer == LayerMask.NameToLayer ("Limits")) {
                float distance = Mathf.Abs (rearHitLeft.point.x - transform.position.x);
                if (distance <= 1 && rearHitLeft.collider.gameObject.layer == obstaclesLayer)
                    Debug.Log ("exit");
            }
        }
    }

    private void OnDrawGizmos () {
        Debug.DrawRay (frontLimit.position, transform.TransformDirection (Vector2.left) * 1, Color.green);
        Debug.DrawRay (frontLimit.position, transform.TransformDirection (Vector2.right) * 1, Color.green);
        Debug.DrawRay (rearLimit.position, transform.TransformDirection (Vector2.left) * 1, Color.red);
        Debug.DrawRay (rearLimit.position, transform.TransformDirection (Vector2.right) * 1, Color.red);
    }
}