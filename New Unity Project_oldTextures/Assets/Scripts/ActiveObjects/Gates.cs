﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gates : MonoBehaviour {

	public CharacterManager cm;

	DoorScript door;
	Gates gates;
	Text dialogue;
	Animator animator;
	bool canInteract = false;
	bool canSkip = false;
	bool gatesOpen = false;

	void Start ()
	{
		gates = gameObject.GetComponent<Gates> ();
		door = gameObject.GetComponent<DoorScript> ();
		door.enabled = false;
		animator = gameObject.GetComponent<Animator> ();
		dialogue = GameObject.Find("Dialogue").GetComponent<Text> ();
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
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
		{
			dialogue.text = "Gates";
			canInteract = true;
		}
		if (other.tag == "Projectile" || other.tag == "Gun")
		{
			if (!gatesOpen) {
				GetComponent<AudioSource> ().Play ();
				door.enabled = true;
				animator.SetTrigger ("Brake");
				gates.enabled = false;
				gatesOpen = true;
			}
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") 
		{
			dialogue.text = "";
			canInteract = false;
		}
		
	}
	
	void Interaction ()
	{
		StartCoroutine(PhraseFirst(0.5F));
		canInteract = false;
	}

	IEnumerator PhraseFirst (float waitTime) {
		dialogue.text = "Closed by lock";
		cm.GoToIdle();
		cm.enabled = false;
		yield return new WaitForSeconds(waitTime);
		canSkip = true;
	}
	
	IEnumerator WaitAfterInteraction(float waitTime)
	{
		dialogue.text = "";
		yield return new WaitForSeconds (waitTime);
		cm.enabled = true;
		canSkip = false;
		canInteract = true;
	}

}
