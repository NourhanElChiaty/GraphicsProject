using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
	public float damage;
	public float damageRate;
	public float pushBackForce;

	float nextDamage;

	bool playerInRange = false;
	GameObject theplayer;
	PlayerHealth thePlayerHealth;

	// Use this for initialization
	void Start () {
		nextDamage = Time.time;
		theplayer = GameObject.FindGameObjectWithTag ("Player");
		thePlayerHealth = theplayer.GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInRange) {
			Attack ();
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			playerInRange = true;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			playerInRange = false;
		}
	}
	void Attack(){
		if (nextDamage <= Time.time) {
			thePlayerHealth.addDamage (damage);
			nextDamage = Time.time + damageRate;

			pushBack (theplayer.transform);
		}
	}
	void pushBack(Transform pushedObject){
		Vector3 pushDirection = new Vector3 (0, (pushedObject.position.y - transform.position.y), 0).normalized;
		pushDirection *= pushBackForce;

		Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody> ();
		pushedRB.AddForce (pushDirection, ForceMode.Impulse);
	}
}
