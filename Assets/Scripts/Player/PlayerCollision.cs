using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public delegate void _OnDamage(string id);
    public static event _OnDamage OnDamaged;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {
            PlayerStats.Instance.idRef = other.name;
            OnDamaged(other.name);

            // PlayerStats.Instance.Damage(other.GetComponent<ObstaclesBehaviour>().Damage);
        }
    }
}
