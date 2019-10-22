using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
	SpriteRenderer sr;
    public float hp;
    public int max;
    public bool isDead;
    public float timeUntilInvulnerable;
    public float startTimeUInvul;
    public GameObject healthBar;

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
		}
		else if (Players.p.playerCount == 1)
		{
			Players.p.playerTwo = gameObject;
			Players.p.playerCount++;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Update()
    {
        if(timeUntilInvulnerable >= 0)
        {
            timeUntilInvulnerable -= Time.deltaTime;
			sr.color = sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1 - timeUntilInvulnerable / startTimeUInvul / 2);
		}
        
        if (Input.GetKeyDown(KeyCode.K) && hp < max)
        {
            Heal(10);
        }
        healthBar.transform.localScale = new Vector3(hp/100, healthBar.transform.localScale.y, 1);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
		if (col.tag == "enemyBullet") 
        {
            Shot(20);
        }
        if(col.name == "Fire")
        {
            hp = 0;
            Die();
        }
    }
    
    public void Shot(int dmg)
    {
        if(timeUntilInvulnerable <= 0)
        {
            if(dmg >= hp)
            {
                hp = 0;
                Die();
            }
            else
            {
                hp -= dmg;
            }
            timeUntilInvulnerable = startTimeUInvul;
			SpriteRenderer sr = GetComponent<SpriteRenderer>();
        }
    }

     public void Heal(int heal)
    {
        hp += heal;
    }

    void Die()
    {
        isDead = true;
        SceneManager.LoadScene("Menu");
    }
    public void FullHeal()
    {
        hp = 100;
        healthBar.transform.localScale = new Vector3(1, healthBar.transform.localScale.y, 1);
    }
}
