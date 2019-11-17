using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
	void Awake()
	{
		Screen.SetResolution(512, 910, false);
	}

    public void OnePlayer()
    {
        PlayerPrefs.SetInt("NumberOfPlayers", 1);
        SceneManager.LoadScene("Game");
    }


    public void TwoPlayer()
    {
        PlayerPrefs.SetInt("NumberOfPlayers", 2);
        SceneManager.LoadScene("Game");
    }
}
