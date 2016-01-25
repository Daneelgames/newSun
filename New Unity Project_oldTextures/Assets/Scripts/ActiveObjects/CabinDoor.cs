using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CabidDoor : MonoBehaviour {

	public CharacterManager cm;
	
	Text dialogue;
	bool canInteract = false;
	bool canSkip = false;
	
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") 
		{
			dialogue.text = "Door";
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

	
	void Interaction ()
	{
		StartCoroutine(PhraseFirst(0.5F));
		canInteract = false;
	}

	IEnumerator PhraseFirst (float waitTime) {
		dialogue.text = "I have to find her first";
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
