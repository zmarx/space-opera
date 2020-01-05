using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
	public int HitPoints = 1;
	public int ScoreValue = 10;
	public UnityEvent OnDeath = new UnityEvent();

	[Header("Shooting abilities")]
	public Shot Shot;
	public Vector3 ShootDirection = Vector3.left;
	[Tooltip("0 - exactly in direction, 1 - 360° up/down")]
	[Range(0f, 1f)]
	public float ShootRangeUpDown = 0f;
	[Tooltip("0 - exactly in direction, 1 - 360° up/down")]
	[Range(0f, 1f)]
	public float ShootRangeLeftRight = 0f;
	[Tooltip("0 - rarely shoots, 1 - shoots always")]
	[Range(0f, 1f)]
	public float ShootProbability = 0f;
	[Tooltip("seconds before next shot will be fired (when probability is set to 100%")]
	public float ShootTimeToFire = 2f;
	[Tooltip("0 - not aiming at player, 1 - 100% aiming at player")]
	[Range(0f, 1f)]
	public float AimingAtPlayer = 0f;

	private Shootable _shootable;
	private Animator _animator;
	private bool _isAlive;
	private float _timeToFire = 0f;

	void Start()
	{
		_shootable = GetComponent<Shootable>();
		_shootable._onShot.AddListener(OnShot);

		_animator = GetComponent<Animator>();
		_isAlive = true;
		ResetTimeToFire();
		_timeToFire += UnityEngine.Random.Range(0f, ShootTimeToFire);
	}

	private void ResetTimeToFire()
	{
		float p = Mathf.Clamp01(1f - ShootProbability);
		float r = UnityEngine.Random.Range(0f, p);
		_timeToFire = ShootTimeToFire;
		while (Mathf.Abs(p) > Mathf.Epsilon)
		{
			_timeToFire = r * _timeToFire + ShootTimeToFire;
			r = UnityEngine.Random.Range(0f, p);
			p = 0.5f * p;
		}
	}

	private void OnShot()
	{
		if (!_isAlive) return;
		AudioMan.Instance.PlaySound("EnemyHit");


		HitPoints--;
		if (HitPoints == 0)
		{
			_isAlive = false;
			enabled = false;
			_animator.SetTrigger("Die");
			OnDeath.Invoke();
			Player.Instance.Score += HitPoints;
			AudioMan.Instance.PlaySound("EnemyDeath");
		}
	}

	private void LateUpdate()
	{
		if (_timeToFire > 0f)
		{
			_timeToFire -= Time.deltaTime;
		}
		else
		{
			FireShot();
		}

		Vector3 p = transform.localPosition;
		p.z = Stage.CropToLane(p.z);
		transform.localPosition = p;
	}

	private void FireShot()
	{
		ShootDirection = Vector3.Lerp(ShootDirection.normalized, (transform.position - Player.Instance.transform.position).normalized, AimingAtPlayer).normalized;
		// ShootRangeUpDown , ShootRangeLeftRight

		Shot shot = Instantiate(Shot);
		shot.Speed = ShootDirection;
		shot.transform.position = transform.position + Shot.transform.localPosition;
		shot.gameObject.SetActive(true);

		ResetTimeToFire();
	}
}
