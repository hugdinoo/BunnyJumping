using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnviroment : MonoBehaviour
{
	[SerializeField] private SpriteSet set;
	[SerializeField] private float enviromentChance = 0.3f;
	private void Awake()
	{
		SetUpGreen();
	}

	private void SetUpGreen()
	{
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = null;
		if (Random.value <= enviromentChance)
		{
			spriteRenderer.sprite = set.GetRandomSprite();
			spriteRenderer.flipX = Random.value > 0.5f;
			float size = Random.value + 0.5f;
			transform.localScale = new Vector3(size, size, 1);
		}
	}
}
