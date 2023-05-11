using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtObject : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Player player = collision.gameObject.GetComponent<Player>();
		if (player != null)
		{
			if (collision.contacts[0].normal.y >= -0.3f)
			{
				player.GameOver();
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		Player player = collider.gameObject.GetComponent<Player>();
		if (player != null)
		{
			player.GameOver();
		}
	}
}
