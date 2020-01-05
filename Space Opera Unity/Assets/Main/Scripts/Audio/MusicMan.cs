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
	private Dictionary<string, AudioClip> _musicDict = new Dictionary<string, AudioClip>();
	private AudioSource _audioSource;

	private void Start()
	{
		foreach (Sound sound in Sounds)
		{
			_musicDict.Add(sound.Name, sound.AudioClip);
		}

		_audioSource = GetComponent<AudioSource>();
	}

	public void QueueMusic(string name)
	{
		StartCoroutine(QueueMusicCoroutine(name));
	}

	private IEnumerator QueueMusicCoroutine(string name)
	{
		float timeDelay = 0;
		if (_audioSource.isPlaying)
		{
			timeDelay = _audioSource.clip.length - _audioSource.time;
		}

		yield return new WaitForSeconds(timeDelay);
		PlayMusic(name);

	}

	public void PlayMusic(string musicId)
	{
		StopAllCoroutines();
		_audioSource.Stop();

		_audioSource.clip = _musicDict[musicId];
		_audioSource.Play();

	}
}
