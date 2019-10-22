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
            score = Mathf.RoundToInt(Players.p.playerOne.transform.position.y);
        }
        GetComponent<Text>().text = (score-111).ToString();
    }
}
