using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatform : MonoBehaviour, IInteractable
{
	[SerializeField] private GameObject breakEffect;


	public void Interact(GameObject sourceObject)
	{
		Break();
	}

	private void Break()
	{
		Instantiate(breakEffect, transform.position, new Quaternion());
		Destroy(gameObject);
	}
}
