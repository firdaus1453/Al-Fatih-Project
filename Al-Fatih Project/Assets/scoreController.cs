using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour {

	int Score;

	//UI Score Variable
	public Text txtScore;
	public Text txtScoreWin;
	// Use this for initialization
	void Start () {
		//txtScore = GameObject.Find ("txtScore").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void addScore(int scoreAmount){
		Score += scoreAmount;
		txtScore.text = Score.ToString();
		txtScoreWin.text = Score.ToString();
	}
}
