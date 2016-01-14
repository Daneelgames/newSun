using UnityEngine;
using System.Collections;

public class CameraTrigger : MonoBehaviour {

	public GameObject cam;
	public Collider player;

	Camera targetCam;
	AudioListener audioListener;

	void Start () {
		targetCam = cam.GetComponent<Camera> ();
		targetCam.enabled = false;
		audioListener = cam.GetComponent<AudioListener> ();
		audioListener.enabled = false;
	}
	
	     
	void OnTriggerEnter(Collider player){
		if (player.tag == "Player") {
			if (Camera.main != null) {
				Camera.main.enabled = false;
			}
			targetCam.enabled = true;
		}
	}
}
