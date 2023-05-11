using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCleaner : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collider)
	{
		PlatformEffector2D platform = collider.gameObject.GetComponent<PlatformEffector2D>();
		if (platform != null)
		{
			Destroy(platform.gameObject);
		}
	}
}
