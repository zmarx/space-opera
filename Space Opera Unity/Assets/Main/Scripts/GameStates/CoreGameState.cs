using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGameState : GameState
{
	public Level _currentLevel;

	public override void OnEnableGameState ()
	{
		Reset ();
	}

	public void Reset ()
	{
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
