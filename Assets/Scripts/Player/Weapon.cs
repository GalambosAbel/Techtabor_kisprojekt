using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
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
        if (GetComponent<Ammunition>().Shooting())
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}
