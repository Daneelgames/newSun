using UnityEngine;
using System.Collections;

[RequireComponent (typeof (LineRenderer))]

public class LaserScript : MonoBehaviour {
	private LineRenderer lr;
	private int SolidMask = 8;
	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit, SolidMask)) {
			if (hit.collider) {
				lr.SetPosition (1, new Vector3 (hit.distance, 0, 0));
			}
		}
		else 
		{
			lr.SetPosition(1, new Vector3(100,0,0));
		}
	}
}
