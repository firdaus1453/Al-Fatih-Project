using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cekstory : MonoBehaviour {
	public int sdhpernahmain;
	// Use this for initialization
	void Start () {
		sdhpernahmain = PlayerPrefs.GetInt ("newplayer");
	}

	// Update is called once per frame
	void Update () {

	}

	public void ketujuan(){
		if (sdhpernahmain < 1) {
			Application.LoadLevel (9);
			sdhpernahmain = 1;
			savepemainbaru ();
		} else {
			Application.LoadLevel (1);
			/*PlayerPrefs.DeleteKey ("newplayer");
			sdhpernahmain = 0;*/
		}
	}

	public void savepemainbaru(){
		PlayerPrefs.SetInt ("newplayer", sdhpernahmain);
		sdhpernahmain = PlayerPrefs.GetInt ("newplayer");
	}
}