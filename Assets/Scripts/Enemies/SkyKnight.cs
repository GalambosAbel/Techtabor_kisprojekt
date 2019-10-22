using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyKnight : MonoBehaviour
{
    Seeker seeker;
    public Vector3 targetPos = Vector3.zero;
    Vector3 playerLastPos;
    Vector3 lastPos;
    Vector3 goalPos;
    public Transform target;
    public float minDistance;
    public float maxDistance;
    public float speed;
    bool left = true;
    Vector2 newVelocity;
    public int HP;
	public GameObject deathAnim;

    void Awake()
    {
        target = Players.p.playerOne.transform;
        seeker = GetComponent<Seeker>();
        targetPos = transform.position;
        seeker.target = targetPos;
        lastPos = transform.position;
        playerLastPos = target.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) targetPos = transform.position;

        SetTargetPosition();
        if (seeker != null) seeker.target = targetPos;
        if (Mathf.Abs((transform.position - target.position).magnitude) > minDistance) GoTowards(goalPos);
        else GoTowards(target.position + (transform.position - target.position).normalized * maxDistance);

        float avoidPlatformX;
        float avoidPlatformY;
        if (newVelocity.x != 0) avoidPlatformX = newVelocity.x * Mathf.Abs(((transform.position.x - lastPos.x) / newVelocity.x) - 1);
        else avoidPlatformX = 0;
        if (newVelocity.y != 0) avoidPlatformY = newVelocity.y * Mathf.Abs(((transform.position.y - lastPos.y) / newVelocity.y) - 1);
        else avoidPlatformY = 0;
        transform.position += new Vector3(avoidPlatformX, avoidPlatformY, 0);

        lastPos = transform.position;
        playerLastPos = target.position;
    }

    void SetGoal(Vector3 _goalPos)
    {
        goalPos = _goalPos;
    }

    void GoTowards(Vector3 goal)
    {
        float currentSpeed = speed * Time.deltaTime;
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

    void SetTargetPosition()
    {
        if (transform.position == targetPos)
        {
            targetPos = GetNewTargetPosition();
            targetPos = target.position + (targetPos - target.position).normalized * Random.Range(minDistance, maxDistance);
        }
        else
        {
            targetPos += target.position - playerLastPos;
        }
    }

    Vector3 GetNewTargetPosition()
    {
        float X = Random.Range(-128f, 128f) + Camera.main.transform.position.x;
        float Y = Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize) + Camera.main.transform.position.y;
        return new Vector3(X, Y, 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(target.position, minDistance);
        Gizmos.DrawWireSphere(target.position, maxDistance);
        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(targetPos, Vector3.one * 10);
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
			Players.p.money += 6;
			Die();
        }
    }

	void Die()
    {
		Destroy(gameObject);
		GameObject a = Instantiate(deathAnim, transform.position, transform.rotation);
		Destroy(a, 0.33333333333f);
	}
}
