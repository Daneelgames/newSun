using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public Transform spawnerOut;
	public Transform spawnerIn;
	public Transform player;
	public CharacterManager cm;

	string whereTo = "Out";

	void Start () {
		//player = GameObject.Find("Player");
		//cm = player.GetComponent<CharacterManager> ();
		
		Renderer renderer = GetComponentInChildren<Renderer>();
		renderer.material.shader = Shader.Find ("Toon/Lit Outline");
	}

	void Update () {

		if(Input.GetKey("right shift"))
		{}
		else if(Input.GetKeyDown("return"))
		{
			if (whereTo == "Out") {
				StartCoroutine(GoOut());
			}
			else if (whereTo == "In") {
				StartCoroutine(GoIn());
			}
		}
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") 
		{
			GetComponentInChildren<Renderer> ().material.SetColor ("_OutlineColor", Color.white);
		}
		
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") 
		{
			GetComponentInChildren<Renderer> ().material.SetColor ("_OutlineColor", Color.black);
		}
		
	}

	IEnumerator GoOut() {
		cm.GoToIdle();
		cm.enabled = false;
		yield return new WaitForSeconds (1.0f);
		player.transform.position = new Vector3( spawnerOut.transform.position.x, player.transform.position.y, spawnerOut.transform.position.z);
		cm.enabled = true;
		whereTo = "In";
	}
		
	IEnumerator GoIn() {
		cm.GoToIdle();
		cm.enabled = false;
		yield return new WaitForSeconds (1.0f);
		player.transform.position = new Vector3( spawnerIn.transform.position.x, player.transform.position.y, spawnerIn.transform.position.z);
		cm.enabled = true;
		whereTo = "Out";
	}
}
