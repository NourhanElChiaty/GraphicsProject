using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garageDoor : MonoBehaviour {

    public bool hey;
    public bool resetable;
    public GameObject door;
    public GameObject gear;
    public bool startOpen;

    bool firstTrigger = false;
    bool open = true;
    Animator doorAnim;
    Animator gearAnim;
    AudioSource doorAudio;

    // Use this for initialization
    void Start()
    {
        doorAnim = door.GetComponent<Animator>();
        gearAnim = gear.GetComponent<Animator>();
        doorAudio = door.GetComponent<AudioSource>();

        if (!startOpen)
        {
            open = false;
            doorAnim.SetTrigger("doorTrigger");
            doorAudio.Play();
            gearAnim.SetTrigger("gearRotating");
            doorAudio.Play();

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !firstTrigger)
        {
            if (!resetable) firstTrigger = true;
            doorAnim.SetTrigger("doorTrigger");
            open = !open;
            gearAnim.SetTrigger("gearRotating");
            doorAudio.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
