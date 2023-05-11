using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlinkHint : MonoBehaviour
{
	[SerializeField] private Color blinkColor;
	[SerializeField] private float blinkTime;
	private Color nextColor;
	private TextMeshProUGUI text;

	private void Start()
	{
		text = GetComponent<TextMeshProUGUI>();
		nextColor = text.color;
		StartCoroutine(Blink());
	}

	private IEnumerator Blink()
	{
		while(gameObject.activeSelf)
		{
			nextColor = text.color;
			text.color = blinkColor;
			blinkColor = nextColor;
			yield return new WaitForSeconds(blinkTime);
		}
	}
}
