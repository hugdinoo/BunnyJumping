using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
	public int Score { get; private set; }

	private float startPoint;

	private Transform playerTransform;


	private void Awake()
	{
		playerTransform = FindObjectOfType<Player>().transform;
	}

	private void Start()
	{
		Score = 0;
		startPoint = playerTransform.position.y;
	}

	private void Update()
	{
		int currentPositionScore = (int)((playerTransform.position.y - startPoint) / 10);
		if (currentPositionScore > Score)
			Score = currentPositionScore;
	}
}
