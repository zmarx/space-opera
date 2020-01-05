using UnityEngine;

public class StoryPointBoss : MonoBehaviour
{
	public EnemySet Boss;


    private void OnTriggerEnter(Collider other)
    {
		if (!Boss.IsAlive) return;

        var level = transform.root.GetComponent<Level>();
        Debug.Assert(level, "root component has no level script attached!");

        level.PauseScrolling();
    }
}
