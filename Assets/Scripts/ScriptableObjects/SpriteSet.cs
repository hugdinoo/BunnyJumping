using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GroundEnviromentSet")]
public class SpriteSet : ScriptableObject
{
	[SerializeField] private List<Sprite> sprites;

	public Sprite GetRandomSprite()
	{
		return sprites[Random.Range(0, sprites.Count)];
	}
}
