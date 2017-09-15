using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartGame : MonoBehaviour {

	public float restartTime;
	bool restartNow = false;
	bool btnRestart = false;
	float resetTime;

	//Variabel Audio GM
	public GameObject audioGM;
	public bool bossDeath = false; 

	public AudioClip winAudioBoss;

	//Get komponen scoreController
	scoreController thePlayerScore;
	public GameObject winGameUI;

	//Variable score
	public int enemyDead = 0;
	int starStage1;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		thePlayerScore = GameObject.Find("_GM").GetComponent<scoreController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (restartNow && resetTime <= Time.time) {
			Application.LoadLevel (Application.loadedLevel);
		}else if (restartNow && btnRestart) {
			Application.LoadLevel (Application.loadedLevel);
		}
		if (GameObject.Find ("benteng") == null) {
			playerHealth playerWins = GameObject.Find("Player").GetComponent <playerHealth> ();
			playerWins.winGame ();

			audioGM.GetComponent<AudioSource> ().Pause ();
			audioGM.GetComponent<AudioSource> ().clip = winAudioBoss;
			audioGM.GetComponent<AudioSource> ().Play ();

			thePlayerScore.winStage1 = 1;
			SaveWinStage ();
			Debug.Log (thePlayerScore.winStage1);

			Animator winGameAnimator = winGameUI.GetComponent<Animator> ();
				if (thePlayerScore.Score >= 80) {
					winGameAnimator.SetInteger ("winStar", 3);
					starStage1 = 3;
					if (thePlayerScore.starStage1 <= 3) {
						thePlayerScore.starStage1 = starStage1;
						SaveStar ();
					}
				} else if (thePlayerScore.Score < 80 && thePlayerScore.Score > 50) {
					winGameAnimator.SetInteger ("winStar", 2);
					starStage1 = 2;
					if (thePlayerScore.starStage1 <= 2) {
						thePlayerScore.starStage1 = starStage1;
						SaveStar ();
					}
				} else if (thePlayerScore.Score <= 50) {
					winGameAnimator.SetInteger ("winStar", 1);
					starStage1 = 1;
					if (thePlayerScore.starStage1 < 1) {
						thePlayerScore.starStage1 = starStage1;
						SaveStar ();
					}
				}
			}
	}

	void SaveStar(){
		PlayerPrefs.SetInt ("starStage1", thePlayerScore.starStage1);
		//Debug.Log ("Jumlah Star = "+ thePlayerScore.starStage1);
	}

	void SaveWinStage(){
		PlayerPrefs.SetInt ("winStage1", 1);
	}

	public void restartTheGame(){
		restartNow = true;
		resetTime = Time.time + restartTime;

	}

	public void btnrestartTheGame(){
		//Time.timeScale = 1;
		btnRestart = true;
		restartNow = true;
	}

	public void winTheGame(){
		//backMapNow = true;
		//resetTime = Time.time + restartTime;
	}
}
