using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScript : MonoBehaviour
{
	public Rigidbody2D rb;
	public float speed = 100f;
	float currentSpeed;
	Vector2 newVelocity;

	void Update()
	{
		GoTowards(Input.mousePosition);
	}

	public void GoTowards(Vector3 goal)
	{
		currentSpeed = speed * Time.deltaTime * 1000;
		newVelocity.x = (goal - transform.position).normalized.x;
		newVelocity.y = (goal - transform.position).normalized.y;
		rb.velocity = newVelocity * currentSpeed;
	}
}
