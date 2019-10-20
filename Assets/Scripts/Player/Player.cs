using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player p;
	public  GameObject playerOne;
	public  GameObject playerTwo;
	public int playerCount;

	void Awake()
	{
		if(p == null)
		{
			p = this;
		}
	}

}
