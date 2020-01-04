using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreGameState : GameState
{
	public Level _currentLevel;

	public override void OnEnableGameState ()
	{
		Reset ();
	}

	public void Reset ()
	{
		SceneManager.LoadScene("level1", LoadSceneMode.Additive);
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
