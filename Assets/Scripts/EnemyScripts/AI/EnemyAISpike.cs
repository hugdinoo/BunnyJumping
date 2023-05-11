using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAISpike : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	private Rigidbody2D rb;
	private float direction;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		direction = Random.value > 0.5 ? 1 : -1;
		transform.localScale = new Vector3(direction, 1, 1);
	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
	}
}
