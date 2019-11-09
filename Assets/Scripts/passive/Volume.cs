using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    void Awake()
    {
        GetComponentInChildren<Slider>().value = PlayerPrefs.GetFloat("volume", 1f);
    }

	public void SetVolume (float volume)
	{
		PlayerPrefs.SetFloat("volume", volume);
	}
}
