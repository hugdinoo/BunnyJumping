using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[SerializeField] private GameObject DeadEffect;
	[HideInInspector] bool isGameOver = false;

	[SerializeField] private AudioSource deathSoundEffect;

	public void GameOver()
	{
		if (!isGameOver)
		{
			isGameOver = true;
            deathSoundEffect.Play();

            GetComponent<Animator>().SetTrigger("hurt");

			GetComponent<Movement>().enabled = false;
			GetComponent<PlayerRotater>().enabled = false;

			TwistRigidbody();
			InstantiateParicles();

			FindObjectOfType<Camera>().GetComponent<FollowObject>().enabled = false;
			FindObjectOfType<PlatformCleaner>().GetComponent<FollowObject>().enabled = false;
			FindObjectOfType<ScoreCounter>().enabled = false;

			Destroy(gameObject, 3f);
		}
	}

	private void OnDestroy()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}

	private void TwistRigidbody()
	{
		Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
		BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
		boxCollider.enabled = false;
		rigidbody.bodyType = RigidbodyType2D.Dynamic;
		rigidbody.velocity = Vector2.up * 7f;
		rigidbody.freezeRotation = false;
		rigidbody.AddTorque(245f * (Random.value > 0.5f ? 1f : -1f), ForceMode2D.Force);
	}

	private void InstantiateParicles()
	{
		GameObject paricles = Instantiate(DeadEffect, transform.position, new Quaternion());
		paricles.transform.localScale.Set(3, 3, 1);
		paricles.GetComponent<ParticleSystem>().startColor = new Color(0.51f, 0.47f, 0.46f);
	}
}
