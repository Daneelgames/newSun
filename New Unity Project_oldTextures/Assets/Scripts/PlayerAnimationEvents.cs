using UnityEngine;
using System.Collections;

public class PlayerAnimationEvents : MonoBehaviour {

	public Collider gun;

	AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource>();
		gun.enabled = false;
	}

	void StepSound ()
	{
		audioSource.pitch = Random.Range (0.6f, 1.0f);
		audioSource.Play ();
	}
	
	void GunStartCollider (){
		gun.enabled = true;
	}
	
	void GunEndCollider (){
		gun.enabled = false;
	}
}
