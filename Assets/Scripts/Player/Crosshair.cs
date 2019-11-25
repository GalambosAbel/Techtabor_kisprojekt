﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
	public float crosshairSpeed = 50f;
	public float distance = 50f;

    void Start()
    {
		transform.position = Camera.main.transform.position;
    }

    void Update()
    {
		if (Input.GetKey(KeyCode.Keypad4)) transform.position -= new Vector3(Time.deltaTime * crosshairSpeed, 0, 0);
		if (Input.GetKey(KeyCode.Keypad6)) transform.position += new Vector3(Time.deltaTime * crosshairSpeed, 0, 0);
		if (Input.GetKey(KeyCode.Keypad5)) transform.position -= new Vector3(0, Time.deltaTime * crosshairSpeed, 0);
		if (Input.GetKey(KeyCode.Keypad8)) transform.position += new Vector3(0, Time.deltaTime * crosshairSpeed, 0);

		Vector3 direction = (transform.position - transform.parent.position).normalized;
		transform.position = transform.parent.position + direction * distance;
    }
}