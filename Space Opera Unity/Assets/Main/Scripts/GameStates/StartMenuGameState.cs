using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuGameState : GameState
{

	public void OnButtonStartPushed ()
	{
		_gameStateManager.SwitchState ("CoreGameState");
	}
}
