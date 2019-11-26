using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public GameObject bullet;
    public float spawnPointMultiplier;
    public int damage;

    void Update()
    {
        if (Input.GetKeyDown((KeyCode)PlayerPrefs.GetInt("Shoot2", 258)))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (GetComponent<Ammunition>().CanShoot())
        {
            FindObjectOfType<AudioManager>().Play("PlayerShoot");
            Vector3 crosshair = FindObjectOfType<Crosshair>().transform.position;
            Vector3 bulletSpawnPoint = transform.position + (crosshair - transform.position).normalized * spawnPointMultiplier;
            Instantiate(bullet, bulletSpawnPoint, transform.rotation);
        }
    }
}
