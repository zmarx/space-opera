using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuGameState : GameState
{

	public void OnButtonStartPushed()
	{
		_gameStateManager.SwitchState<CoreGameState>();
	}

	public void Start()
	{
		foreach (string level in Progress.Instance.LevelScenes)
		{
			Scene loadedLevel = SceneManager.GetSceneByName(level);

			if (loadedLevel.isLoaded)
			{
				SceneManager.UnloadSceneAsync(loadedLevel, UnloadSceneOptions.None);

			}
		}
	}
}
