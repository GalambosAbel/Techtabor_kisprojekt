using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public Vector3 shopEnterance;
	Vector3 p1Pos;
	Vector3 p2Pos;

	public Collider2D heart;
	public Collider2D ammo;

	public LayerMask playerMask;

	[Space]

	public int healthCost;
	public int healthPercent;

	public int ammoCost;
	public int ammoCount;

	bool isShopping = false;

	public Camera shopCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
		{
			LeaveShop();
		}
    }



	public void TeleportToShop ()
	{
		if (isShopping) return;
		if (Players.p.playerOne != null)
		{
			p1Pos = Players.p.playerOne.transform.position;
			Players.p.playerOne.transform.position = shopEnterance;
		}
		if (Players.p.playerTwo != null)
		{
			p2Pos = Players.p.playerTwo.transform.position;
			Players.p.playerTwo.transform.position = shopEnterance;
		}

		isShopping = true;
		shopCamera.depth = 0;
	}

	public void LeaveShop ()
	{
		if (!isShopping) return;
		if (Players.p.playerOne != null)
		{
			Players.p.playerOne.transform.position = p1Pos;
		}
		if (Players.p.playerTwo != null)
		{
			Players.p.playerTwo.transform.position = p2Pos;
		}

		isShopping = false;
		shopCamera.depth = -2;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawCube(shopEnterance, Vector3.one * 10);
	}
}
