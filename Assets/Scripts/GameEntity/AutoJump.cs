using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJump : MonoBehaviour
{
	public float jumpPower = 3f;
	[SerializeField] private LayerMask jumpableLayerMask;
	[SerializeField] private GameObject jumpEffect;

	private Rigidbody2D rb;
	private BoxCollider2D boxCollider;
	private Animator animator;

	private float groundCastDistance = 0.05f;
	private bool isGrounded = false;

	[SerializeField] private AudioSource jumpSoundEffect;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
		animator = GetComponent<Animator>();
	}


	private void Update()
	{
		Collider2D ground = CheckGround();
		isGrounded = ground != null;

		if (isGrounded && rb.velocity.y <= 0)
		{
			jumpSoundEffect.Play();
			Jump(jumpPower);
			Instantiate(jumpEffect, transform.position + Vector3.down * boxCollider.bounds.size.y / 2, new Quaternion(), transform);
			animator.SetTrigger("grounded");
			InteractWithGround(ground);
		}
	}

	public void Jump(float power)
	{
		rb.velocity = Vector2.up * power;
	}

	private Collider2D CheckGround()
	{
		return Physics2D.BoxCast(
			new Vector2(boxCollider.bounds.center.x, boxCollider.bounds.center.y - boxCollider.bounds.size.y / 2),
			new Vector2(boxCollider.bounds.size.x, 0.01f),
			0f,
			Vector2.down,
			groundCastDistance,
			jumpableLayerMask
		).collider;
	}

	private void InteractWithGround(Collider2D ground)
	{
		IInteractable interactable = ground.gameObject.GetComponent<IInteractable>();
		if (interactable != null)
		{
			interactable.Interact(gameObject);
		}
	}
}