using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//movement variables
	public float runSpeed;
	Rigidbody myRb;
	Animator myAnimator;
	bool facingRight;
	public float walkSpeed;
	bool running;

	//jumping variables
	bool grounded = false;
	Collider[] groundCollisions;
	float groundCheckRadious= 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	// Use this for initialization
	void Start () {
		myRb = GetComponent<Rigidbody> ();
		myAnimator = GetComponent<Animator> ();
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		
		running = false;
		if (grounded && Input.GetAxis ("Jump") > 0) {
			grounded = false;
			myAnimator.SetBool ("grounded", grounded);
			myRb.AddForce (new Vector3 (0, jumpHeight, 0));
		}

		groundCollisions = Physics.OverlapSphere (groundCheck.position, groundCheckRadious, groundLayer);
		if (groundCollisions.Length > 0) {
			grounded = true;
		} else {
			grounded = false;
		}

		myAnimator.SetBool ("grounded", grounded);
		float moveX = Input.GetAxis ("Horizontal");	
		myAnimator.SetFloat ("speed", Mathf.Abs (moveX));
		float moveZ = Input.GetAxis ("Vertical");

		float sneaking = Input.GetAxisRaw("Fire3");
		myAnimator.SetFloat ("sneaking",sneaking);

		float firing = Input.GetAxis ("Fire1");
		myAnimator.SetFloat ("shooting", firing);

		if (sneaking > 0 || firing>0 && grounded) {
			myRb.velocity = new Vector3 (moveX * walkSpeed, myRb.velocity.y, moveZ * walkSpeed);
		} 
		else {
			myRb.velocity = new Vector3 (moveX * runSpeed , myRb.velocity.y, moveZ *runSpeed);
			if (Mathf.Abs (moveX) > 0) {
				running = true;
			}
		}

		if (moveX > 0 && !facingRight) {
			Flip ();
		} else if (moveX < 0 && facingRight) {
			Flip ();
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 trasformPlayer = transform.localScale;
		trasformPlayer.z *= -1;
		transform.localScale = trasformPlayer;
	}

	public float getFacing(){
		if (facingRight) {
			return 1;
		} else
			return -1;
	}

	public bool getRunning(){
		return running;
	}
}
