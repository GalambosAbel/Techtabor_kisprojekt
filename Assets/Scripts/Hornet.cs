using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hornet : MonoBehaviour
{
	//public Transform targetTransform;
	public Rigidbody2D rb;
	float currentSpeed;
	public float speed;
	Vector2 newVelocity;
    public int HP;
    public Transform attackPos;
    public float attackRange;
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    bool ableToAttack;
    public LayerMask enemies;

	void Awake()
	{
    }

    void Update()
	{
        //GoTowards(targetTransform.position);
        if (Input.GetKeyDown(KeyCode.C))
        {
            Attack();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "bullet")
        {
            Weapon weapon = Player.p.playerOne.GetComponent<Weapon>();
            HP -= weapon.damage;
        }
        if(HP <= 0)
        {
            Die();
        }
    }

    void GoTowards (Vector3 goal)
	{
		currentSpeed = speed * Time.deltaTime * 1000;
		newVelocity.x = (goal - transform.position).normalized.x;
		newVelocity.y = (goal - transform.position).normalized.y;
		rb.velocity = newVelocity * currentSpeed;

	}
    void Die()
    {
        Destroy(gameObject);
    }
    void Attack()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);
        for (int i = 0; i < enemiesInRange.Length; i++)
        {
            enemiesInRange[i].GetComponent<Health>().Shot();
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}


