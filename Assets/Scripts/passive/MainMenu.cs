using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	void Awake()
	{
		Screen.SetResolution(512, 910, false);
	}

	public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
