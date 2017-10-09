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

	//Get komponen PlayerHealth
	playerHealth thePlayerHealth;

	//Variable score
	public int enemyDead = 0;
	int starStage;
	int totalScore;

	spawnDoor theSpawnDoor;

	//Variable menteketsi stage keberadaan player
	bool beradaDiStage1,beradaDiStage2,beradaDiStage3,beradaDiStage4,beradaDiStage5;

	// Use this for initialization
	void Start () {
		theSpawnDoor = GameObject.Find ("winningConditions").GetComponent <spawnDoor> ();

		Time.timeScale = 1;
		thePlayerScore = GameObject.Find("_GM").GetComponent<scoreController> ();
		thePlayerHealth = GameObject.Find("Player").GetComponent <playerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (restartNow && resetTime <= Time.time) {
			Application.LoadLevel (Application.loadedLevel);
		}else if (restartNow && btnRestart) {
			Application.LoadLevel (Application.loadedLevel);
		}
		if ((GameObject.Find ("benteng") == null) || (theSpawnDoor.stage4 == true)){
			thePlayerHealth.winGame ();
			menjumlahkanScore ();

			//Memainkan audio menang
			audioGM.GetComponent<AudioSource> ().Pause ();
			audioGM.GetComponent<AudioSource> ().clip = winAudioBoss;
			audioGM.GetComponent<AudioSource> ().Play ();

			/*if (Application.loadedLevel == 2) {
				thePlayerScore.winStage1 = 1;
				beradaDiStage1 = true;
			}

			if (Application.loadedLevel == 3) {
				thePlayerScore.winStage2 = 1;
				beradaDiStage2 = true;
			}*/

			cekLokasiPlayer ();
			SaveWinStage ();
			Debug.Log ("wins stage = " +thePlayerScore.winStage1);

			Animator winGameAnimator = winGameUI.GetComponent<Animator> ();
			if (thePlayerScore.Score >= 200) {
					winGameAnimator.SetInteger ("winStar", 3);
					starStage = 3;
					SaveScoreStar3 ();
					SaveStar ();
					/*if (thePlayerScore.starStage1 <= 3) {
						thePlayerScore.starStage1 = starStage;
						SaveStar ();
					}*/
			} else if (thePlayerScore.Score < 200 && thePlayerScore.Score > 150) {
					winGameAnimator.SetInteger ("winStar", 2);
					starStage = 2;
					SaveScoreStar2 ();
					SaveStar ();
					/*if (thePlayerScore.starStage1 <= 2) {
						thePlayerScore.starStage1 = starStage;
						SaveStar ();
					}*/
			} else if (thePlayerScore.Score <= 150) {
					winGameAnimator.SetInteger ("winStar", 1);
					starStage = 1;
					SaveScoreStar1 ();
					SaveStar ();
					/*if (thePlayerScore.starStage1 < 1) {
						thePlayerScore.starStage1 = starStage;
						SaveStar ();
					}*/
				}
			}
	}

	void cekLokasiPlayer(){
		if (Application.loadedLevel == 2) {
			thePlayerScore.winStage1 = 1;
			beradaDiStage1 = true;
			Debug.Log ("berada di stage 1 = " + beradaDiStage1);
		}

		if (Application.loadedLevel == 3) {
			thePlayerScore.winStage2 = 1;
			beradaDiStage2 = true;
			Debug.Log ("berada di stage 2 = " + beradaDiStage2);
		}
		if (Application.loadedLevel == 4) {
			thePlayerScore.winStage3 = 1;
			beradaDiStage3 = true;
			Debug.Log ("berada di stage 3 = " + beradaDiStage3);
		}
		if (Application.loadedLevel == 5) {
			thePlayerScore.winStage4 = 1;
			beradaDiStage4 = true;
			Debug.Log ("berada di stage 4 = " + beradaDiStage4);
		}
		if (Application.loadedLevel == 6) {
			thePlayerScore.winStage5 = 1;
			beradaDiStage5 = true;
			Debug.Log ("berada di stage 5 = " + beradaDiStage5);
		}
	}

	void SaveScoreStar1(){
		if (beradaDiStage1 == true) {
			if (thePlayerScore.starStage1 <= 1) {
				thePlayerScore.starStage1 = starStage;
				Debug.Log ("dapat bintang = " + thePlayerScore.starStage1);
			}
		}

		if (beradaDiStage2 == true) {
			if (thePlayerScore.starStage2 <= 1) {
				thePlayerScore.starStage2 = starStage;
				Debug.Log ("dapat bintang = " + thePlayerScore.starStage2);
			}
		}
		if (beradaDiStage3 == true) {
			if (thePlayerScore.starStage3 <= 1) {
				thePlayerScore.starStage3 = starStage;
				Debug.Log ("dapat bintang = " + thePlayerScore.starStage3);
			}
		}
		if (beradaDiStage4 == true) {
			if (thePlayerScore.starStage4 <= 1) {
				thePlayerScore.starStage4 = starStage;
				Debug.Log ("dapat bintang = " + thePlayerScore.starStage4);
			}
		}
		if (beradaDiStage5 == true) {
			if (thePlayerScore.starStage5 <= 1) {
				thePlayerScore.starStage5 = starStage;
				Debug.Log ("dapat bintang = " + thePlayerScore.starStage5);
			}
		}
	}

	void SaveScoreStar2(){
		if (beradaDiStage1 == true) {
			if (thePlayerScore.starStage1 <= 2) {
				thePlayerScore.starStage1 = starStage;
				Debug.Log ("dapat bintang = " + thePlayerScore.starStage1);
			}
		}

		if (beradaDiStage2 == true) {
			if (thePlayerScore.starStage2 <= 2) {
				thePlayerScore.starStage2 = starStage;
				Debug.Log ("dapat bintang = " + thePlayerScore.starStage1);
			}
		}
		if (beradaDiStage3 == true) {
			if (thePlayerScore.starStage3 <= 2) {
				thePlayerScore.starStage3 = starStage;
				Debug.Log ("dapat bintang = " + thePlayerScore.starStage3);
			}
		}
		if (beradaDiStage4 == true) {
			if (thePlayerScore.starStage4 <= 2) {
				thePlayerScore.starStage4 = starStage;
				Debug.Log ("dapat bintang = " + thePlayerScore.starStage4);
			}
		}
		if (beradaDiStage5 == true) {
			if (thePlayerScore.starStage5 <= 2) {
				thePlayerScore.starStage5 = starStage;
				Debug.Log ("dapat bintang = " + thePlayerScore.starStage5);
			}
		}
	}

	void SaveScoreStar3(){
		if (beradaDiStage1 == true) {
			if (thePlayerScore.starStage1 <= 3) {
				thePlayerScore.starStage1 = starStage;
			}
		}

		if (beradaDiStage2 == true) {
			if (thePlayerScore.starStage2 <= 3) {
				thePlayerScore.starStage2 = starStage;
			}
		}
		if (beradaDiStage3 == true) {
			if (thePlayerScore.starStage3 <= 3) {
				thePlayerScore.starStage3 = starStage;
			}
		}
		if (beradaDiStage4 == true) {
			if (thePlayerScore.starStage4 <= 3) {
				thePlayerScore.starStage4 = starStage;
			}
		}
		if (beradaDiStage5 == true) {
			if (thePlayerScore.starStage5 <= 3) {
				thePlayerScore.starStage5 = starStage;
			}
		}
	}

	void SaveStar(){
		if (beradaDiStage1 == true) {
			PlayerPrefs.SetInt ("starStage1", thePlayerScore.starStage1);
		}
		if (beradaDiStage2 == true) {
			PlayerPrefs.SetInt ("starStage2", thePlayerScore.starStage2);
		}
		if (beradaDiStage3 == true) {
			PlayerPrefs.SetInt ("starStage3", thePlayerScore.starStage3);
		}
		if (beradaDiStage4 == true) {
			PlayerPrefs.SetInt ("starStage4", thePlayerScore.starStage4);
		}
		if (beradaDiStage5 == true) {
			PlayerPrefs.SetInt ("starStage5", thePlayerScore.starStage5);
		}
		//Debug.Log ("Jumlah Star = "+ thePlayerScore.starStage1);
	}
		
	void SaveWinStage(){
		if (beradaDiStage1 == true) {
			PlayerPrefs.SetInt ("winStage1", 1);
		}
		if (beradaDiStage2 == true) {
			PlayerPrefs.SetInt ("winStage2", 1);
		}
		if (beradaDiStage3 == true) {
			PlayerPrefs.SetInt ("winStage3", 1);
		}
		if (beradaDiStage4 == true) {
			PlayerPrefs.SetInt ("winStage4", 1);
		}
		if (beradaDiStage5 == true) {
			PlayerPrefs.SetInt ("winStage5", 1);
		}
	}

	void menjumlahkanScore(){
		thePlayerScore.addScore((int)thePlayerHealth.currentHealth);
		Debug.Log ("darah player = "+ thePlayerHealth.currentHealth);
		//totalScore = (int)thePlayerHealth.currentHealth + thePlayerScore.Score;
		//thePlayerScore.Score = totalScore;
		Debug.Log ("total score = "+ thePlayerScore.Score);

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
