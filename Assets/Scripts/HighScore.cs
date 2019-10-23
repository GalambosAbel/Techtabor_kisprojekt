using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void HighScoreReset()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
}
