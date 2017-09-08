using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementControllerBack : MonoBehaviour {

	public float enemySpeed;

	Animator enemyAnimator;

	//jalan
	Transform myTrans;


	//Facing
	public GameObject enemyGraphic;
	bool canFlip = true;
	bool facingRight = false;
	float flipTime = 5f;
	float nextFlipChance;

	//attacking
	public float chargeTime;
	float startChargerTime;
	bool charging;
	Rigidbody2D enemyRB;

	// Use this for initialization
	void Start () {
		enemyAnimator = GetComponentInChildren<Animator> ();
		enemyRB = GetComponent<Rigidbody2D> ();
		myTrans = this.transform;
	}

	// Update is called once per frame
	void FixedUpdate () {
		/*if (Time.time > nextFlipChance) {
			if (Random.Range (0, 10) >= 5) flipFacing ();
			nextFlipChance = Time.time + flipTime;
		}*/

		/*if (!facingRight) {
		Vector2 myVel = enemyRB.velocity;
		myVel.x = -myTrans.right.x * enemySpeed;
		enemyRB.velocity = myVel;
	}
	else {
		Vector2 myVel = enemyRB.velocity;
		myVel.x = myTrans.right.x * enemySpeed;
		enemyRB.velocity = myVel;
	}*/

}

void OnTriggerEnter2D(Collider2D other){
	if (other.tag == "Player") {
		if (facingRight && other.transform.position.x < transform.position.x) {
			flipFacing (); 
			Debug.Log ("Player ketemu");
			enemyRB.velocity = new Vector2 (0f, 0f);
			move ();

		} else if (!facingRight && other.transform.position.x > transform.position.x) {
			flipFacing ();
			Debug.Log ("Player tidak ketemu");
			enemyRB.velocity = new Vector2 (0f, 0f);
			move ();	
		}

		/*if (!facingRight) enemyRB.AddForce (new Vector2 (-1, 0) * enemySpeed);
			else enemyRB.AddForce (new Vector2 (1,0) * enemySpeed);*/

		canFlip = true;
		charging = true;
		startChargerTime = Time.time + chargeTime;
	}


}

void OnTriggerStay2D(Collider2D other){
	if(other.tag == "Player"){
		if (startChargerTime < Time.time) {
			/*if (!facingRight) enemyRB.AddForce (new Vector2 (-1, 0) * enemySpeed);
				else enemyRB.AddForce (new Vector2 (1,0) * enemySpeed);*/
			canFlip = true;
			//charging = false;
			enemyAnimator.SetBool("isCharging", charging);
		}
	}
}


void OnTriggerExit2D(Collider2D other){
	if (other.tag == "Player") {
		canFlip = true;
		//charging = false;
		enemyRB.velocity = new Vector2 (0f, 0f);
		//enemyAnimator.SetBool ("isCharging", charging);
	}
}

void flipFacing(){
	if (!canFlip) return;
	float facingX = enemyGraphic.transform.localScale.x;
	facingX *= -1f;
	enemyGraphic.transform.localScale = new Vector3 (facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
	facingRight = !facingRight;
}

void move(){
	if (!facingRight) enemyRB.AddForce (new Vector2 (-1, 0) * enemySpeed);
	else enemyRB.AddForce (new Vector2 (1,0) * enemySpeed);
}

}
