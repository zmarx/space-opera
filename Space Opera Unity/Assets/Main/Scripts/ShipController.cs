using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ValveIA = Valve.VR.InteractionSystem;

public class ShipController : MonoBehaviour
{
	public Transform Hand1;
	public Transform Hand2;
	public Stage Stage;
	public GameObject Shot;

	private ValveIA.Hand _valveHand;
	private Vector3 _positionOffset;

	public void Start()
	{
		_valveHand = Hand1.GetComponent<ValveIA.Hand>();
	}

	// Update is called once per frame
	void LateUpdate()
    {
        if (_valveHand .controller == null) return;

        // Change the ButtonMask to access other inputs
        if (_valveHand .controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
			Debug.Log("Reset offset");
			_positionOffset = Hand1.position - Stage.Min;
        }
        if (_valveHand .controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
			GameObject shot = Instantiate(Shot);
			shot.transform.position = transform.position + Shot.transform.localPosition;
			shot.SetActive(true);
        }
		Vector3 p = Hand1.position - _positionOffset;
		Stage.Clamp(ref p);
		p.z = Mathf.Floor(p.z * 10f) * 0.1f;

		transform.position = p;
    }
}
