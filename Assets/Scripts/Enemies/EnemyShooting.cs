using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public GameObject bullet;
    public float spawnPointMultiplier;

    void Update()
    {
        if(timeBtwAttack <= 0)
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
        
        Vector3 p = Player.p.playerOne.transform.position;
        Vector3 bulletSpawnPoint = transform.position + (p - transform.position).normalized * spawnPointMultiplier;
        Instantiate(bullet, bulletSpawnPoint, transform.rotation);
    }
}
