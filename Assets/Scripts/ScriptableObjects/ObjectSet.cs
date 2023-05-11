using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ObjectSet")]
public class ObjectSet: ScriptableObject
{
	[SerializeField] private List<GameObject> objects;

	public GameObject GetRandomObject()
	{
		return objects[Random.Range(0, objects.Count)];
	}
}
