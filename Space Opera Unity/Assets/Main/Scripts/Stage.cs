using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Vector3 Min;
    public Vector3 Max;
    public float DeltaLane;
    public GameObject [] ShowOnStart;

    private static float StaticDeltaLane;

    private void Start()
    {
        StaticDeltaLane = DeltaLane;
        foreach (var go in ShowOnStart)
        {
            go.SetActive(true);
        }
    }

    public void Clamp(ref Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, Min.x, Max.x);
        position.y = Mathf.Clamp(position.y, Min.y, Max.y);
        position.z = Mathf.Clamp(position.z, Min.z, Max.z);
    }

    public static float CropToLane(float value)
    {
        value = value / StaticDeltaLane;
        value = Mathf.Floor(value+0.1f);
        value *= StaticDeltaLane;
        return value;
    }
}
