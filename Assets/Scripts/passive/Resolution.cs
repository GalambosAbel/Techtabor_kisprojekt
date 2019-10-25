using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
	public void ChangeResolutionSmall ()
	{
		Screen.SetResolution(512, 910, false);
	}

	public void ChangeResolutionBig()
	{
		Screen.SetResolution(1024, 1820, false);
	}
}
