using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float despawnDistance;
    public float speed;
    public Rigidbody2D rb;

    void Start()
    {
        Vector3 p = Players.p.playerOne.transform.position;
        rb.velocity = (p - transform.position).normalized * speed;
    }

    void Update()
    {
        Vector3 p = Players.p.playerOne.transform.position;
        Vector3 v = transform.position;
        if (v.x > p.x + despawnDistance || v.x < p.x - despawnDistance
            || v.y > p.y + despawnDistance || v.y < p.y - despawnDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
