using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
	SpriteRenderer sr;
    public float hp;
    public int max;
    public float timeUntilInvulnerable;
    public float startTimeUInvul;
    public GameObject healthBar;
    int whichPlayer;

	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	void Start()
	{
		if (Players.p.playerCount == 0)
		{
			Players.p.playerOne = gameObject;
			Players.p.playerCount++;
            whichPlayer = 0;
		}
		else if (Players.p.playerCount == 1)
		{
			Players.p.playerTwo = gameObject;
			Players.p.playerCount++;
            whichPlayer = 1;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Update()
    {
        if(hp <= 0)
        {
            Die();
        }
        if(timeUntilInvulnerable >= 0)
        {
            timeUntilInvulnerable -= Time.deltaTime;
			sr.color = sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1 - timeUntilInvulnerable / startTimeUInvul / 2);
		}
        healthBar.transform.localScale = new Vector3(hp/max, healthBar.transform.localScale.y, 1);

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
		if (col.tag == "enemyBullet") 
        {
            Shot(20);
        }

    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.name == "Fire")
        {
            FireDamage();
        }

    }


    public void Shot(int dmg)
    {
        if(timeUntilInvulnerable <= 0)
        {
            if(dmg >= hp)
            {
                hp = 0;
            }
            else
            {
                hp -= dmg;
            }
			FindObjectOfType<AudioManager>().Play("Hurt");
			timeUntilInvulnerable = startTimeUInvul;
        }
    }

	public void Heal(int heal)
	{
		if (hp + heal < max)
		{
			hp += heal;
		}
		else hp = max;
    }

    void Die()
    {
		FindObjectOfType<MenuScript>().Died(whichPlayer);
        Destroy(gameObject);
    }

    void FireDamage()
    {
        if (hp > 0)
        {
            hp--;
        }
    }
}
