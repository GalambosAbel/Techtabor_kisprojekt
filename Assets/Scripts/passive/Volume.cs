using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
	void Awake()
	{
		PlayerPrefs.SetFloat("volume", 1f);
	}

	public void SetVolume (float volume)
	{
		PlayerPrefs.SetFloat("volume", volume);
	}
}
