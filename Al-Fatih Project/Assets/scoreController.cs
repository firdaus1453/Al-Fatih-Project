using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour {

	public int Score;
	public int starStage1;
	public int winStage1;
	//UI Score Variable
	public Text txtScore;
	public Text txtScoreWin,txtScoreDeath;
	// Use this for initialization
	void Start () {
		//txtScore = GameObject.Find ("txtScore").GetComponent<Text>();
		if (PlayerPrefs.HasKey ("starStage1")) {
			if (Application.loadedLevel == 0) {
				PlayerPrefs.DeleteKey ("starStage1");
				starStage1 = 0;
				Debug.Log (starStage1);
			} else {
				starStage1 = PlayerPrefs.GetInt ("starStage1");
				winStage1 = PlayerPrefs.GetInt ("winStage1");
				Debug.Log (starStage1);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void addScore(int scoreAmount){
		Score += scoreAmount;
		txtScore.text = Score.ToString();
		txtScoreWin.text = Score.ToString();
		//txtScoreWin.text = Score.ToString();
	}
}
