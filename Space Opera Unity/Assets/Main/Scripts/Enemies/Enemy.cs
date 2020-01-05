using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
	public int HitPoints = 1;
	public int ScoreValue = 1;
<<<<<<< HEAD
=======
	public float DelayAnimation = 0f;
>>>>>>> 59027e5ade3b96f47a0bc3b96ac265d746186da7
	public UnityEvent OnDeath = new UnityEvent();

	private Shootable _shootable;
	private Animator _animator;
	private bool _isAlive;

	void Start()
	{
		_shootable = GetComponent<Shootable>();
		_shootable._onShot.AddListener(OnShot);

		_animator = GetComponent<Animator>();
<<<<<<< HEAD
	}

    private void OnShot()
=======
		_animator.enabled = false;
		Invoke("DelayAnimationCR", DelayAnimation);

		_isAlive = true;
	}

	private void DelayAnimationCR()
	{
		_animator.enabled = true;
	}

	private void OnShot()
>>>>>>> 59027e5ade3b96f47a0bc3b96ac265d746186da7
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
