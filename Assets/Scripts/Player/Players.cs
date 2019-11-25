using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
	public static Players p;
	public GameObject playerOne;
	public GameObject playerTwo;
	public int playerCount;
	public bool[] playersDead;

	public int money;
	public int multiplayerMaxAmmo;

	public bool paused = false;
	public bool dead = false;

	void Awake()
	{
		if (p == null)
		{
			p = this;
		}
		if (PlayerPrefs.GetInt("NumberOfPlayers") == 1)
		{
			FindObjectOfType<MenuScript>().Died(1);
			playerTwo.SetActive(false);
		}
		else
		{
			playerOne.GetComponent<Ammunition>().maxAmmunition = multiplayerMaxAmmo;
			playerTwo.GetComponent<Ammunition>().maxAmmunition = multiplayerMaxAmmo;
		}
	}


	public int DeadPlayersCount
	{
		get
		{
			int returnValue = 0;
			for(int i = 0; i < playersDead.Length; i++)
			{
				if (playersDead[i]) returnValue++; 
			}
			return returnValue;
		}
	}
}
