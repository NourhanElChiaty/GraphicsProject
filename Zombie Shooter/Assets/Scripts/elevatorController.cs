using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorController : MonoBehaviour {

    public float resetTime; //how much time elevtor stays at it's position
    Animator elevAnim;
    AudioSource elevAS;

    float downTime;
    bool elevIsUp = false;

	// Use this for initialization
	void Start () {
        elevAnim = GetComponent<Animator>();
        elevAS = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (downTime <= Time.time && elevIsUp) {
            elevAnim.SetTrigger("activateElevator");
            elevIsUp = false;
            elevAS.Play();


        }
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            elevAnim.SetTrigger("activateElevator");
            downTime = Time.time + resetTime;
            elevIsUp = true;
            elevAS.Play();
        }
    }

}
