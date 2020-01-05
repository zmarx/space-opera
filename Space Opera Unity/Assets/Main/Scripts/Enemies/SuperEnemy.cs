using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemy : MonoBehaviour
{
	private int _numParts;

	private void Start()
	{
		Enemy[] childEnemies = GetComponentsInChildren<Enemy>();
		_numParts = childEnemies.Length;

		foreach (Enemy enemy in childEnemies)
		{
			enemy.OnDeath.AddListener(OnPartDestroyed);
		}
	}

	private void OnPartDestroyed()
	{
		_numParts--;

		if (_numParts == 0)
		{
			// SuperEnemy is dead
			var level = transform.root.GetComponent<Level>();
			Debug.Assert(level, "root component has no level script attached!");

			level.ResumeScrolling();
		}
	}
}
