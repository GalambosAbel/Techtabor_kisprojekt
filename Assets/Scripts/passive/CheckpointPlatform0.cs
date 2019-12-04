using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointPlatform0 : MonoBehaviour
{
	GameObject platform0;

	void Awake()
	{
		platform0 = transform.GetChild(0).gameObject;
	}

	void Update()
    {
		if (platform0.activeSelf) return;
        if (Players.p.playerOne.activeSelf && Players.p.playerTwo.activeSelf)
        {
            if (Players.p.playerOne.transform.position.y >= transform.position.y - transform.localScale.y * 0.45)
            {
                if (Players.p.playerTwo.transform.position.y >= transform.position.y - transform.localScale.y * 0.45) platform0.SetActive(true);
            }
        }
        else if (Players.p.playerOne.activeSelf)
        {
            if (Players.p.playerOne.transform.position.y >= transform.position.y - transform.localScale.y * 0.45) platform0.SetActive(true);
        }
        else if(Players.p.playerTwo.activeSelf)
        {
            if (Players.p.playerTwo.transform.position.y >= transform.position.y - transform.localScale.y * 0.45) platform0.SetActive(true);
        }
    }
}
