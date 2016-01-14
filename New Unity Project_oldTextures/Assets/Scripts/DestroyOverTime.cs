using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour {

	public float timeToDestroy;

	void Start () {
		Destroy (gameObject, timeToDestroy);
	}

}
