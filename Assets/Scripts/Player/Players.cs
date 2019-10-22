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

	void Awake()
	{
		if(p == null)
		{
			p = this;
		}
	}

}
