using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayerS2 : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GameObject.Find ("kapalJalan").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			anim.SetBool ("kapal jalan", true);
		}
	}

}
