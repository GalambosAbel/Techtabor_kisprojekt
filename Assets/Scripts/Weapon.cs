using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
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
