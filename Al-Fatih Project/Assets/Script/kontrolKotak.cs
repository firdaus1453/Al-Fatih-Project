using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kontrolKotak : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			anim.SetBool ("kotakLompatOn", true);
		}else if(Input.GetKey(KeyCode.A)) {
			anim.SetBool ("kotakLompatOn", false);
		}
	}
}
