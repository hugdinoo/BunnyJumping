using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIElectro : MonoBehaviour
{
	[SerializeField] private SpriteRenderer areaSpriteRendrer;
	[SerializeField] private CircleCollider2D circleCollider;

	[SerializeField] private float activeTime = 3f;
	[SerializeField] private float preparingTime = 1.5f;
	[SerializeField] private float pauseTime = 3f;

	private float timer;
	private bool isActive = true;

	private void Start()
	{
		ResetTimer();
	}

	private void Update()
	{
		timer -= Time.deltaTime;

		if (timer <= 0)
		{
			ToggleState();
		}
	}

	private void ToggleState()
	{
		isActive = !isActive;
		if (isActive)
		{
			areaSpriteRendrer.gameObject.SetActive(true);
			StartCoroutine(PreparingCoroutine());
		}
		else
		{
			areaSpriteRendrer.gameObject.SetActive(false);
			circleCollider.gameObject.SetActive(false);
		}
		ResetTimer();
	}

	private void ResetTimer()
	{
		if (isActive)
		{
			timer = activeTime + preparingTime;
		}
		else
		{
			timer = pauseTime;
		}
	}

	private IEnumerator PreparingCoroutine()
	{
		for (int i = 0; i < preparingTime / 0.2f; i++)
		{
			areaSpriteRendrer.gameObject.SetActive(!areaSpriteRendrer.gameObject.activeSelf);
			yield return new WaitForSeconds(0.2f);
		}
		areaSpriteRendrer.gameObject.SetActive(true);

		areaSpriteRendrer.enabled = true;
		circleCollider.gameObject.SetActive(true);
	}
}
