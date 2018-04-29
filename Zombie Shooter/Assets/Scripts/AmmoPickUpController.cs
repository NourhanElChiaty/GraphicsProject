using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUpController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponentInChildren<FireBullet>().reload ();
			Destroy (transform.root.gameObject);
		}
	}
}
