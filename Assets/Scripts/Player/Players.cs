using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
	public static Players p;
	public  GameObject playerOne;
	public  GameObject playerTwo;
	public int playerCount;

	public int money;

	public bool paused = false;
	public bool dead = false;

	void Awake()
	{
		if(p == null)
		{
			p = this;
		}
	}

}
