using UnityEngine;
using System.Collections;

[RequireComponent (typeof (LineRenderer))]

public class LaserScript : MonoBehaviour {

	public LayerMask solidMask;

	private LineRenderer lr;

	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, 100, solidMask)) {
			if (hit.collider) {
				lr.SetPosition (1, new Vector3 (0, 0, hit.distance));
				//print (hit.collider.gameObject.name);
                print(hit.collider.gameObject.layer);
            }
		}
		else
		{
			lr.SetPosition(1, new Vector3(0,0,100));
		}
	}
}