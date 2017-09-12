using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartGame : MonoBehaviour {

	public float restartTime;
	bool restartNow = false;
	bool btnRestart = false;
	float resetTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (restartNow && resetTime <= Time.time) {
			Application.LoadLevel (Application.loadedLevel);
		}else if (restartNow && btnRestart) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	public void restartTheGame(){
		restartNow = true;
		resetTime = Time.time + restartTime;
	}

	public void btnrestartTheGame(){
		btnRestart = true;
		restartNow = true;
	}

	public void winTheGame(){
		//backMapNow = true;
		//resetTime = Time.time + restartTime;
	}
}
