using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviourSingleton<Player>
{
	private int _playerHp = 3;
	public int Hp
	{
		get
		{
			return _playerHp;
		}
		set
		{
			_playerHp = value;
			OnPlayerHpChanged.Invoke();
		}
	}
	public UnityEvent OnPlayerHpChanged = new UnityEvent();

	private int _playerScore = 0;
	public int Score
	{
		get
		{
			return _playerScore;
		}
		set
		{
			_playerScore = value;
			OnScoreChanged.Invoke();
		}
	}
	public UnityEvent OnScoreChanged = new UnityEvent();
}
