using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBond : MonoBehaviour {

	public GameObject penghalang;
	public Vector2 maxX;
	public Vector2 minX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			penghalang.SetActive (true);
			CameraFollow theCameraFollow = GameObject.Find ("Main Camera").GetComponent<CameraFollow> ();
			theCameraFollow.maxXAndY = maxX;
			theCameraFollow.minXAndY = minX;
			Destroy (gameObject);
		}
	}
}
