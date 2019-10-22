using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
	public Text money;

    void Update()
    {
		money.text = Players.p.money.ToString(); 
    }
}
