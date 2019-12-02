using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{
	public float crosshairSpeed = 50f;
	public float distance = 50f;

	Player2Controller inputController;

	void Start()
    {
		transform.position = Camera.main.transform.position;
		inputController = new Player2Controller();

		inputController.Gameplay.Enable();

		inputController.Gameplay.Aim.performed += ctx => QuickAim(ctx.ReadValue<Vector2>());
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

	void QuickAim(Vector2 direction)
	{
		transform.position = transform.parent.position + new Vector3(direction.x, direction.y, 0).normalized * distance;
	}
}
