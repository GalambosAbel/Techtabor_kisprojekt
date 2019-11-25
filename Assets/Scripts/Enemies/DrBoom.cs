using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrBoom : MonoBehaviour
{
	public int HP;
	public int bounty;

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
	public LayerMask players;
	public float attackRange;
	public int damage;
	#endregion

	public GameObject deathAnim;

	void Awake()
	{
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
		GetNewTarget();
		seeker = GetComponent<Seeker>();
		seeker.target = targetTransform.position;
		lastPos = transform.position;
	}

	void Update()
	{
		if (!targetTransform.gameObject.activeSelf) GetNewTarget();
		if (seeker != null) seeker.target = targetTransform.position;
		GoTowards(goalPos);

		float avoidPlatformX;
		float avoidPlatformY;
		if (newVelocity.x != 0) avoidPlatformX = newVelocity.x * Mathf.Abs(((transform.position.x - lastPos.x) / newVelocity.x) - 1);
		else avoidPlatformX = 0;
		if (newVelocity.y != 0) avoidPlatformY = newVelocity.y * Mathf.Abs(((transform.position.y - lastPos.y) / newVelocity.y) - 1);
		else avoidPlatformY = 0;
		transform.position += new Vector3(avoidPlatformX, avoidPlatformY, 0);

		lastPos = transform.position;

		Attack();
	}

	void SetGoal(Vector3 _goalPos)
	{
		goalPos = _goalPos;
	}

	void GetNewTarget()
	{
		if (targetTransform.gameObject.activeSelf) return;
		int index = Random.Range(0, Players.p.playerCount - Players.p.DeadPlayersCount);

		if (index == 0 && Players.p.playerOne.activeSelf && !Players.p.playersDead[0]) targetTransform = Players.p.playerOne.transform;
		else if (Players.p.playerTwo.activeSelf) targetTransform = Players.p.playerTwo.transform;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "bullet")
		{
			Weapon weapon = Players.p.playerOne.GetComponent<Weapon>();
			HP -= weapon.damage;
		}

		if (HP <= 0)
		{
			Players.p.money += bounty;
			Die();
		}
	}

	void GoTowards(Vector3 goal)
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
		FindObjectOfType<AudioManager>().Play("Explode");
		Destroy(gameObject);
		GameObject a = Instantiate(deathAnim, transform.position, transform.rotation);
		Destroy(a, 0.25f);
	}

	void Attack()
	{
		Collider2D[] playersInRange = Physics2D.OverlapCircleAll(transform.position, attackRange, players);
		for (int i = 0; i < playersInRange.Length; i++)
		{
			playersInRange[i].GetComponent<Health>().Shot(damage);
		}
		if (playersInRange.Length > 0) Die();
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);
	}
}