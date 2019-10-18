using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player s_p = null;
	public  GameObject playerOne;
	public  GameObject playerTwo;

	public static Player p
	{
		get
		{
			if (s_p == null) s_p = FindObjectOfType(typeof(Player)) as Player;
			if (s_p == null) s_p = Camera.main.gameObject.AddComponent<Player>();
			return s_p;
		}
	}
    
}
