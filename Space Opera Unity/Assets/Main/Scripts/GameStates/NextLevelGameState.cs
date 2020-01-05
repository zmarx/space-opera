using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelGameState : GameState
{
	public Level _currentLevel;

	public override void OnEnableGameState ()
	{
		Reset ();
	}

	public void Reset ()
	{
	}

}
