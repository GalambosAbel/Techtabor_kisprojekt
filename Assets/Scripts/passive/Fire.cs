using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
	public LayerMask playerMask;
	public int fireDmg;

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.layer != playerMask) return;
		col.gameObject.SendMessage("Shot", fireDmg);
	}
}
