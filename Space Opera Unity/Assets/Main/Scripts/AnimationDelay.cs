using System;
using UnityEngine;

public class AnimationDelay : MonoBehaviour
{
    public float DelayAnimation = 0f;

    private Animator []_animators;
    private void Start()
    {
        _animators = GetComponentsInChildren<Animator>(true);
        EnableAnimators(false);
        Invoke("DelayAnim", DelayAnimation);
    }

    private void EnableAnimators(bool enable)
    {
        foreach (var ani in _animators)
            ani.enabled = enable;
    }

    private void DelayAnim()
    {
        EnableAnimators(true);
    }
}
