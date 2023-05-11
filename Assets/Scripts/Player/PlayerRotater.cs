using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotater: MonoBehaviour
{
	[SerializeField] private float maxRotation = 10f;
	private Rigidbody2D rb;
	private Movement movement;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		movement = GetComponent<Movement>();
	}

	private void FixedUpdate()
	{
		float currentRotation = maxRotation * -rb.velocity.x / movement.moveSpeed;
		transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
	}

}
