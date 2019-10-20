using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;


    void Update()
    {
        if(score < Player.p.playerOne.transform.position.y)
        {
            score = Mathf.RoundToInt(Player.p.playerOne.transform.position.y);
        }
        GetComponent<Text>().text = (score-111).ToString();
    }
}
