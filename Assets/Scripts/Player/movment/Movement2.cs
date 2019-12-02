using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement2 : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

	Player2Controller inputController;

	void Start()
	{
		inputController = new Player2Controller();

		inputController.Gameplay.Enable();

		inputController.Gameplay.Jump.started += ctx => jump = true;

		inputController.Gameplay.Move.performed += ctx => horizontalMove = ctx.ReadValue<Vector2>().x * runSpeed; 
		inputController.Gameplay.Move.canceled += ctx => horizontalMove = 0;
	}

	void Update()
    {
		if (Input.GetKeyUp((KeyCode)PlayerPrefs.GetInt("Left2", 97)) || Input.GetKeyUp((KeyCode)PlayerPrefs.GetInt("Right2", 100)))
		{
			horizontalMove = 0;
		}
		if (Input.GetKey((KeyCode)PlayerPrefs.GetInt("Left2", 97)))
		{
			horizontalMove = -runSpeed;
		}
		if (Input.GetKey((KeyCode)PlayerPrefs.GetInt("Right2", 100)))
		{
			horizontalMove = runSpeed;
		}
		if (Input.GetKeyDown((KeyCode)PlayerPrefs.GetInt("Jump2", 119)))
		{
			jump = true;
		}
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}

