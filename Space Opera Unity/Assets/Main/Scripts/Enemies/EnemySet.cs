using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySet : MonoBehaviour
{
	public int HitPoints = 100;

	private int _numParts;
    public UnityEvent OnDeath = new UnityEvent();
	public bool IsAlive;

    private void Start()
	{
		Enemy[] childEnemies = GetComponentsInChildren<Enemy>();
		_numParts = childEnemies.Length;

		foreach (Enemy enemy in childEnemies)
		{
			enemy.OnDeath.AddListener(OnPartDestroyed);
		}

		IsAlive = true;
	}

	private void OnPartDestroyed()
	{
		_numParts--;

		if (_numParts == 0)
		{
			// SuperEnemy is dead
			var level = transform.root.GetComponent<Level>();
			Debug.Assert(level, "root component has no level script attached!");

			Player.Instance.Score += HitPoints;

			level.ResumeScrolling();
            OnDeath.Invoke();
			IsAlive = false;
		}
	}
}
