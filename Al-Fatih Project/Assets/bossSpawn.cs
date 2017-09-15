using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossSpawn : MonoBehaviour {

	bool activated = false;

	public Slider enemySlider;

	public GameObject audioGM;

	AudioSource audioBGBoss;

	public AudioClip FileAudioBGBoss;

	// Use this for initialization
	void Start () {
		audioBGBoss = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			audioGM.GetComponent<AudioSource> ().Pause ();
			audioGM.GetComponent<AudioSource> ().clip = FileAudioBGBoss;
			audioGM.GetComponent<AudioSource> ().Play ();
			/*audioBGBoss.clip = FileAudioBGBoss;
			audioBGBoss.Play ();*/
			//AudioSource.PlayClipAtPoint (FileAudioBGBoss, transform.position);

			enemySlider.gameObject.SetActive (true);
			Destroy(gameObject);
		}
	}
}
