using System;
using UnityEngine;

public class AnimationDelay : MonoBehaviour
{
    public float DelayAnimation = 0f;

    private Animator []_animators;

    public void ShotDown()
    {
        StartCoroutine(ShotDownCR());
    }

    private System.Collections.IEnumerator ShotDownCR()
    {
        while (transform.localPosition.y > 0f)
        {
            transform.localPosition -= new Vector3(0f, Time.deltaTime, 0f);
            yield return null;
        }
    }

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
