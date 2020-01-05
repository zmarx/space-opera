using UnityEngine;

public class StoryPointMusic : MonoBehaviour
{
	public string MusicName;


    private void OnTriggerEnter(Collider other)
    {
		MusicMan.Instance.PlayMusic(MusicName);
    }
}
