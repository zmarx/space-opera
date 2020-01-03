using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
	public Vector3 Min;
	public Vector3 Max;

	public void Clamp (ref Vector3 position)
	{
		position.x = Mathf.Clamp(position.x, Min.x, Max.x);
		position.y = Mathf.Clamp(position.y, Min.y, Max.y);
		position.z = Mathf.Clamp(position.z, Min.z, Max.z);
	}
}
