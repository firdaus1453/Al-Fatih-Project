using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void quitClicked(int yangdituju){
		Application.LoadLevel (yangdituju);
	}
}
