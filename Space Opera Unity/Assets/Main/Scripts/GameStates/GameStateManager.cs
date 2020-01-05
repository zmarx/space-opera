using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameStateManager : MonoBehaviourSingleton<GameStateManager>
{

	public Dictionary<string, GameState> _gameStateDictionary;
	public string _startGameState;

	private void Start ()
	{
		_gameStateDictionary = new Dictionary<string, GameState> ();
		GameState[] gameStates = GetComponentsInChildren<GameState> ();

		foreach (GameState gameState in gameStates) {
			_gameStateDictionary.Add (gameState.GetType().Name, gameState);
		}

		SwitchState (_startGameState);
	}

	public void SwitchState<T>()
	{
		SwitchState(typeof(T).Name);
	}

	private void SwitchState (string stateName)
	{
		Assert.IsTrue (_gameStateDictionary.ContainsKey (stateName));
		foreach (GameState gameState in _gameStateDictionary.Values) {
			if (gameState.gameObject.name != stateName) {
				gameState.gameObject.SetActive (false);
			}
		}

		// enable last (to make sure the connected game object are enabled at the end and not disabled by a previous state)
		GameState activeState = _gameStateDictionary[stateName];
		activeState.gameObject.SetActive (true);
		activeState.OnEnableGameState ();
	}
}
