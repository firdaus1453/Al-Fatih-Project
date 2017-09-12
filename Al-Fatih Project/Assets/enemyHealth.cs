using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {

	public float enemyMaxHealth;

	public GameObject enemyDeathFX;
	public Slider enemySlider;

	public bool drops;
	public GameObject theDrop;

	public int enemyScore;

	//Sound death enemy
	public AudioClip deathKnell;

	float currentHealth;
	//int enemyDead; 

	// Use this for initialization
	void Start () {
		currentHealth = enemyMaxHealth;
		enemySlider.maxValue = currentHealth;
		enemySlider.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void addDamage(float damage){
		enemySlider.gameObject.SetActive (true);
		currentHealth -= damage;
		enemySlider.value = currentHealth;
		if (currentHealth <= 0) {
			addScore ();
			makeDead ();
		}
	}

	void makeDead(){
		
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint (deathKnell, transform.position);
		Instantiate (enemyDeathFX, transform.position, transform.rotation);
		if(drops) Instantiate(theDrop, transform.position, transform.rotation);
	}

	void addScore(){
		scoreController thePlayerScore = GameObject.Find("_GM").GetComponent<scoreController> ();
		thePlayerScore.addScore(enemyScore);
	}
}
