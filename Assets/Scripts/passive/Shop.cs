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
	public Collider2D revive;

	int p1HP = 0;
	int p2HP = 0;
	int p1Am = 0;
	int p2Am = 0;

	[Space]

	public int healthCost;
	public int healthPercent;

	public int ammoCost;
	public int ammoCount;

	public int reviveCost;

	bool isShopping = false;

	public Camera shopCamera;

	void Awake()
	{
		if(PlayerPrefs.GetInt("NumberOfPlayers") == 2)
		{
			Destroy(ammo.gameObject);
			ammo = revive;
			ammo.gameObject.SetActive(true);
		}
	}

	void Update()
	{
		if (Input.GetKeyDown((KeyCode)PlayerPrefs.GetInt("LeaveShop",108)))
		{
			LeaveShop();
		}
	}

	void FixedUpdate()
    {
		if (isShopping)
		{
			if(Players.p.playerOne.activeSelf)
			{
				if (heart.IsTouching(Players.p.playerOne.GetComponent<BoxCollider2D>()))
				{
					p1HP++;
					if (p1HP >= 50)
					{
						p1HP = 0;
						BuyHealth(Players.p.playerOne);
					}
				}
				else p1HP = 0;

				if (ammo.IsTouching(Players.p.playerOne.GetComponent<BoxCollider2D>()))
				{
					p1Am++;
					if (p1Am >= 50)
					{
						p1Am = 0;
						BuyAmmoOrRevive(Players.p.playerOne);
					}
				}
				else p1Am = 0;

			}
			if (Players.p.playerTwo.activeSelf)
			{
				if (heart.IsTouching(Players.p.playerTwo.GetComponent<BoxCollider2D>()))
				{
					p2HP++;
					if (p2HP >= 50)
					{
						p2HP = 0;
						BuyHealth(Players.p.playerTwo);
					}
				}
				else p2HP = 0;

				if (ammo.IsTouching(Players.p.playerTwo.GetComponent<BoxCollider2D>()))
				{
					p2Am++;
					if (p2Am >= 50)
					{
						p2Am = 0;
						BuyAmmoOrRevive(Players.p.playerTwo);
					}
				}
				else p2Am = 0;
			}
		}
    }

	void BuyHealth (GameObject player)
	{
		if (Players.p.money >= healthCost && player.GetComponent<Health>().hp < player.GetComponent<Health>().max)
		{
			player.GetComponent<Health>().Heal(healthPercent);
			Players.p.money -= healthCost;
		}
	}

	void BuyAmmoOrRevive(GameObject player)
	{
		if (PlayerPrefs.GetInt("NumberOfPlayers") != 2)
		{
			if (Players.p.money >= ammoCost && player.GetComponent<Ammunition>().magazineCurrent < player.GetComponent<Ammunition>().maxAmmunition)
			{
				player.GetComponent<Ammunition>().magazineCurrent += ammoCount;
				Players.p.money -= ammoCost;
			}
		}

		if (PlayerPrefs.GetInt("NumberOfPlayers") == 2)
		{
			if (Players.p.money >= reviveCost)
			{
				if(Players.p.playersDead[0])
				{
					p1Pos = p2Pos;
					Players.p.playerOne.SetActive(true);
					Players.p.playerOne.GetComponent<Health>().Heal(Players.p.playerOne.GetComponent<Health>().max);
					Players.p.playerOne.transform.position = shopEnterance;
					Players.p.playersDead[0] = false;
					Players.p.money -= reviveCost;
				}
				else if(Players.p.playersDead[1])
				{
					p2Pos = p1Pos;
					Players.p.playerTwo.SetActive(true);
					Players.p.playerTwo.GetComponent<Health>().Heal(Players.p.playerTwo.GetComponent<Health>().max);
					Players.p.playerTwo.transform.position = shopEnterance;
					Players.p.playersDead[1] = false;
					Players.p.money -= reviveCost;
				}
			}
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
		if (!isShopping || Players.p.paused) return;
		if (Players.p.playerOne != null)
		{
			Players.p.playerOne.transform.position = p1Pos;
			Players.p.playerOne.GetComponent<Ammunition>().magazineCurrent++;
		}
		if (Players.p.playerTwo != null)
		{
			Players.p.playerTwo.transform.position = p2Pos;
			Players.p.playerTwo.GetComponent<Ammunition>().magazineCurrent++;
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
