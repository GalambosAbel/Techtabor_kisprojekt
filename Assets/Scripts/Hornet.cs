using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hornet : MonoBehaviour
{
	public Transform targetTransform;
	public Rigidbody2D rb;
	float currentSpeed;
	public float speed;
	Vector2 newVelocity;

	void Awake()
	{
	}

	void Update()
	{
		GoTowards(targetTransform.position);
	}

	void GoTowards (Vector3 goal)
	{
		currentSpeed = speed * Time.deltaTime * 1000;
		newVelocity.x = (goal - transform.position).normalized.x;
		newVelocity.y = (goal - transform.position).normalized.y;
		rb.velocity = newVelocity * currentSpeed;

	}
}


