using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpeed : MonoBehaviour
{
    public float gameSpeed;

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }
}
