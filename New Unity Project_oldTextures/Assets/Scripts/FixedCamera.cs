using UnityEngine;
using System.Collections;

public class FixedCamera : MonoBehaviour {

	public bool follow = false;
	public Transform player;

	float rotateDir = 1.0f;
	float rotationOffset = 0.0f;
	Camera cam;
	AudioListener al;

	void Start (){
		cam = gameObject.GetComponent<Camera> ();
		al = gameObject.GetComponent<AudioListener> ();
		if (follow == false) {
			StartCoroutine (TurnRight (5.0F));
		}
	}

	void Update () {
		if (cam.enabled == false) {
			al.enabled = false;
		} else {
			al.enabled = true;
		}
		if (follow){
			transform.LookAt(new Vector3(player.transform.position.x,player.transform.position.y+3,player.transform.position.z));
		}

		transform.Rotate (0, 0, rotationOffset);

		rotationOffset = Mathf.Lerp(0, rotateDir, 0.3f * Time.deltaTime);
	}
	
	IEnumerator TurnRight (float waitTime) {
		yield return new WaitForSeconds(waitTime);
		StartCoroutine(TurnLeft(5.0F));
		rotateDir = -1.0f;
	}
	
	IEnumerator TurnLeft (float waitTime) {
		yield return new WaitForSeconds(waitTime);
		StartCoroutine(TurnRight(5.0F));
		rotateDir = 1.0f;
	}
}
