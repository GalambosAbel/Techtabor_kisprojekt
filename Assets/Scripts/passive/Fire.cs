using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
	public int fireDmg;

	void OnTriggerStay2D(Collider2D col)
	{
		col.gameObject.SendMessage("Shot", fireDmg);
	}
}
