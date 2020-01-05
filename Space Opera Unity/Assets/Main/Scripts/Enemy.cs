using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float DelayAnimation = 0f;
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
	}

    private void LateUpdate()
    {
        Vector3 p = transform.localPosition;
        p.z = Stage.CropToLane(p.z);
        transform.localPosition = p;
    }
}
