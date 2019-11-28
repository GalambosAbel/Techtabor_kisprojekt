using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = 0;
        if (Input.GetKey((KeyCode)PlayerPrefs.GetInt("Left",276)))
        {
            horizontalMove = -runSpeed;
        }
        if (Input.GetKey((KeyCode)PlayerPrefs.GetInt("Right",275)))
        {
            horizontalMove = runSpeed;
        }
        if (Input.GetKeyDown((KeyCode)PlayerPrefs.GetInt("Jump",273)))
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

