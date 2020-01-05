using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreView : MonoBehaviour
{

	private Text _label;

	private void Start()
	{
		_label = GetComponentInChildren<Text>();
		Player.Instance.OnScoreChanged.AddListener(UpdateView);
	}

	private void UpdateView()
	{
		_label.text = Player.Instance.Score.ToString();
	}

}
