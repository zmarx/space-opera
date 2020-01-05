using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHitpointView : MonoBehaviour
{

	private Text _label;

	private void Start()
	{
		_label = GetComponentInChildren<Text>();
		Player.Instance.OnPlayerHpChanged.AddListener(UpdateView);
		UpdateView();
	}

	private void UpdateView()
	{
		_label.text = "Lifes:" + Player.Instance.Hp.ToString();
	}

}
