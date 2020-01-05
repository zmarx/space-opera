using UnityEngine;
using ValveIA = Valve.VR.InteractionSystem;

public class ShipController : MonoBehaviour
{
	public Transform Hand1;
	public Transform Hand2;
	public Stage Stage;
	public Shot Shot;
	public float TimeToFire = 0.1f;

	private ValveIA.Hand _valveHand;
	private Vector3 _positionOffset;
	private float _timeToFire = 0f;

	public void Start()
	{
		_valveHand = Hand1.GetComponent<ValveIA.Hand>();
	}

	// Update is called once per frame
	void LateUpdate()
	{
		_timeToFire -= Time.deltaTime;

		if (_valveHand.controller != null)
		{
			// Change the ButtonMask to access other inputs
			if (_valveHand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
			{
				ResetOffset();
			}
			if (_valveHand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
			{
				Shoot();
			}
		}
		if (Input.GetButton("Reset"))
		{
			ResetOffset();
		}
		if (Input.GetAxis("Fire") > 0.2f)
		{
			Shoot();
		}

		Vector3 dp;
		dp.x = Input.GetAxis("Horizontal");
		dp.y = Input.GetAxis("Vertical");
		dp.z = Input.GetAxis("Depth");

		Hand1.Translate(dp * Time.deltaTime);

		Vector3 p = Stage.transform.InverseTransformPoint(Hand1.position);// - _positionOffset;
		p.z += 0.5f * Stage.DeltaLane;
		Stage.Clamp(ref p);

#if UNITY_EDITOR
		// clamp hand position for desktop testing, so we don't exceed the staging bounds
		// otherwise joystick inputs would feel awkward to wait for the position to come in stage range again.
		//Hand1.position = p + _positionOffset;
#endif

		// set position on a defined lane
		p.z = Stage.CropToLane(p.z);

		transform.localPosition = p;
	}

	private void Shoot()
	{
		if (_timeToFire <= 0f)
		{
			_timeToFire = TimeToFire;
			Shot shot = Instantiate(Shot);
			shot.transform.position = transform.position + Shot.transform.localPosition;
			shot.gameObject.SetActive(true);
		}
	}

	private void ResetOffset()
	{
		Debug.Log("Reset offset");
		_positionOffset = Hand1.position - Stage.Min;
		_positionOffset.z += 0.5f * (Stage.Max.z - Stage.Min.z);
	}

	private void OnTriggerEnter(Collider other)
	{
		Player.Instance.Hp--;
	}
}
