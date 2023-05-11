using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableEnemy : MonoBehaviour, IInteractable
{
	[SerializeField] private GameObject deadEffect;	

	public void Interact(GameObject sourceObject)
	{
		Die();
	}

	public void Die()
	{
		TwistRigidbody();
		Instantiate(deadEffect, transform.position, new Quaternion());
		GetComponent<Animator>().SetTrigger("Killed");
		Destroy(gameObject, 3f);
	}

	private void TwistRigidbody()
	{
		Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
		BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
		boxCollider.enabled = false;
		rigidbody.bodyType = RigidbodyType2D.Dynamic;
		rigidbody.velocity = Vector2.up * 5f;
		rigidbody.AddTorque(245f * (Random.value > 0.5f ? 1f : -1f), ForceMode2D.Force);
	}
}
