using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordHit : MonoBehaviour {

	public float weaponDamage;
	public AudioClip playerHit;
	AudioSource playerAS;


	// Use this for initialization
	void Start () {
		playerAS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			playerAS.clip = playerHit;
			playerAS.PlayOneShot (playerHit);
			enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth> ();
			hurtEnemy.addDamage (weaponDamage);
		}
	}

	/*void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Enemy") {
			enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth> ();
			hurtEnemy.addDamage (weaponDamage);
		}
	}*/
}
