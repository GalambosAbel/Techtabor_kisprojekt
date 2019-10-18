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

    void Update()
    {
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
		for (int i = 0; i < dmg; i++)
		{
			if (hp <= 0) return;
			hearts[hp - 1].GetComponent<SpriteRenderer>().sprite = empty;
			hp--;
			if (hp <= 0) Die();
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
