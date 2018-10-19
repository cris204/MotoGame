using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {

	[SerializeField] private Animator animator;
	public Collider2D collider2D;

	IEnumerator disableColliderOnCollision;

	private void Start () {
		animator = GetComponent<Animator> ();
		collider2D = GetComponent<Collider2D> ();
	}

	public void OnMove (float amount) {
		animator.SetFloat ("Horizontal", amount);
	}

	public void Damage () {
		animator.SetTrigger ("Collision");

		if (disableColliderOnCollision != null) {
			StopCoroutine (disableColliderOnCollision);
		}

		disableColliderOnCollision = DisableColliderOnCollision ();
		StartCoroutine (disableColliderOnCollision);
	}

	public void Death () {
		animator.SetTrigger ("Death");
		collider2D.enabled = false;
	}

	IEnumerator DisableColliderOnCollision () {
		collider2D.enabled = false;
		yield return new WaitForSeconds (1f);
		collider2D.enabled = true;
	}
}