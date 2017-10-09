using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordHit : MonoBehaviour {

	public float weaponDamage;
	public AudioClip playerHit;
	public AudioClip playerHitMiss;
	AudioSource playerAS;

	public bool terkenaAttack;
	Animator enemyAnim;

	//Pushback enemy when player hit enemy
	public float pushBackForce;

	bool detectEnemy = false;

	// Use this for initialization
	void Start () {
		playerAS = GetComponent<AudioSource> ();
		enemyAnim = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		enemyAnim.SetBool ("terkenaSerangan", false);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			terkenaAttack = true;
			playHitAudio();
			pushBack(other.transform);
			enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth> ();
			hurtEnemy.addDamage (weaponDamage);

		}
	}

	public void playHitAudio(){
		playerAS.clip = playerHit;
		playerAS.PlayOneShot (playerHit);
	}

	public void playAttackAudio(){
			playerAS.clip = playerHitMiss;
			playerAS.PlayOneShot (playerHitMiss);
	}

	void pushBack(Transform pushedObject){
		Vector2 pushDirection = new Vector2 ((pushedObject.position.x - transform.position.x),0 ).normalized;
		pushDirection *= pushBackForce;
		Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D> ();
		pushRB.velocity = Vector2.zero;
		pushRB.AddForce (pushDirection, ForceMode2D.Impulse);
	}
}
