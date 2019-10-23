using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("Jump", (int)KeyCode.Space);
        PlayerPrefs.SetInt("Left", (int)KeyCode.A);
        PlayerPrefs.SetInt("Right", (int)KeyCode.D);
        PlayerPrefs.SetInt("Shoot", (int)KeyCode.Mouse0);
    }
}
