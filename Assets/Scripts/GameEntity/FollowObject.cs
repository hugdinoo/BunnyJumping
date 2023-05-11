using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
	[SerializeField] private float smoothness;
	[SerializeField] private Transform targetObject;
	[SerializeField] private Vector2 maxOffset;
	[SerializeField] private bool followX;
	[SerializeField] private bool followY;
	[SerializeField] private bool lockDownY;
	private Vector3 offset;

	private void Start()
	{
		Init();
	}

	private void FixedUpdate()
	{
		transform.position = GetFollowingPosition(targetObject, offset);
	}

	public Vector3 GetFollowingPosition(Transform followedObject, Vector3 initalOffset)
	{
		Vector3 objectPosition = new Vector3();
		if (followX)
		{
			objectPosition.x = followedObject.position.x + initalOffset.x;
		}
		if (followY)
		{
			objectPosition.y = followedObject.position.y + initalOffset.y;
		}
		objectPosition = Vector3.Lerp(transform.position, objectPosition, smoothness * Time.fixedDeltaTime);
		if (followX)
		{
			objectPosition.x = Mathf.Clamp(objectPosition.x, followedObject.position.x + initalOffset.x - maxOffset.x, followedObject.position.x + initalOffset.x + maxOffset.x);
		}
		if (followY)
		{
			objectPosition.y = Mathf.Clamp(objectPosition.y, followedObject.position.y + initalOffset.y - maxOffset.y, followedObject.position.y + initalOffset.y + maxOffset.y);
		}
		if (lockDownY && objectPosition.y < transform.position.y)
		{
			objectPosition.y = transform.position.y;
		}
		return objectPosition;
	}

	public void SetTargetObject(Transform newTargetObject)
	{
		targetObject = newTargetObject;
		Init();
	}

	private void Init()
	{
		offset = transform.position - targetObject.position;
	}
}
