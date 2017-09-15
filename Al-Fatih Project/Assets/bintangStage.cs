using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bintangStage : MonoBehaviour {

	public GameObject bg1,b1s1,b2s1,b3s1,st2;
	scoreController sc;

	// Use this for initialization
	void Start () {
		sc = GameObject.Find("_GM").GetComponent<scoreController> ();
		Debug.Log ("win stage = "+sc.winStage1);
		/*PlayerPrefs.DeleteKey ("winStage1");
		sc.winStage1 = 0;*/
	}
	
	// Update is called once per frame
	void Update () {
		if(sc.winStage1 == 1){
			st2.SetActive (true);
		if(sc.starStage1 == 3){
			bg1.SetActive (true);
			b1s1.SetActive (true);
			b2s1.SetActive (true);
			b3s1.SetActive (true);
		}else if(sc.starStage1 == 2){
			bg1.SetActive (true);
			b1s1.SetActive (true);
			b2s1.SetActive (true);
			b3s1.SetActive (false);
		}else if(sc.starStage1 == 1){
			bg1.SetActive (true);
			b1s1.SetActive (true);
			b2s1.SetActive (false);
			b3s1.SetActive (false);
		}
		}
	}
}
