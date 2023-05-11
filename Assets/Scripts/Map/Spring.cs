using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour, IInteractable
{
	[SerializeField] private float jumpPower = 10f;
	[SerializeField] private GameObject springJumpEffect;

	public void Interact(GameObject gameObject)
	{
		gameObject.GetComponent<AutoJump>().Jump(jumpPower);
		Instantiate(springJumpEffect, gameObject.transform);
		GetComponent<Animator>().SetTrigger("pressed");
	}
}
