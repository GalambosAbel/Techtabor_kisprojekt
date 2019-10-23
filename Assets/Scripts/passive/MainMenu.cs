using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	void Awake()
	{
		Screen.fullScreen = false;
	}

	public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
