using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;


    void Update()
    {
        if (Players.p.playerOne != null)
        {
            if (score < Players.p.playerOne.transform.position.y - 111)
            {
                score = Mathf.RoundToInt(Players.p.playerOne.transform.position.y) - 111;
            }
        }
        if (Players.p.playerTwo != null)
        {
            if (score < Players.p.playerTwo.transform.position.y - 111)
            {
                score = Mathf.RoundToInt(Players.p.playerTwo.transform.position.y) - 111;
            }
        }
        GetComponent<Text>().text = (score).ToString();
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
