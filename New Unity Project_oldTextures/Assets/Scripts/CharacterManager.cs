using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {
	
	public AudioSource gun;
	public float forceValue;
	public int bullets = 0;
	public GameObject shot;
	public GameObject projectile;
	public Transform shotHolder;
	public GameObject playersGun;

	float torgueValue = 5;
	Animator animator;
	bool canShoot = true;
	bool aiming = false;

	void Start () {
		animator = GetComponentInChildren<Animator> ();
	}

	public void GoToIdle ()
	{
		animator.SetBool ("Walk", false);
		animator.SetBool ("Back", false);
		animator.SetBool ("Turn", false);
	}

	//movement
	void FixedUpdate () {
		var force = transform.rotation * Vector3.forward;
		if (Input.GetKey ("left shift") && aiming == false) {
			forceValue = 50;
			animator.speed = 2.0f;
		} else {
			forceValue = 25;
			animator.speed = 1.0f;
		}
		if (aiming == false) {
			if (Input.GetKey ("w")) {
				animator.SetBool ("Walk", true);
				animator.SetBool ("Back", false);
				animator.SetBool ("Turn", false);
			} else if (Input.GetKey ("a") || Input.GetKey ("d")) {
				animator.SetBool ("Walk", false);
				animator.SetBool ("Back", false);
				animator.SetBool ("Turn", true);
			} else if (Input.GetKey ("s")) {
				animator.SetBool ("Walk", false);
				animator.SetBool ("Back", true);
				animator.SetBool ("Turn", false);
			} else {
				animator.SetBool ("Walk", false);
				animator.SetBool ("Back", false);
				animator.SetBool ("Turn", false);
			}
		}
		if (Input.GetKey ("right shift") && playersGun.activeInHierarchy) {
			animator.SetBool ("Walk", false);
			animator.SetBool ("Back", false);
			animator.SetBool ("Turn", false);
			animator.SetBool ("Aiming", true);
			aiming = true;
			if (Input.GetKeyDown("return") && canShoot == true)
			{
				StartCoroutine(Attack());
			}
		} else {
			animator.SetBool ("Aiming", false);
			aiming = false;
		}
		if (aiming == false) {
			if (Input.GetKey("w")){
				GetComponent<Rigidbody>().AddForce(force * forceValue);
				torgueValue = 5;
			} else if (Input.GetKey("s")) {
				GetComponent<Rigidbody>().AddForce(-force * forceValue);
				torgueValue = -5;
			}
			else
			{
				torgueValue = 5;
			}
		}
		
		if (Input.GetKey("a")){
			GetComponent<Rigidbody>().AddTorque(0, -torgueValue, 0);
		} else if (Input.GetKey("d")){
			GetComponent<Rigidbody>().AddTorque(0, torgueValue, 0);
		}

	}

	IEnumerator Attack()
	{
		if (bullets > 0) {
			Instantiate(shot, shotHolder.position, shotHolder.rotation );
			Instantiate(projectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+2, gameObject.transform.position.z), gameObject.transform.rotation );
			gun.GetComponent<AudioSource>().pitch = Random.Range (0.6f, 1.0f);
			gun.Play();
			animator.SetTrigger ("Shoot");
			bullets--;
			canShoot = false;
			yield return new WaitForSeconds (1.0f);
			canShoot = true;
		}
		else {
			GetComponent<AudioSource>().pitch = Random.Range (0.6f, 1.0f);
			GetComponent<AudioSource>().Play();
			animator.SetTrigger ("Melee");
			canShoot = false;
			yield return new WaitForSeconds (1.0f);
			canShoot = true;
		}
	
	}

}
