using System.Collections;
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
		if (Input.GetKey((KeyCode)PlayerPrefs.GetInt("CrosshairLeft", 104))) transform.position -= new Vector3(Time.deltaTime * crosshairSpeed, 0, 0);
		if (Input.GetKey((KeyCode)PlayerPrefs.GetInt("CrosshairRight", 107))) transform.position += new Vector3(Time.deltaTime * crosshairSpeed, 0, 0);
		if (Input.GetKey((KeyCode)PlayerPrefs.GetInt("CrosshairDown", 106))) transform.position -= new Vector3(0, Time.deltaTime * crosshairSpeed, 0);
		if (Input.GetKey((KeyCode)PlayerPrefs.GetInt("CrossHairUp", 117))) transform.position += new Vector3(0, Time.deltaTime * crosshairSpeed, 0);

		Vector3 direction = (transform.position - transform.parent.position).normalized;
		transform.position = transform.parent.position + direction * distance;
    }
}
