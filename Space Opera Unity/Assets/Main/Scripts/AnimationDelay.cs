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
        Vector3 p = transform.localPosition;
        Vector3 r = p;
        Vector3 v = Vector3.zero;
        r.y = 0.1f;
        r.z -= 0.25f * Stage.StaticDeltaLane;
        while (Mathf.Abs(p.y) > 0f)
        {
            p = Vector3.SmoothDamp(p, r, ref v, 0.2f);
            transform.localPosition = p;
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
