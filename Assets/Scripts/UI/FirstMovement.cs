using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMovement : MonoBehaviour
{
	private void Update()
	{
		float move = Input.GetAxis("Horizontal");
		if (move != 0)
		{
			gameObject.SetActive(false);
		}
	}
}
