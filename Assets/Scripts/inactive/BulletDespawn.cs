using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : MonoBehaviour
{
    void Update()
    {
        Vector3 v = transform.position;
        if (v.x > 20 || v.x < -20 || v.y > 20 || v.y < -20)
        {
            Destroy(gameObject);
        }
    }
}
