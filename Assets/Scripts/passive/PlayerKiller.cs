using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
	public Transform bottom;
    void Update()
    {
		if (transform.position.y < bottom.position.y) Debug.Log("aaaaaaaaaaaaapuff");
    }
}
