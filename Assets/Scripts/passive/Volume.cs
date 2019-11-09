using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
	public void SetVolume (float volume)
	{
		PlayerPrefs.SetFloat("volume", volume);
	}
}
