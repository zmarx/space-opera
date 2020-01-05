using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreGameState : GameState
{

	public override void OnEnableGameState ()
	{
		Reset ();
	}

	public void Reset ()
	{
		SceneManager.LoadScene(Progress.Instance.LevelScenes[0], LoadSceneMode.Additive);
	}

	public void OnLevelDone ()
	{
		Reset ();
	}

	public void OnPlayerDead ()
	{
		_gameStateManager.SwitchState ("DeathGameState");
	}

}
