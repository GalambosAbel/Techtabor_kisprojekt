using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour
{
    public string alma = "a";
    public string joystickButton = "JoystickButton9";
    public KeyCode thisKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), "asd");
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
