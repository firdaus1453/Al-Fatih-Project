using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	//Move enemy
	public LayerMask enemyMask,deteksiplayer;
	public float speed = 1;
	Rigidbody2D myBody;
	Transform myTrans;
	float myWidth, myHeight;

	//Animasi
	Animator anim;

	//Enemy
	public Transform Target;
	private GameObject Enemy;
	private GameObject Player;
	private float Range;
	public float Speed;

	gerak KomponenGerak;
	public int nyawaMusuh;

	// Use this for initialization
	void Start () {
		//Animasi
		anim = GetComponent<Animator>();

		Enemy = GameObject.FindGameObjectWithTag ("Enemy");
		Player = GameObject.FindGameObjectWithTag ("Player");

		KomponenGerak = GameObject.Find("Player").GetComponent<gerak>();
		//Rest ();

		//------------------Enemy Move----------------------------------------------------------------
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D>();
		SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
		myWidth = mySprite.bounds.extents.x;
		myHeight = mySprite.bounds.extents.y;
		//------------------End Enemy Move------------------------------------------------------------------
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (nyawaMusuh <= 0) {
			KomponenGerak.koin += 10;
			Destroy(gameObject);
		}

		//Musuh gerak
		/*Range = Vector2.Distance(Enemy.transform.position, Player.transform.position);
		if (Range <= 15f) {
			transform.Translate (Vector2.MoveTowards (Enemy.transform.position, Player.transform.position, Range) * Speed * Time.deltaTime);
		}*/

		//------------------Enemy Move------------------------------------------------------------------
		//Use this position to cast the isGrounded/isBlocked lines from
		Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
		//Check to see if there's ground in front of us before moving forward
		//NOTE: Unity 4.6 and below use "- Vector2.up" instead of "+ Vector2.down"
		Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
		bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
		//Check to see if there's a wall in front of us before moving forward
		Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2() * .3f);
		bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * .3f, enemyMask);

		Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2() * .5f);
		bool isPlayer = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * .5f, deteksiplayer);

		//If theres no ground, turn around. Or if I hit a wall, turn around
		if(!isGrounded || isBlocked)
		{
			Vector3 currRot = myTrans.eulerAngles;
			currRot.y += 180;
			myTrans.eulerAngles = currRot;
		}

		//Always move forward


		//if there is player
		if (isPlayer) {
			Debug.Log ("Tersentuh player");
			Rest();
			anim.SetBool ("serang", true);
			
		} else if(!isPlayer) {
			anim.SetBool ("serang", false);
			MoveToPlayer();
		}


		//------------------End Enemy Move------------------------------------------------------------------
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.transform.tag == "Pedang") {
			nyawaMusuh--;
		} else if (other.transform.tag == "Player") {
			KomponenGerak.nyawa--;
		}
	}

	public void MoveToPlayer ()
	{
		Vector2 myVel = myBody.velocity;
		myVel.x = -myTrans.right.x * speed;
		myBody.velocity = myVel;
	}

	public void Rest ()
	{
		Vector2 myVel = myBody.velocity;
		myVel.x = 0;
		myBody.velocity = myVel;
	}
}
