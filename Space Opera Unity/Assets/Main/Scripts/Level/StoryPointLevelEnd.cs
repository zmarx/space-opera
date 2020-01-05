using UnityEngine;

public class StoryPointLevelEnd : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		var level = transform.root.GetComponent<Level>();
		Debug.Assert(level, "root component has no level script attached!");

		GameStateManager.Instance.SwitchState<NextLevelGameState>();
	}
}
