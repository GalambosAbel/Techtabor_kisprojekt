using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
	public float speed = 100;
	bool active = false;

    void Update()
    {
		if (active) transform.position += new Vector3(0, speed * Time.deltaTime, 0);
		else if(Players.p.playerOne != null) if (Players.p.playerOne.transform.position.y > transform.position.y) active = true;
        else if(Players.p.playerTwo != null) if (Players.p.playerTwo.transform.position.y > transform.position.y) active = true;
    }

	public void Stop ()
	{
		active = false;
	}
}
