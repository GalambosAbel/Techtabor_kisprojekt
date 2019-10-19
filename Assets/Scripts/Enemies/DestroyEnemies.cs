using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemies : MonoBehaviour
{
    public void KillEnemies()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
			transform.GetChild(i).gameObject.SendMessage("Die");
        }
    }
}
