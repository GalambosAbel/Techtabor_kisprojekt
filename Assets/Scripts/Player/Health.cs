using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float hp;
    public int max;
    public bool isDead;
    public float timeUntilInvulnerable;
    public float startTimeUInvul;
    public GameObject healthBar;

    void Update()
    {
        if(timeUntilInvulnerable >= 0)
        {
            timeUntilInvulnerable -= Time.deltaTime;
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
}
