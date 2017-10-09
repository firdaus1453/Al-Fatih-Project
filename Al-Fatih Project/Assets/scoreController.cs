using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour {

	public int Score;
	public int starStage1;
	public int starStage2, winStage2;
	public int starStage3, winStage3;
	public int starStage4, winStage4;
	public int starStage5, winStage5;
	public int winStage1;

	//UI Score Variable
	public Text txtScore;
	public Text txtScoreWin,txtScoreDeath;

	// Use this for initialization
	void Start () {
		//txtScore = GameObject.Find ("txtScore").GetComponent<Text>();
		/*if (PlayerPrefs.HasKey ("starStage1")) {
			if (Application.loadedLevel == 0) {
				PlayerPrefs.DeleteKey ("starStage1");
				starStage1 = 0;
				Debug.Log (starStage1);
			} else {
				starStage1 = PlayerPrefs.GetInt ("starStage1");
				winStage1 = PlayerPrefs.GetInt ("winStage1");
				Debug.Log (starStage1);
			}
		}*/
		/*if (Application.loadedLevel == 0) {
			PlayerPrefs.DeleteKey ("starStage1");
			PlayerPrefs.DeleteKey ("winStage1");
			PlayerPrefs.DeleteKey ("starStage2");
			PlayerPrefs.DeleteKey ("winStage2");
			PlayerPrefs.DeleteKey ("starStage3");
			PlayerPrefs.DeleteKey ("winStage3");
			PlayerPrefs.DeleteKey ("starStage4");
			PlayerPrefs.DeleteKey ("winStage4");
			PlayerPrefs.DeleteKey ("starStage5");
			PlayerPrefs.DeleteKey ("winStage5");
			starStage1 = 0;
			winStage1 = 0;
			starStage2 = 0;
			winStage2 = 0;
			starStage3 = 0;
			winStage3 = 0;
			starStage4 = 0;
			winStage4 = 0;
			starStage5 = 0;
			winStage5 = 0;
		}*/
				starStage1 = PlayerPrefs.GetInt ("starStage1");
				winStage1 = PlayerPrefs.GetInt ("winStage1");
				Debug.Log ("Jmlah star stage 1 = " +starStage1);
				Debug.Log ("win stage 1 = " +winStage1);


				starStage2 = PlayerPrefs.GetInt ("starStage2");
				winStage2 = PlayerPrefs.GetInt ("winStage2");
				Debug.Log ("Jmlah star stage 2 = " +starStage2);
				Debug.Log ("win stage 2 = " +winStage2);

				starStage3 = PlayerPrefs.GetInt ("starStage3");
				winStage3 = PlayerPrefs.GetInt ("winStage3");
				Debug.Log ("Jmlah star stage 3 = " +starStage3);
				Debug.Log ("win stage 3 = " +winStage3);

				starStage4 = PlayerPrefs.GetInt ("starStage4");
				winStage4 = PlayerPrefs.GetInt ("winStage4");
				Debug.Log ("Jmlah star stage 4 = " +starStage4);
				Debug.Log ("win stage 4 = " +winStage4);

				starStage5 = PlayerPrefs.GetInt ("starStage5");
				winStage5 = PlayerPrefs.GetInt ("winStage5");
				Debug.Log ("Jmlah star stage 5 = " +starStage5);
				Debug.Log ("win stage 5 = " +winStage5);
	}
	
	// Update is called once per frame
	void Update () {
		//txtScore.text = Score.ToString();
		//txtScoreWin.text = Score.ToString();
	}
	
	public void addScore(int scoreAmount){
		Score += scoreAmount;
		txtScore.text = Score.ToString();
		txtScoreWin.text = Score.ToString();
		//txtScoreWin.text = Score.ToString();
	}
}
