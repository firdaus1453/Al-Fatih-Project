using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallToWater : MonoBehaviour {

	public Transform locationSpawn;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//locationSpawn = GameObject.Find ("spawnPlayer").GetComponent<Vector2> ();
			playerHealth playerFell = other.GetComponent<playerHealth> ();
			playerFell.addDamage (15);

			other.transform.position = locationSpawn.position;
			//playerFell.makeDead ();

		} else
			Destroy (other.gameObject);
	}
}
