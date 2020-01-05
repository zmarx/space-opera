using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public int HitPoints = 1;
	public int ScoreValue = 1;
    public float DelayAnimation = 0f;
	public UnityEvent OnDeath = new UnityEvent();

	private Shootable _shootable;
	private Animator _animator;

	void Start()
	{
		_shootable = GetComponent<Shootable>();
		_shootable._onShot.AddListener(OnShot);

		_animator = GetComponent<Animator>();
        _animator.enabled = false;
        Invoke("DelayAnimationCR", DelayAnimation);
	}

    private void DelayAnimationCR()
    {
        _animator.enabled = true;
    }

    private void OnShot()
	{
		_animator.SetTrigger("Die");
		OnDeath.Invoke();
	}

    private void LateUpdate()
    {
        Vector3 p = transform.localPosition;
        p.z = Stage.CropToLane(p.z);
        transform.localPosition = p;
    }
}
