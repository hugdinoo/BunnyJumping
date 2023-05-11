using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTeleport : MonoBehaviour
{
	private float teleportBounds;


	private void Awake()
	{

		float halfOfObject = GetComponent<BoxCollider2D>().bounds.size.x / 2;
		Camera cam = Camera.main;
		teleportBounds = cam.orthographicSize * cam.aspect + halfOfObject;
	}

	private void Update()
	{
		if (transform.position.x > teleportBounds)
		{
			transform.position = new Vector3(-teleportBounds, transform.position.y, transform.position.z);
		}
		else if (transform.position.x < -teleportBounds)
		{
			transform.position = new Vector3(teleportBounds, transform.position.y, transform.position.z);
		}
	}
}
