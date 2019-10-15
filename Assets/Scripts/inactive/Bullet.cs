using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    void Start()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        rb.velocity = (mouse - transform.position).normalized * speed;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
