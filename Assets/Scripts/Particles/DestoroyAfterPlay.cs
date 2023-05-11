using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoroyAfterPlay : MonoBehaviour
{
	private void Start()
	{
		ParticleSystem particle = GetComponent<ParticleSystem>();
		Destroy(gameObject, particle.main.duration);
	}
}
