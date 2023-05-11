using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float moveSpeed = 1.5f;

	private Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		float move = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(moveSpeed * move, rb.velocity.y);
	}
}
