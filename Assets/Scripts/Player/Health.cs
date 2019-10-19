using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int hp;
    public GameObject[] hearts;
    public Sprite empty;
    public Sprite fill;
    public int max;
    public bool isDead;
    public float timeUntilInvulnerable;
    public float startTimeUInvul;

    void Update()
    {
        if(timeUntilInvulnerable >= 0)
        {
            timeUntilInvulnerable -= Time.deltaTime;
        }
        if(hp <= 0)
        {
            Die();
        }
        if(hp != 0)
        {
            isDead = false;
        }
        if(Input.GetKeyDown(KeyCode.L) && !isDead)
        {
            Shot(1);
        }
        if (Input.GetKeyDown(KeyCode.K) && hp < max)
        {
            Heal();
        }

    }

    public void Shot(int dmg)
    {
        if(timeUntilInvulnerable <= 0)
        {
            for (int i = 0; i < dmg; i++)
            {
                if (hp <= 0) return;
                hearts[hp - 1].GetComponent<SpriteRenderer>().sprite = empty;
                hp--;
                if (hp <= 0) Die();

            }
            timeUntilInvulnerable = startTimeUInvul;
        }
    }

     public void Heal()
    {
        hp++;
        hearts[hp-1].GetComponent<SpriteRenderer>().sprite = fill;
    }

    void Die()
    {
        isDead = true;
    }
}
