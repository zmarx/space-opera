using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	private Shootable _shootable;
	private Animator _animator;

	void Start()
	{
		_shootable = GetComponent<Shootable>();
		_shootable._onShot.AddListener(OnShot);

		_animator = GetComponent<Animator>();
	}

	private void OnShot()
	{
		_animator.SetTrigger("Die");
	}

}
