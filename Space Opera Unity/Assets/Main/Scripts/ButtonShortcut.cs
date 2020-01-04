using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonShortcut : MonoBehaviour
{
	public KeyCode KeyCode;

	private Button _button;

	private void Start()
	{
		_button = GetComponent<Button>();
	}

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode))
		{
			_button.onClick.Invoke();
		}
	}
}
