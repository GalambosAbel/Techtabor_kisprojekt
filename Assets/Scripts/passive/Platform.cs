using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	float despawn;

	void Update()
    {
		despawn = Camera.main.transform.position.y - Camera.main.orthographicSize * 2;
		if (transform.position.y < despawn)
		{

			Destroy(gameObject);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(transform.position, new Vector3(transform.localScale.x, transform.localScale.y, 1));
	}
}
