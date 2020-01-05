using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreGameState : GameState
{
	private void Start()
	{
		Debug.Log("lsdjf");
	}

	public override void OnEnableGameState()
	{
		StartCoroutine(Reset());
	}

	public IEnumerator Reset()
	{
		foreach (string level in Progress.Instance.LevelScenes)
		{
			Scene loadedLevel = SceneManager.GetSceneByName(level);
			if (loadedLevel.isLoaded)
			{
				AsyncOperation async = SceneManager.UnloadSceneAsync(loadedLevel, UnloadSceneOptions.None);

				while (!async.isDone)
				{
					yield return null;
				}
			}
		}

		SceneManager.LoadScene(Progress.Instance.LevelScenes[0], LoadSceneMode.Additive);

		MusicMan.Instance.PlayMusic("LevelMusic");
	}

	public void OnLevelDone()
	{
		Reset();
	}

	public void OnPlayerDead()
	{
		_gameStateManager.SwitchState<DeathGameState>();
	}

}
