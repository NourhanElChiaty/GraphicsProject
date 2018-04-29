using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootFireBall : MonoBehaviour {
	public float damage;
	public float speed;

	Rigidbody myRb;
	// Use this for initialization
	void Start () {
		myRb = GetComponentInParent<Rigidbody> ();
		if (transform.rotation.y > 0) {
			myRb.AddForce (Vector3.right * speed, ForceMode.Impulse);
		} else {
			myRb.AddForce (Vector3.right * -speed, ForceMode.Impulse);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy" || other.gameObject.layer == LayerMask.NameToLayer("Shootable")) {
			myRb.velocity = Vector3.zero;
			EnemyHealth theEnemyHealth = other.GetComponent<EnemyHealth>();
			if (theEnemyHealth != null) {
				theEnemyHealth.addDamage(damage);
				theEnemyHealth.addFire();
			}
			Destroy (gameObject);
		}
	}
}
