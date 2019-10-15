using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Seeker : MonoBehaviour
{
	Rigidbody2D rb;
	Action< Action<Vector3> > getTarget;
	public float updateTime;
	float timer;
	public bool active;
	Vector3[] path;
	int targetIndex;
	public float speed = 100f;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		active = false;
	}

	public void Activate (Action< Action<Vector3> > _getTarget)
	{
		getTarget = _getTarget;
		active = true;
	}

	void Update()
	{
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			timer += updateTime;
			if (active) getTarget(RequestNewPath);
		}
	}

	void RequestNewPath (Vector3 _targetPos)
	{
		Vector3 targetPos = _targetPos;
		PathRequestManager.RequestPath(transform.localPosition, targetPos, OnPathFound);
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

			transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
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

