using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
	public float Speed;
	public float TimeToLive;

	void Update()
    {
		TimeToLive -= Time.deltaTime;
		transform.Translate(Speed * Time.deltaTime, 0, 0);

		if (TimeToLive < 0f)
		{
			Destroy(gameObject);
		}
    }
}
