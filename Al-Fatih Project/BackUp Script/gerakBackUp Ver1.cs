using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class gerak : MonoBehaviour {

	Text infonyawa,infoscore,infonyawaM;
	// Use this for initialization

	public int kecepatan,kekuatanLompat;

	public bool balik;
	public int pindah;

	Rigidbody2D lompat;

	public bool tanah;
	public LayerMask targetlayer;
	public Transform deteksitanah;
	public float jangkauan;

	Animator anim;

	public int nyawa;
	public int koin;

	//Serang
	SoalManager KomponenSoal;

	enemy KomponenEnemy;
	Vector2 mulai;
	public bool ulang;
	public bool tombolKiri,tombolKanan,tombolSerang;

	//UI Menang Kalah
	public GameObject menang, kalah, restart, keluar;
	//UI Paket
	public GameObject gameui;
	public GameObject stopui;
	public GameObject player;

	//Soal
	/*public Question[] questions;
	private static List<Question> unansweredQuestions;
	private Question currentQuestion;

	[SerializeField]
	public GameObject soalText;*/

	void Start () {

		//Soal
		/*if (unansweredQuestions == null || unansweredQuestions.Count == 0){
			unansweredQuestions = questions.ToList<Question>();
		}

		SetCurrentQuestion();
		Debug.Log (currentQuestion.soal + " adalah " + currentQuestion.jawaban);*/

		KomponenSoal = GameObject.Find("Main Camera").GetComponent<SoalManager> ();
		//KomponenEnemy = GameObject.Find("MusuhKnight").GetComponent<enemy>();
		gameui.SetActive (true);
		//infonyawaM = GameObject.Find ("UInyawaM").GetComponent<Text> ();
		infoscore = GameObject.Find ("UIscore").GetComponent<Text> ();
		infonyawa = GameObject.Find ("UInyawa").GetComponent<Text> ();
		lompat = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
		mulai = transform.position;
		//sa.name = "a";


	}

	// Update is called once per frame
	void Update () {
		//infonyawaM.text = "Nyawa Musuh : " + KomponenEnemy.nyawaMusuh.ToString();
		infonyawa.text = "Nyawa : " + nyawa.ToString ();
		infoscore.text = "Score : " + koin.ToString ();

		if (ulang == true) {
			//Instantiate (player);
			transform.position = mulai;
			ulang = false;
		}

		if (nyawa <= 0) {
			//Kalah info
			kalah.SetActive (true);
			restart.SetActive (true);
			keluar.SetActive (true);
			gameui.SetActive (false);
			Destroy(player);
			//ulang = true;
		} else if (koin >= 30) {
			//Menang info
			menang.SetActive (true);
			gameui.SetActive (false);
			restart.SetActive (true);
			keluar.SetActive (true);
		}

		if (tanah == true) {
			anim.SetBool ("lompat", false);
		} else {
			anim.SetBool ("lompat", true);
		}

		tanah = Physics2D.OverlapCircle (deteksitanah.position, jangkauan, targetlayer);

		//Gerak kiri dan kanan
		if (Input.GetKey (KeyCode.D) || (tombolKanan==true)) {
			anim.SetBool("lari",true);
			transform.Translate (Vector2.right * kecepatan * Time.deltaTime);
			pindah = -1;
		} else if (Input.GetKey (KeyCode.A) || (tombolKiri==true)) {
			anim.SetBool("lari",true);
			transform.Translate (Vector2.right * -kecepatan * Time.deltaTime);
			pindah = 1;
		}else {
			anim.SetBool("lari",false);
		}	

		//Serang
		//if (tombolSerang == true) {
		/*foreach (string s in fa) {
				if ((tombolSerang == true) && (s == ta)) {
					anim.SetBool ("serang", true);
					//sa.SetActive (false);
					Debug.Log(s);
				} else if(tombolSerang == false) {
					anim.SetBool ("serang", false);
				}
			}*/
		//}
		if ((tombolSerang == true)) {
			anim.SetBool ("serang", true);
			//sa.SetActive (false);
		} else if(tombolSerang == false) {
			anim.SetBool ("serang", false);
		}




		if (pindah > 0 && !balik) {
			balikbadan ();
		} else if (pindah < 0 && balik) {
			balikbadan ();
		}
	}

	void balikbadan(){
		balik = !balik;
		Vector3 karakter = transform.localScale;
		karakter.x *= -1;
		transform.localScale = karakter;
	}

	public void tekankiri(){
		tombolKiri = true;
	}
	public void lepaskiri(){
		tombolKiri = false;
	}

	public void tekankanan(){
		tombolKanan= true;
	}
	public void lepaskanan(){
		tombolKanan= false;
	}

	//Lompat
	public void jump(){
		if (tanah == true) {
			lompat.AddForce(new Vector2(0,kekuatanLompat));
		}
	}

	//Serang
	/*public void tekanserang(){
		tombolSerang = true;
	}*/
	public void lepasserang(){
		tombolSerang = false;
	}

	public void oa(GameObject aa){
		Debug.Log (KomponenSoal.currentQuestion.jawaban + "dan " + aa);
		//GameObject ht = KomponenSoal.tempQ;

		if (KomponenSoal.tempQ[KomponenSoal.qN] == aa) {
			tombolSerang = true;
			Debug.Log ("CORRECT!");
			//StartCoroutine(KomponenSoal.TransitionToNextQuestion());
			KomponenSoal.TransitionToNextQuestion();

		} else {
			Debug.Log ("WRONG!");
			//StartCoroutine(KomponenSoal.TransitionToNextQuestion());
			KomponenSoal.TransitionToNextQuestion();
		}Debug.Log (KomponenSoal.currentQuestion.jawaban + "dan " + aa);

	}


	//Soal
	/*void SetCurrentQuestion(){
		int randomQuestionIndex = Random.Range (0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions [randomQuestionIndex];

		//soalText.gameObject = currentQuestion.soal;

		Transform t = Instantiate(currentQuestion.soal, soalText.transform.position, soalText.transform.rotation).transform;
		//t.parent = transform;
		t.transform.parent = transform;
		unansweredQuestions.RemoveAt(randomQuestionIndex);
	}*/

	//Jika pemain menajwab benar dan salah
	/*public void UserSelectTrue(){
		if (currentQuestion.jawaban) {
			Debug.Log ("CORRECT!");
		} else {
			Debug.Log ("WRONG!");
		}
	}

	public void UserSelectFalse(){
		if (!currentQuestion.jawaban) {
			Debug.Log ("CORRECT!");
		} else {
			Debug.Log ("WRONG!");
		}
	}*/

}
