using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class MusicMan : MonoBehaviourSingleton<MusicMan>
{
	[System.Serializable]
	public class Sound
	{
		public string Name;
		public AudioClip AudioClip;
	}


	public Sound[] Sounds;
	private Dictionary<string, AudioClip> _soundDict = new Dictionary<string, AudioClip>();
	private AudioSource _audioSource;

	private void Start()
	{
		foreach (Sound sound in Sounds)
		{
			_soundDict.Add(sound.Name, sound.AudioClip);
		}

		_audioSource = GetComponent<AudioSource>();
	}

	public void PlayMusic(string name)
	{
		_audioSource.PlayOneShot(_soundDict[name]);

	}
}
