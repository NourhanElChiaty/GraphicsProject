using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUpController : MonoBehaviour {
	public float healthAmount;
	public AudioClip healthPickupSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponent<PlayerHealth> ().addHealth (healthAmount);
			Destroy (transform.root.gameObject);
			AudioSource.PlayClipAtPoint(healthPickupSound,transform.position,1f);
		}
	}
}
