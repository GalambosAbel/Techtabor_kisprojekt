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
        Vector3 p = GetComponentInParent<SkyKnight>().targetTransform.position;
        rb.velocity = (p - transform.position).normalized * speed;
		transform.rotation = Quaternion.FromToRotation(Vector3.up, p - transform.position);
    }

    void Update()
    {
        Vector3 p = GetComponentInParent<SkyKnight>().targetTransform.position;
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
