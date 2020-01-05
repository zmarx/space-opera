using UnityEngine;
using UnityEngine.Assertions;

public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;
	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				T[] instances = FindObjectsOfType<T>();
				Assert.IsTrue(instances.Length == 1);

				_instance = instances[0];
			}

			return _instance;
		}
	}

}
