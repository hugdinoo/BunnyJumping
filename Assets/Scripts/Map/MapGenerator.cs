using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
	[SerializeField] private ObjectSet groundSet;
	[SerializeField] private ObjectSet brokenGroundSet;
	[SerializeField] private ObjectSet enemySet;

	[Space(10)]

	[SerializeField] private int maxComplexityY;
	[SerializeField] private int maxPlatformsOnLine = 6;
	[SerializeField] private float maxBrokenPlatformChanse = 0.4f;
	[SerializeField] private float minBrokenPlatformChanse = 0.1f;

	private Vector2 bounds;
	private Transform player;
	private int lastPlatformPlace = 2;
	private float complexity = 0;
	private float nextGenerateY = 7;
	private float generatedSize = 10;

	private void Awake()
	{
		player = FindObjectOfType<Player>().transform;
		Camera cam = Camera.main;
		float cameraXSize = cam.orthographicSize * cam.aspect;
		bounds = new Vector2(-cameraXSize + player.position.x + 2, cameraXSize + player.position.x - 2);
	}

	private void Start()
	{
		Generate();
	}

	private void Update()
	{
		if (player.position.y >= nextGenerateY - generatedSize)
		{
			Generate();
		}
	}

	private void Generate()
	{
		GeneratePlatforms();
		GenerateEnemies();

		nextGenerateY += generatedSize;
	}

	private void GeneratePlatforms()
	{
		float currentY = nextGenerateY;

		int yStep = 4;
		for (int i = 0; i < generatedSize; i += yStep)
		{
			complexity = GetComplexity(currentY);
			Debug.Log("complexity " + complexity);
			bool[] platformsOnLine = new bool[maxPlatformsOnLine];

			int newPlatformPlace = SetNewPlatformPlace(platformsOnLine);
			lastPlatformPlace = newPlatformPlace;
			platformsOnLine[newPlatformPlace] = true;

			int extraPlatformAmount = (int)(-(complexity-1) * Random.Range(2, 4));
			AddExtraPlatforms(extraPlatformAmount, platformsOnLine);

			float mapWidth = bounds.y - bounds.x;
			float stepBetweenPlatforms = mapWidth / maxPlatformsOnLine;
			for (int j = 0; j < maxPlatformsOnLine; j++)
			{
				if (platformsOnLine[j] == true)
				{
					SpawnPlatform(j, currentY, stepBetweenPlatforms);
				}
			}

			currentY += yStep;
		}
	}

	private void GenerateEnemies()
	{
		float y = nextGenerateY;

		int enemiesAmount = Random.Range(0, 2) + (int)(complexity * Random.Range(0, 2));
		for (int i = 0; i < enemiesAmount; i++)
		{
			Vector3 position = new Vector3(Random.Range(bounds.x, bounds.y), Random.Range(y, y + generatedSize), 5);
			GameObject enemyPrefub = enemySet.GetRandomObject();
			Instantiate(enemyPrefub, position, new Quaternion(), transform);
		}
	}

	private float GetComplexity(float currentY)
	{
		float coefficient = currentY / maxComplexityY;
		return Mathf.Clamp(coefficient * coefficient, 0, 1);
	}

	private int SetNewPlatformPlace(bool[] platformsOnLine)
	{
		int newPlatformPlace = lastPlatformPlace + Random.Range(-1, 2);
		if (newPlatformPlace < 0)
		{
			newPlatformPlace = platformsOnLine.Length - 1;
		}
		else if (newPlatformPlace > platformsOnLine.Length - 1)
		{
			newPlatformPlace = 0;
		}

		return newPlatformPlace;
	}

	private void AddExtraPlatforms(int amount, bool[] platformsOnLine)
	{

		for (int i = 0; i < amount; i++)
		{
			int placeIndex = Random.Range(0, platformsOnLine.Length - 1 - i);
			for (int j = 0; j < maxPlatformsOnLine; j++)
			{
				if (platformsOnLine[j] == true)
					continue;

				if (placeIndex == j)
				{
					platformsOnLine[j] = true;
				}
				placeIndex--;
			}
		}
	}

	private void SpawnPlatform(int placeInLine, float height, float stepBetweenPlatforms)
	{
		float xPos = bounds.x + stepBetweenPlatforms / 2 + stepBetweenPlatforms * placeInLine + Random.Range(-stepBetweenPlatforms / 4, stepBetweenPlatforms / 4);
		Vector3 position = new Vector3(xPos, height + Random.Range(-0.5f, 0.5f), 5);

		GameObject platformPrefab = groundSet.GetRandomObject();
		if (minBrokenPlatformChanse + (maxBrokenPlatformChanse - minBrokenPlatformChanse * complexity) > Random.value)
		{
			platformPrefab = brokenGroundSet.GetRandomObject();
		}

		Instantiate(platformPrefab, position, new Quaternion(), transform);
	}
}