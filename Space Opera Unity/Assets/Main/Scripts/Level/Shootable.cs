using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shootable : MonoBehaviour
{
    public class UnityEventCollider : UnityEvent<Collider> { }
    public UnityEventCollider _onShot = new UnityEventCollider();

	public void GetShot(Collider collider)
	{
		_onShot.Invoke(collider);
	}
}
