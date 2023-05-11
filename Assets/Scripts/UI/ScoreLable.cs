using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLable : MonoBehaviour
{
	private ScoreCounter scoreCounter;
	private TextMeshProUGUI lable; 

	private void Awake()
	{
		scoreCounter = FindObjectOfType<ScoreCounter>();
		lable = GetComponent<TextMeshProUGUI>();
	}

	private void Update()
	{
		lable.text = "Score: " + scoreCounter.Score;
	}
}
