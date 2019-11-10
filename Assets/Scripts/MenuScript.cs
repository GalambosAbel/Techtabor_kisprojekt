using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	public GameObject pauseMenu;
	public GameObject deathMenu;

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Pause();
		}
    }

	public void Pause()
	{
		if (Players.p.dead) return;
		if (Players.p.paused)
		{
			Resume();
			return;
		}
		pauseMenu.SetActive(true);
		Players.p.paused = true;
		Time.timeScale = 0f;
	}

	public void Resume()
	{
		if (Players.p.dead) return;
		pauseMenu.SetActive(false);
		Players.p.paused = false;
		Time.timeScale = 1f;
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void QuitToMenu()
	{
		SceneManager.LoadScene("Menu");
	}

    public void RestartLevel()
    {
        SceneManager.LoadScene("Game");
    }

	public void Died()
	{
		Players.p.paused = true;
		pauseMenu.SetActive(false);
		deathMenu.SetActive(true);
		Time.timeScale = 0f;
	}
}
