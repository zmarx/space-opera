using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class GameState : MonoBehaviour
{
	public GameObject[] _enabledGameObjects;

	protected GameStateManager _gameStateManager;

	private void Start ()
	{
		_gameStateManager = (GameStateManager)FindObjectOfType (typeof(GameStateManager));
		Assert.IsNotNull (_gameStateManager);
	}

	public virtual void OnEnableGameState ()
	{
	}

	private void OnEnable ()
	{
		foreach (GameObject go in _enabledGameObjects) {
			go.SetActive (true);
		}
	}

	private void OnDisable ()
	{
		foreach (GameObject go in _enabledGameObjects) {
			if (go == null) continue;
			go.SetActive (false);
		}
	}
}
