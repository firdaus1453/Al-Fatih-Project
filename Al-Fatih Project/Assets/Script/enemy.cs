using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	gerak KomponenGerak;
	public int nyawaMusuh;

	// Use this for initialization
	void Start () {
		KomponenGerak = GameObject.Find("Player").GetComponent<gerak>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (nyawaMusuh <= 0) {
			KomponenGerak.koin += 10;
			Destroy(gameObject);
		}
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.transform.tag == "Pedang") {
			nyawaMusuh--;
		} else if (other.transform.tag == "Player") {
			KomponenGerak.nyawa--;
		}
	}
}
