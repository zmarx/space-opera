using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHitpointView : MonoBehaviour
{

	private Text _label;

	private void Start()
	{
		_label = GetComponentInChildren<Text>();
		Player.Instance.OnPlayerHpChanged.AddListener(UpdateView);
	}

	private void UpdateView()
	{
		_label.text = Player.Instance.Hp.ToString();
	}

}
