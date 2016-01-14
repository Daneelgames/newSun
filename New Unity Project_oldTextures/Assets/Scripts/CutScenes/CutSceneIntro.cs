using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CutSceneIntro : MonoBehaviour {

	public GameObject player;
	public GameObject gun;
	Text dialogue;
	
	Animator standUpAnimator;
	
	void Start () {
		dialogue = GameObject.Find("Dialogue").GetComponent<Text> ();
		dialogue.text = "";
		standUpAnimator = gameObject.GetComponent<Animator> ();
		player.SetActive (false);
		gun.SetActive (false);
		StartCoroutine(CloseUp());
	}
	
	IEnumerator CloseUp() {
		yield return new WaitForSeconds(3.0f);
		dialogue.text = "You have not finished the job.";
		yield return new WaitForSeconds(2.0f);
		dialogue.text = "";
		yield return new WaitForSeconds(1.0f);
		dialogue.text = "I'm coming for you.";
		yield return new WaitForSeconds(3.0f);
		dialogue.text = "";
		standUpAnimator.SetBool ("StandUp", true);
		StartCoroutine(StandUp());
	}
	
	IEnumerator StandUp() {
		yield return new WaitForSeconds(3.0f);
		player.SetActive (true);
		gameObject.SetActive (false);
	}
}
