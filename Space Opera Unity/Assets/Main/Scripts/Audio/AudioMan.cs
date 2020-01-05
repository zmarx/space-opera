using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioMan : MonoBehaviourSingleton<AudioMan>
{
	[System.Serializable]
	public class Sound
	{
		public string Name;
		public AudioClip AudioClip;
		public float PitchVariation;
	}

	public Sound[] Sounds;
	private Dictionary<string, Sound> _soundDict = new Dictionary<string, Sound>();
	private AudioSource _audioSource;

	private void Start()
	{
		foreach (Sound sound in Sounds)
		{
			_soundDict.Add(sound.Name, sound);
		}

		_audioSource = GetComponent<AudioSource>();
	}

	public void PlaySound(string name)
	{
		Sound sound = _soundDict[name];
		_audioSource.pitch = Random.Range(1 - sound.PitchVariation, 1 + sound.PitchVariation);
		_audioSource.PlayOneShot(sound.AudioClip);
	}
}
