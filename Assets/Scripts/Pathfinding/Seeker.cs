using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Seeker : MonoBehaviour
{
	Rigidbody2D rb;
	public Vector3 target; 
	public float updateTime;
	float timer;
	Vector3[] path;
	int targetIndex;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			timer += updateTime;
			RequestNewPath();
		}
	}

	void RequestNewPath ()
	{
		PathRequestManager.RequestPath(transform.position, target, OnPathFound);
	}

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
	{
		if (pathSuccessful)
		{
			path = newPath;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath()
	{
		if (path.Length == 0) yield break;
		targetIndex = 0;
		Vector3 currentWaypoint = path[0];

		while (true)
		{
			if (transform.position == currentWaypoint)
			{
				targetIndex++;
				if (targetIndex >= path.Length)
				{
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}

			gameObject.SendMessage("SetGoal", currentWaypoint);
			yield return null;
		}
	}

	public void OnDrawGizmos()
	{
		if (path != null)
		{
			for (int i = targetIndex; i < path.Length; i++)
			{
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetIndex)
				{
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else
				{
					Gizmos.DrawLine(path[i - 1], path[i]);
				}
			}
		}
	}
}

