using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shootable : MonoBehaviour
{
    public UnityEvent _onShot = new UnityEvent();

	public void GetShot()
	{
		_onShot.Invoke();
	}
}
