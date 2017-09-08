using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

	gerak KomponenGerak;

	// Use this for initialization
	void Start () {
		KomponenGerak = GameObject.Find("Player").GetComponent<gerak>();

	}

	// Update is called once per frame
	void Update () {

	}

	/*void OnTriggerEnter2D (Collider2D other){
		if (other.transform.tag == "Player") {
			KomponenGerak.nyawa++;
			Destroy(gameObject);
		}
	}*/
}
