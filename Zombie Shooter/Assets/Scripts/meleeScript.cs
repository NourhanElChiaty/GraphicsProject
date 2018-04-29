using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeScript : MonoBehaviour {

	public float damage;
	public float knockBack;
	public float KnockBackRadius;
	public float meleeRate;//how often i can swing my weapon
	float nextMelee;//the next time you can swing
	int shootableMask; 
	Animator myAnimator;
	PlayerController myPC;

	// Use this for initialization
	void Start () {
		shootableMask = LayerMask.GetMask ("Shootable");
		myAnimator = transform.root.GetComponent<Animator> ();
		myPC = transform.root.GetComponent<PlayerController> ();
		nextMelee = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float melee = Input.GetAxis ("Fire2");

		if (melee > 0 && nextMelee < Time.time && !(myPC.getRunning ())) {
			myAnimator.SetTrigger ("gunMelee");
			nextMelee = Time.time + meleeRate;

			// do damage
			Collider[] attacked = Physics.OverlapSphere(transform.position,KnockBackRadius, shootableMask);

		}
	}
}
