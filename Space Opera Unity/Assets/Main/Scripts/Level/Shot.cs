using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
	public Vector3 Speed;
	public float TimeToLive;
	public LayerMask LayerDestroy;

	void Update()
	{
		TimeToLive -= Time.deltaTime;
		transform.Translate(Speed * Time.deltaTime);

		if (TimeToLive < 0f)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		// destroy shot if it hits an obstacle
		if (other.GetComponent<Coin>() == null)
		{
			Destroy(gameObject);
		}

		// if shot hits a object within the layer mask destroy the object
		if (((1 << other.gameObject.layer) & LayerDestroy) != 0)
		{
			Shootable shootable = other.GetComponent<Shootable>();
			if (shootable != null)
			{
				shootable.GetShot(other);
			}
		}
	}
}
