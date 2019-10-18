using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hornet : MonoBehaviour
{
	public int HP;

	#region movementVars
	public Transform targetTransform;
	Seeker seeker;
	public Rigidbody2D rb;
	float currentSpeed;
	public float speed;
	Vector2 newVelocity;
	Vector3 goalPos;
	#endregion

	#region attackVars
	public Transform attackPosUp;
	public Transform attackPosDown;
	public float attackRange;
	public float timeBetweenAttack;
	float timeUntilAttack;
	bool ableToAttack;
	public LayerMask players;
	public int damage;
	public GameObject attackAnim;
	#endregion

void Awake()
	{
		targetTransform = Player.p.playerOne.transform;
		seeker = GetComponent<Seeker>();
		seeker.target = targetTransform.position;
	}

	void Update()
	{
		seeker.target = targetTransform.position;
		GoTowards(goalPos);
		if (ableToAttack)
		{
			AttackUp();
		}
		else
		{
			timeUntilAttack -= Time.deltaTime;
			if (timeUntilAttack <= 0) ableToAttack = true;
		}
    }

	void SetGoal (Vector3 _goalPos)
	{
		goalPos = _goalPos;
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

    void AttackUp()
    {
		Collider2D[] playersInRange = Physics2D.OverlapCircleAll(attackPosUp.position, attackRange, players);
		if (playersInRange.Length == 0)
		{
			AttackDown();
			return;
		}
		AnimateAttack(attackPosUp);
        for (int i = 0; i < playersInRange.Length; i++)
        {
            playersInRange[i].GetComponent<Health>().Shot(damage);
		}
		ableToAttack = false;
		timeUntilAttack = timeBetweenAttack;
	}

	void AttackDown()
	{
		Collider2D[] playersInRange = Physics2D.OverlapCircleAll(attackPosDown.position, attackRange, players);
		if (playersInRange.Length == 0)
		{
			return;
		}
		AnimateAttack(attackPosDown);
		for (int i = 0; i < playersInRange.Length; i++)
		{
			playersInRange[i].GetComponent<Health>().Shot(damage);
		}
		ableToAttack = false;
		timeUntilAttack = timeBetweenAttack;
	}

	void AnimateAttack (Transform pos)
	{
		GameObject anim = Instantiate(attackAnim, pos.position, pos.rotation);
		Destroy(anim, 0.333333f);
	}

	void OnDrawGizmos()
    {
		Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosUp.position, attackRange);
		Gizmos.DrawWireSphere(attackPosDown.position, attackRange);
	}
}
