using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBullet : MonoBehaviour {
	public float timeBetweenBullets = 0.15f;

	public GameObject projectTile;
	//bulletInfo
	public Slider playerAmmoSlider;
	float nextBullet;
	public int maxRounds;
	public int startingRounds;
	int remainingRounds;

	AudioSource gunMuzzelAS;
	public AudioClip shootSound;
	public AudioClip reloadSound;


	// Use this for initialization
	void Awake () {
		nextBullet = 0f;
		remainingRounds = startingRounds;
		playerAmmoSlider.maxValue = maxRounds;
		playerAmmoSlider.value = remainingRounds;
		gunMuzzelAS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerController myPlayer = transform.root.GetComponent<PlayerController> ();
		if (Input.GetAxisRaw ("Fire1") > 0 && nextBullet < Time.time && remainingRounds > 0) {
			nextBullet = Time.time + timeBetweenBullets;
			Vector3 rotation;
			if (myPlayer.getFacing () == -1f) {
				rotation = new Vector3 (0, -90, 0);
			} else {
				rotation = new Vector3 (0, 90, 0);
			}
			Instantiate (projectTile, transform.position, Quaternion.Euler (rotation));

			playASound (shootSound);


			remainingRounds -= 1;
			playerAmmoSlider.value = remainingRounds;
		}
	}

	public void reload(){
		remainingRounds = maxRounds;
		playerAmmoSlider.value = remainingRounds;
		playASound (reloadSound);
	}

	void playASound(AudioClip playTheSound){
		gunMuzzelAS.clip = playTheSound;
		gunMuzzelAS.Play ();
	}
}
