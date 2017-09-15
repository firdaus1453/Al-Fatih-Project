using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

	public float fullHealth;
	public GameObject deathFX;
	public AudioClip playerHurt;

	//restart game
	public restartGame theGameManager;

	float currentHealth;

	playerController controlMovement;

	//sound player death
	public AudioClip playerDeathSound;

	//Variabel Audio
	AudioSource playerAS;

	//HUD Variables
	public Slider healthSlider;
	//public Text gameOverScreen;
	//public Text winGameScreen;
	public GameObject winGameUI;

	//Damage screen
	public Image damageScreen;
	bool damaged = false;
	Color damagedColour = new Color(0f,0f,0f,0.5f);
	float smoothColour = 5f;

	//UI Death
	public GameObject playerDeathUI;
	//Score Death
	public Text txtScoreDeath;
	//Unactive puase button
	public GameObject pauseBtn;

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		controlMovement = GetComponent<playerController> ();

		//HUD Initialization
		healthSlider.maxValue=fullHealth;
		healthSlider.value = fullHealth;

		damaged = false;

		playerAS = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (damaged) {
			damageScreen.color = damagedColour;
		} else {
			damageScreen.color = Color.Lerp (damageScreen.color, Color.clear, smoothColour*Time.deltaTime);
		}damaged = false;
	}

	public void addDamage(float damage){
		if (damage<= 0) return;
		currentHealth -= damage;

		//playerAS.clip = playerHurt;
		playerAS.PlayOneShot (playerHurt);
		//playerAS.Play ();

		healthSlider.value = currentHealth;
		damaged = true;

		if (currentHealth <= 0) {
			makeDead ();
		}
	}

	public void addHealth(float healthAmount){
		currentHealth += healthAmount;
		if (currentHealth > fullHealth) currentHealth=fullHealth;
		healthSlider.value = currentHealth;
	}

	public void makeDead(){
		Instantiate (deathFX, transform.position, transform.rotation);
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint (playerDeathSound, transform.position);
		damageScreen.color = damagedColour;
		pauseBtn.SetActive(false);
		scoreController thePlayerScore = GameObject.Find("_GM").GetComponent<scoreController> ();
		txtScoreDeath.text = thePlayerScore.Score.ToString();
		Animator gameOverAnimator = playerDeathUI.GetComponent<Animator> ();
		gameOverAnimator.SetTrigger ("gameOver");
		//theGameManager.restartTheGame ();
	}

	public void winGame(){
		pauseBtn.SetActive(false);
		Destroy (gameObject);
		//playerwinui.SetActive (true);
		//theGameManager.winTheGame();
		//scoreController thePlayerScore = GameObject.Find("_GM").GetComponent<scoreController> ();
		Animator winGameAnimator = winGameUI.GetComponent<Animator> ();
		winGameAnimator.SetTrigger ("gameOver");
		/*if (thePlayerScore.Score >= 80) {
			winGameAnimator.SetInteger ("winStar", 3);
			}else if (thePlayerScore.Score < 80 && thePlayerScore.Score > 30 ) {
					winGameAnimator.SetInteger ("winStar",2);
				}else if (thePlayerScore.Score <= 30) {
					winGameAnimator.SetInteger ("winStar",1);
					}*/
	}
}

