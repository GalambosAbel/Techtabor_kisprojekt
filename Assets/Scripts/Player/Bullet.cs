﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float despawnDistance;
    public float speed;
    public Rigidbody2D rb;

    void Start()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        rb.velocity = (mouse - transform.position).normalized * speed;
		transform.rotation = Quaternion.FromToRotation(Vector3.up, mouse - transform.position);
    }

	void Update()
	{
        Vector3 c = Camera.main.gameObject.transform.position;
        Vector3 v = transform.position;
		if (v.x > c.x + despawnDistance || v.x < c.x - despawnDistance 
            || v.y > c.y + despawnDistance || v.y < c.y - despawnDistance)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
