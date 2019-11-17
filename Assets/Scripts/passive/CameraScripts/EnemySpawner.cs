using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	#region spawnbox
	public Vector2 A;
	public Vector2 B;
	public Vector2 C;
	public Vector2 D;

	public bool AB;
	public bool BC;
	public bool CD;
	public bool DA;
	#endregion

	public GameObject[] enemies;
	public Transform enemyParent;
	public float spawnDelay;
	float untilNextSpawn;
	bool isSpawning = false;

	void Start ()
	{
		untilNextSpawn = spawnDelay;
	}

	void Update ()
	{
		if (Players.p.playerOne != null) if (Players.p.playerOne.transform.position.y > transform.position.y) isSpawning = true;
		else if (Players.p.playerTwo != null) if (Players.p.playerTwo.transform.position.y > transform.position.y) isSpawning = true;
		else if (!isSpawning) return;

		untilNextSpawn -= Time.deltaTime;
		if(untilNextSpawn <= 0)
		{
			untilNextSpawn += spawnDelay / (2 * Players.p.playerCount - 1);
			SpawnEnemy();
		}
	}

	public void StopSpawn ()
	{
		enemyParent.GetComponent<DestroyEnemies>().KillEnemies();
		isSpawning = false;
	}

	void SpawnEnemy ()
	{
		if (enemies.Length == 0) return;

		float posPercent = Random.Range(0f, 1f);
		int posCase = Random.Range(0, 4);
		int enemyCase = Random.Range(0, enemies.Length);

		switch (posCase)
		{
			case 0:
				if (AB) Instantiate(enemies[enemyCase], position2D + A + (B - A) * posPercent, Quaternion.identity, enemyParent);
				break;

			case 1:
				if (BC) Instantiate(enemies[enemyCase], position2D + B + (C - B) * posPercent, Quaternion.identity, enemyParent);
				break;

			case 2:
				if (CD) Instantiate(enemies[enemyCase], position2D + C + (D - C) * posPercent, Quaternion.identity, enemyParent);
				break;

			case 3:
				if (DA) Instantiate(enemies[enemyCase], position2D + D + (A - D) * posPercent, Quaternion.identity, enemyParent);
				break;

			default:
				Debug.Log("something went terribly wrong!");
				break;

		}
	}

	Vector2 position2D
	{
		get
		{
			return new Vector2(transform.position.x, transform.position.y);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.black;
		if(AB)
		{
			Gizmos.DrawLine(position2D + A, position2D + B);
		}
		if (BC)
		{
			Gizmos.DrawLine(position2D + B, position2D + C);
		}
		if (CD)
		{
			Gizmos.DrawLine(position2D + C, position2D + D);
		}
		if (DA)
		{
			Gizmos.DrawLine(position2D + D, position2D + A);
		}
	}
}
