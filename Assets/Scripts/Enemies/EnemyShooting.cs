using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public GameObject bullet;
    public float spawnPointMultiplier;
	public LayerMask blockingMask;

	void Update()
    {
		if (timeBtwAttack <= 0 && LineOfSight(transform.position, Players.p.playerOne.transform.position, blockingMask))
        {
            Shoot();
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
	}

    void Shoot()
    {
		FindObjectOfType<AudioManager>().Play("EnemyShoot");
		Vector3 p = Players.p.playerOne.transform.position;
        Vector3 bulletSpawnPoint = transform.position + (p - transform.position).normalized * spawnPointMultiplier;
        Instantiate(bullet, bulletSpawnPoint, transform.rotation);
    }

	bool LineOfSight (Vector3 from, Vector3 to, LayerMask block)
	{
		Vector3 direction = (to - from).normalized;
		float distance = (to - from).magnitude;

		RaycastHit2D sightTest = Physics2D.Raycast(from, direction, distance, block);
		if (sightTest.collider != null)
		{
			return false;
		}
		return true;
	}
}
