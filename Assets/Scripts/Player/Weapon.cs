using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public float spawnPointMultiplier;
    public int damage;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            
        }
    }

    void Shoot()
    {
        if (GetComponent<Ammunition>().CanShoot())
        {
			FindObjectOfType<AudioManager>().Play("PlayerShoot");
			Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0;
            Vector3 bulletSpawnPoint = transform.position + (mouse - transform.position).normalized * spawnPointMultiplier;
            Instantiate(bullet, bulletSpawnPoint, transform.rotation);
        }
    }
}
