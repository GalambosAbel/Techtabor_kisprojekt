using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;


    void Update()
    {
        if(score < Players.p.playerOne.transform.position.y)
        {
            score = Mathf.RoundToInt(Players.p.playerOne.transform.position.y) - 111;
        }
        GetComponent<Text>().text = (score).ToString();
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
