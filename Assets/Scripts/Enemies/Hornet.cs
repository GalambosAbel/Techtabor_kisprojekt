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
	float currentSpeed;
	public float speed;
	Vector2 newVelocity;
	Vector3 goalPos;
	Vector3 lastPos;
	bool left = true;
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

	public GameObject deathAnim;

	void Awake()
	{
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
		targetTransform = Players.p.playerOne.transform;
		seeker = GetComponent<Seeker>();
		seeker.target = targetTransform.position;
		lastPos = transform.position;
	}

	void Update()
	{
		if (seeker != null) seeker.target = targetTransform.position;
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

		float avoidPlatformX;
		float avoidPlatformY;
		if (newVelocity.x != 0) avoidPlatformX = newVelocity.x * Mathf.Abs(((transform.position.x - lastPos.x) / newVelocity.x) - 1);
		else avoidPlatformX = 0;
		if (newVelocity.y != 0) avoidPlatformY = newVelocity.y * Mathf.Abs(((transform.position.y - lastPos.y) / newVelocity.y) - 1);
		else avoidPlatformY = 0;
		transform.position += new Vector3(avoidPlatformX, avoidPlatformY, 0);

		lastPos = transform.position;
	}

	void SetGoal (Vector3 _goalPos)
	{
		goalPos = _goalPos;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "bullet")
        {
            Weapon weapon = Players.p.playerOne.GetComponent<Weapon>();
            HP -= weapon.damage;
        }
        if(HP <= 0)
        {
			Players.p.money += 3;
			Die();
        }
    }

	void GoTowards (Vector3 goal)
	{
		currentSpeed = speed * Time.deltaTime;
		newVelocity.x = (goal - transform.position).normalized.x * currentSpeed;
		newVelocity.y = (goal - transform.position).normalized.y * currentSpeed;
		if (Mathf.Abs(newVelocity.x) > Mathf.Abs((goal - transform.position).x)) newVelocity.x = (goal - transform.position).x;
		if (Mathf.Abs(newVelocity.y) > Mathf.Abs((goal - transform.position).y)) newVelocity.y = (goal - transform.position).y;
		transform.position += new Vector3(newVelocity.x, newVelocity.y, 0);
		if (newVelocity.x > 0 && left || newVelocity.x < 0 && !left)
		{
			left = !left;
			transform.Rotate(0f, 180f, 0);
		}
	}

    void Die()
    {
		Destroy(gameObject);
		GameObject a = Instantiate(deathAnim, transform.position, transform.rotation);
		Destroy(a, 0.25f);
	}

    void AttackUp()
    {
		Collider2D[] playersInRange = Physics2D.OverlapCircleAll(attackPosUp.position, attackRange, players);
		if (playersInRange.Length == 0)
		{
			AttackDown();
			return;
		}
		ableToAttack = false;
		timeUntilAttack = timeBetweenAttack;
		AnimateAttack(attackPosUp);
		for (int i = 0; i < playersInRange.Length; i++)
        {
            playersInRange[i].GetComponent<Health>().Shot(damage);
		}
	}

	void AttackDown()
	{
		Collider2D[] playersInRange = Physics2D.OverlapCircleAll(attackPosDown.position, attackRange, players);
		if (playersInRange.Length == 0)
		{
			return;
		}
		ableToAttack = false;
		timeUntilAttack = timeBetweenAttack;
		AnimateAttack(attackPosDown);
		for (int i = 0; i < playersInRange.Length; i++)
		{
			playersInRange[i].GetComponent<Health>().Shot(damage);
		}
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
