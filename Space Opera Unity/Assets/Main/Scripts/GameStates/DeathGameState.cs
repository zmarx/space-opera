using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGameState : GameState
{

	public void OnStartButtonPressed ()
	{
		_gameStateManager.SwitchState ("CoreGameState");
	}
}
