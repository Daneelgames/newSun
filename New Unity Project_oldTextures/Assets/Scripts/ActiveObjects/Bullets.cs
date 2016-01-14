using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullets : MonoBehaviour {

	public CharacterManager cm;

	Text dialogue;
	GameObject bulletCount;
	AudioSource pickUp;
	bool canSkip = false;
	bool canInteract = false;
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") 
		{
			dialogue.text = "Bullets";
			canInteract = true;
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") 
		{
			dialogue.text = "";
			canInteract = false;
		}
		
	}

	void Start ()
	{
		bulletCount = GameObject.Find ("BulletCount");
		dialogue = GameObject.Find("Dialogue").GetComponent<Text> ();
		pickUp = GetComponent<AudioSource> ();
		Renderer renderer = GetComponentInChildren<Renderer>();
		renderer.material.shader = Shader.Find ("Toon/Lit Outline");
	}
	
	void Update ()
	{
		if (canInteract == true) {
			GetComponentInChildren<Renderer> ().material.SetColor ("_OutlineColor", Color.white);
		} else {
			GetComponentInChildren<Renderer> ().material.SetColor ("_OutlineColor", Color.black);
		}
		
		if (canInteract == true && canSkip == false) {
			if(Input.GetKey("right shift"))
			{}
			else if(Input.GetKeyDown("return"))
			{
				Interaction();
			}
		}
		
		if (canSkip == true) {
			if(Input.GetKeyDown("return"))
				StartCoroutine(WaitAfterInteraction(0.5F));
		}
	}
	
	
	void Interaction ()
	{
		StartCoroutine(PhraseFirst(0.5F));
		canInteract = false;
	}

	IEnumerator PhraseFirst (float waitTime) {
		pickUp.Play ();
		dialogue.text = "Found some bullets";
		cm.GoToIdle();
		cm.enabled = false;
		yield return new WaitForSeconds(waitTime);
		canSkip = true;
	}
	
	IEnumerator WaitAfterInteraction(float waitTime)
	{
		dialogue.text = "";
		yield return new WaitForSeconds (waitTime);
		pickUp.Play ();
		cm.enabled = true;
		cm.bullets += 6;
		canSkip = false;
		canInteract = true;
		bulletCount.SetActive(true);
		gameObject.SetActive (false);
	}

}
