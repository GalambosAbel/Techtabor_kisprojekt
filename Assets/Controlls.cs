using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour
{
    string alma = "a";
    public string joystickButton = "JoystickButton9";
    public KeyCode thisKeyCode = (KeyCode)System.Enum.Parse();
    void Start()
    {        
        
    }
    private void Update()
    {
        if (Input.GetButtonDown(alma))
        {
            Debug.Log("asd");
        }
    }
}
