using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDoor : MonoBehaviour {

	bool activated = false;
	public Transform whereToSpawn;
	public GameObject door;

	/*
	//Get komponen scoreController
	scoreController thePlayerScore;
	public GameObject winGameUI;
	//Variable pendukung untuk data score
	public int enemyDead = 0;
	int starStage1;*/

	// Use this for initialization
	void Start () {
		//thePlayerScore = GameObject.Find("_GM").GetComponent<scoreController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && !activated && GameObject.Find("benteng") == null) {
			activated = true;
			Instantiate (door, whereToSpawn.position, Quaternion.identity);
			Destroy (gameObject);

			/*thePlayerScore.winStage1 = 1;
			SaveWinStage ();
			Debug.Log (thePlayerScore.winStage1);

			Animator winGameAnimator = winGameUI.GetComponent<Animator> ();
			if (thePlayerScore.Score >= 80){
				winGameAnimator.SetInteger ("winStar", 3);
				starStage1 = 3;
				if (thePlayerScore.starStage1 <= 3) {
					thePlayerScore.starStage1 = starStage1;
					SaveStar ();
				}
				}
				else if (thePlayerScore.Score < 80 && thePlayerScore.Score > 50  ){
					winGameAnimator.SetInteger ("winStar",2);
					starStage1 = 2;
						if (thePlayerScore.starStage1 <= 2) {
							thePlayerScore.starStage1 = starStage1;
							SaveStar();
						}
					}
					else if (thePlayerScore.Score <= 50) {
						winGameAnimator.SetInteger ("winStar",1);
						starStage1 = 1;
							if (thePlayerScore.starStage1 < 1) {
								thePlayerScore.starStage1 = starStage1;
								SaveStar();
							}
						}*/
		}
	}

	/*void SaveStar(){
		PlayerPrefs.SetInt ("starStage1", thePlayerScore.starStage1);
		//Debug.Log ("Jumlah Star = "+ thePlayerScore.starStage1);
	}

	void SaveWinStage(){
		PlayerPrefs.SetInt ("winStage1", 1);
	}*/
}
