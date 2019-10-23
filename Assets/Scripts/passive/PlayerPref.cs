using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text jump, left, right, shoot;

    void Start()
    {
        keys.Add("Jump", (KeyCode)PlayerPrefs.GetInt("Jump"));
        keys.Add("Left", (KeyCode)PlayerPrefs.GetInt("Left"));
        keys.Add("Right", (KeyCode)PlayerPrefs.GetInt("Right"));
        keys.Add("Shoot", (KeyCode)PlayerPrefs.GetInt("Shoot"));
        jump.text = keys["Jump"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        shoot.text = keys["Shoot"].ToString();
    }

}
