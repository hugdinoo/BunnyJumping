using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringSpawner : MonoBehaviour
{
	[SerializeField] GameObject springPrefub;
	[SerializeField] float spawnChance = 0.05f;
	private float boundsSize;

	private void Awake()
	{
		boundsSize = GetComponentInParent<BoxCollider2D>().bounds.size.x/2;
		if (Random.value < spawnChance)
		{
			SpawnSpring();
		}
	}

	public void SpawnSpring()
	{
		GameObject spring = Instantiate(springPrefub, transform);
		spring.transform.localPosition = new Vector3(Random.Range(-boundsSize, boundsSize), 0, 0);
	}
}
