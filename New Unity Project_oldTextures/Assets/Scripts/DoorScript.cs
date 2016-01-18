using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour {

	public Transform spawnerOut;
	public Transform spawnerIn;
	public Transform player;
	public CharacterManager cm;
	public string description;

	Text dialogue;
	string whereTo = "Out";
	bool canPass = false;

	void Start () {
		//player = GameObject.Find("Player");
		//cm = player.GetComponent<CharacterManager> ();
		
		Renderer renderer = GetComponentInChildren<Renderer>();
		dialogue = GameObject.Find("Dialogue").GetComponent<Text> ();
		renderer.material.shader = Shader.Find ("Toon/Lit Outline");
	}

	void Update () {

		if(Input.GetKey("right shift"))
		{}
		else if(Input.GetKeyDown("return"))
		{
			if (canPass) {
				if (whereTo == "Out") {
					StartCoroutine (GoOut ());
				} else if (whereTo == "In") {
					StartCoroutine (GoIn ());
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") 
		{
			dialogue.text = description;
			GetComponentInChildren<Renderer> ().material.SetColor ("_OutlineColor", Color.white);
			canPass = true;
		}
		
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") 
		{
			dialogue.text = "";
			GetComponentInChildren<Renderer> ().material.SetColor ("_OutlineColor", Color.black);
			canPass = false;
		}
		
	}

	IEnumerator GoOut() {
		cm.GoToIdle();
		cm.enabled = false;
		yield return new WaitForSeconds (0.5f);
		player.transform.position = new Vector3( spawnerOut.transform.position.x, player.transform.position.y, spawnerOut.transform.position.z);
		cm.enabled = true;
		whereTo = "In";
	}
		
	IEnumerator GoIn() {
		cm.GoToIdle();
		cm.enabled = false;
		yield return new WaitForSeconds (0.5f);
		player.transform.position = new Vector3( spawnerIn.transform.position.x, player.transform.position.y, spawnerIn.transform.position.z);
		cm.enabled = true;
		whereTo = "Out";
	}
}
