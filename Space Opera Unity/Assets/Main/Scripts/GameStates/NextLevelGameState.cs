using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelGameState : GameState
{
	private float _waitTime = 3f;

	public override void OnEnableGameState ()
	{
		StartCoroutine(Reset());
	}

	public IEnumerator Reset ()
	{
		yield return new WaitForSeconds(_waitTime);
		_gameStateManager.SwitchState<CoreGameState>();
	}

}
