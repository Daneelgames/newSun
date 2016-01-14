using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed;
	
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
		Destroy (gameObject, 2.0f);

	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player" || other.tag == "Gun" || other.tag == "Trigger") {
			return;
		} else {
			print (other.name);
			Destroy (gameObject);
		}

	}
}
