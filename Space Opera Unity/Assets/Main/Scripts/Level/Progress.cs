using System.Collections;
using UnityEngine;

public class Progress : MonoBehaviourSingleton<Progress>
{
	private int _currentLevel;

	public void Reset()
	{
		_currentLevel = 0;
	}

	public string[] LevelScenes = new string[]
	{
		"level1",
		"level2"
	};
}
