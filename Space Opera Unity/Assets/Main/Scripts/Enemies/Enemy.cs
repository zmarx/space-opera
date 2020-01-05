using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
	public int HitPoints = 1;
	public int ScoreValue = 10;
	public UnityEvent OnDeath = new UnityEvent();

	private Shootable _shootable;
	private Animator _animator;
    private bool _isAlive;

	void Start()
	{
		_shootable = GetComponent<Shootable>();
		_shootable._onShot.AddListener(OnShot);

		_animator = GetComponent<Animator>();
        _isAlive = true;
	}

	private void OnShot()
	{
		if (!_isAlive) return;

		_isAlive = false;
		_animator.SetTrigger("Die");
		OnDeath.Invoke();
		Player.Instance.Score += HitPoints;
	}

	private void LateUpdate()
	{
		Vector3 p = transform.localPosition;
		p.z = Stage.CropToLane(p.z);
		transform.localPosition = p;
	}
}
