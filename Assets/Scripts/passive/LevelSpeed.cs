using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpeed : MonoBehaviour
{
	public float gameSpeed;

	void Start()
	{
		Players.p.paused = false;
		Time.timeScale = gameSpeed;
	}

	void Update()
    {
		if (!Players.p.paused) Time.timeScale = gameSpeed;
    }
}
