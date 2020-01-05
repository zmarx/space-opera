using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public int Value = 5;

	public void Collect()
	{
		Destroy(gameObject);
		AudioMan.Instance.PlaySound("CoinCollect");
		Player.Instance.Score += Value;
	}
}
