using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseBtnScript : MonoBehaviour {

	bool pauseON;

	public GameObject pauseBtn, btnPause;

	// Use this for initialization
	void Start () {
		btnPause.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void pauseClicked(){
		btnPause.SetActive (false);
		pauseBtn.SetActive (true);
		Time.timeScale = 0;
	}

	public void pauseUnclicked(){
		btnPause.SetActive (true);
		pauseBtn.SetActive (false);
		Time.timeScale = 1;
	}
}
