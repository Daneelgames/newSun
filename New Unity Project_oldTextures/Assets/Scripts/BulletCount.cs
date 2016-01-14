using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletCount : MonoBehaviour {
	
	public CharacterManager cm;

	int bulletCount;
	Text count;

	void Start (){
		CharacterManager cm = GetComponent<CharacterManager> ();
		count = gameObject.GetComponent<Text> ();
	}

	void Update () {
		bulletCount = cm.bullets;
		count.text = "" + bulletCount.ToString ();
	}
}
