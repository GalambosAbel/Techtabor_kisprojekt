using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;

	void Awake()
	{
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();

			s.source.clip = s.clip;
			s.source.volume = s.volume * PlayerPrefs.GetFloat("volume");
			s.source.loop = s.loop;
		}
	}

	void Start()
    {
		Play("Main");
    }

	public void Play (string clipName)
	{
		Sound s = Array.Find(sounds, sound => sound.name == clipName);
		if (s == null)
		{
			Debug.LogWarning("missing sound: '" + clipName + "'");
			return;
		}
		s.source.Play();
	}
}
