using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bintangStage : MonoBehaviour {

	public GameObject backGroundBintang1,bintang1Stage1,bintang2Stage1,bintang3Stage1;
	public GameObject btnStage2,backGroundBintang2, bintang1Stage2, bintang2Stage2, bintang3Stage2;
	public GameObject btnStage3,backGroundBintang3, bintang1Stage3, bintang2Stage3, bintang3Stage3;
	public GameObject btnStage4,backGroundBintang4, bintang1Stage4, bintang2Stage4, bintang3Stage4;
	public GameObject btnStage5,backGroundBintang5, bintang1Stage5, bintang2Stage5, bintang3Stage5;
	scoreController sc;

	// Use this for initialization
	void Start () {
		sc = GameObject.Find("_GM").GetComponent<scoreController> ();
		//Debug.Log ("win stage = "+sc.winStage1);
		/*PlayerPrefs.DeleteKey ("winStage1");
		sc.winStage1 = 0;*/
	}
	
	// Update is called once per frame
	void Update () {
		if(sc.winStage1 == 1){
			backGroundBintang1.SetActive (true);
			btnStage2.SetActive (true);
			munculBintangStage1 ();
		}
		if(sc.winStage2 == 1){
			backGroundBintang2.SetActive (true);
			btnStage3.SetActive (true);
			munculBintangStage2 ();
		}
		if(sc.winStage3 == 1){
			backGroundBintang3.SetActive (true);
			btnStage4.SetActive (true);
			munculBintangStage3 ();
		}
		if(sc.winStage4 == 1){
			backGroundBintang4.SetActive (true);
			btnStage5.SetActive (true);
			munculBintangStage4 ();
		}
		if(sc.winStage5 == 1){
			backGroundBintang5.SetActive (true);
			//btnStage5.SetActive (true);
			munculBintangStage5 ();
		}
	}

	void munculBintangStage1 (){
		if (sc.starStage1 == 3) {
			bintang1Stage1.SetActive (true);
			bintang2Stage1.SetActive (true);
			bintang3Stage1.SetActive (true);
		} else if (sc.starStage1 == 2) {
			bintang1Stage1.SetActive (true);
			bintang2Stage1.SetActive (true);
			bintang3Stage1.SetActive (false);
		} else if (sc.starStage1 == 1) {
			bintang1Stage1.SetActive (true);
			bintang2Stage1.SetActive (false);
			bintang3Stage1.SetActive (false);
		}
	}

	void munculBintangStage2 (){
		if(sc.starStage2 == 3){
			bintang1Stage2.SetActive (true);
			bintang2Stage2.SetActive (true);
			bintang3Stage2.SetActive (true);
		}else if(sc.starStage2 == 2){
			bintang1Stage2.SetActive (true);
			bintang2Stage2.SetActive (true);
			bintang3Stage2.SetActive (false);
		}else if(sc.starStage2 == 1){
			bintang1Stage2.SetActive (true);
			bintang2Stage2.SetActive (false);
			bintang3Stage2.SetActive (false);
		}
	}

	void munculBintangStage3 (){
		if(sc.starStage3 == 3){
			bintang1Stage3.SetActive (true);
			bintang2Stage3.SetActive (true);
			bintang3Stage3.SetActive (true);
		}else if(sc.starStage3 == 2){
			bintang1Stage3.SetActive (true);
			bintang2Stage3.SetActive (true);
			bintang3Stage3.SetActive (false);
		}else if(sc.starStage2 == 1){
			bintang1Stage3.SetActive (true);
			bintang2Stage3.SetActive (false);
			bintang3Stage3.SetActive (false);
		}//Debug.Log ("star stage 3 = " +sc.starStage3);
	}

	void munculBintangStage4 (){
		if(sc.starStage4 == 3){
			bintang1Stage4.SetActive (true);
			bintang2Stage4.SetActive (true);
			bintang3Stage4.SetActive (true);
		}else if(sc.starStage4 == 2){
			bintang1Stage4.SetActive (true);
			bintang2Stage4.SetActive (true);
			bintang3Stage4.SetActive (false);
		}else if(sc.starStage4 == 1){
			bintang1Stage4.SetActive (true);
			bintang2Stage4.SetActive (false);
			bintang3Stage4.SetActive (false);
		}//Debug.Log ("star stage 3 = " +sc.starStage3);
	}

	void munculBintangStage5 (){
		if(sc.starStage5 == 3){
			bintang1Stage5.SetActive (true);
			bintang2Stage5.SetActive (true);
			bintang3Stage5.SetActive (true);
		}else if(sc.starStage5 == 2){
			bintang1Stage5.SetActive (true);
			bintang2Stage5.SetActive (true);
			bintang3Stage5.SetActive (false);
		}else if(sc.starStage5 == 1){
			bintang1Stage5.SetActive (true);
			bintang2Stage5.SetActive (false);
			bintang3Stage5.SetActive (false);
		}//Debug.Log ("star stage 3 = " +sc.starStage3);
	}
}
