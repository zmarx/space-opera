using UnityEngine;

public class Level : MonoBehaviour
{
    public float SmoothTime = 0.1f;
    public float TargetSpeed = 0.1f;

    private float _speed = 0f;
    private float _velocity = 0f;
    private float _restoreTargetSpeed = 0f;

    public void PauseScrolling()
    {
        if (TargetSpeed != 0f)
        {
            _restoreTargetSpeed = TargetSpeed;
        }
        TargetSpeed = 0f;
    }

    public void ResumeScrolling()
    {
        if (_restoreTargetSpeed != 0f)
        {
            TargetSpeed = _restoreTargetSpeed;
        }
    }

    private void Update()
    {
        _speed = Mathf.SmoothDamp(_speed, TargetSpeed, ref _velocity, SmoothTime);
        transform.Translate(-_speed * Time.deltaTime, 0f, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResumeScrolling();
        }
    }
}
