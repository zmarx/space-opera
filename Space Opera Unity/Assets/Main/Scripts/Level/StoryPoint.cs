using UnityEngine;

public class StoryPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var level = transform.root.GetComponent<Level>();
        Debug.Assert(level, "root component has no level script attached!");

        level.PauseScrolling();
    }
}
