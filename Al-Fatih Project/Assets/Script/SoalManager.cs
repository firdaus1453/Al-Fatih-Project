using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class SoalManager : MonoBehaviour {
	//Mengambil komponen class/script gerak
	public GameObject pl;
	gerak sr;
	swordHit jr;

	//Animasi
	public Animator anim2,anim3;

	//Soal
	public Question[] questions;
	public static List<Question> unansweredQuestions;
	public GameObject[] tempQ;
	public int qN,i = 0;
	//-----------off
	public Question currentQuestion;

	[SerializeField]
	public GameObject soalText;
	public GameObject soalText2;

	[SerializeField]
	private float timeBetweenQuestions = 1f;

	public GameObject[] t;
	float po;
	float pa;

	//Panah penunjuk soal
	public GameObject[] panah;

	//Penunjuk benar salah
	public GameObject benar;

	//Variabel Jurus
	public int correctCount;
	bool jurusON = false;
	public GameObject btnJurus;
	public float delayUsingJurus;

	// Use this for initialization
	void Start () {
		jr = GameObject.Find("Player").GetComponentInChildren<swordHit> ();
		//Memasukkan class gerak ke dalam pl dan mencari nama object yang ingin diambil

		//Soal
		//if (unansweredQuestions == null || unansweredQuestions.Count == 0){
		//tempQ = GameObject.FindGameObjectsWithTag("Soal");
		unansweredQuestions = questions.ToList<Question>();
		//}
		SetCurrentQuestion();
		//Debug.Log (currentQuestion.soal + " adalah " + currentQuestion.jawaban);

		//Animator
		//anim3 = GameObject.FindWithTag("Player").GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
	}

	//Soal
	public void SetCurrentQuestion(){
		//int randomQuestionIndex = Random.Range (0, unansweredQuestions.Count);
		//int randomQuestionIndex2 = Random.Range (1, unansweredQuestions.Count);
		//currentQuestion = unansweredQuestions [randomQuestionIndex];
		//currentQuestion2 = unansweredQuestions [randomQuestionIndex2];


		panah[qN].SetActive (true);
		//soalText.gameObject = currentQuestion.soal;
		for(int i = 0;i < unansweredQuestions.Count;i++){
			//unansweredQuestions = questions.ToList<Question>();
			int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
			currentQuestion = unansweredQuestions[randomQuestionIndex];
			tempQ[i] = currentQuestion.soal;
			po = soalText.transform.position.x-0.2f*-1*2+i+i*0.4f;
			pa = soalText.transform.position.y;
			t[i] = Instantiate(currentQuestion.soal,new Vector3 (po,pa,0), soalText.transform.rotation) as GameObject; //-1.5f*2+i+i*0.4f,3.40f,0
			t[i].transform.parent=transform;
			/*Vector3 posisiSoal = t[i].transform.position;
			Debug.Log (posisiSoal);*/
			anim2 = t[i].gameObject.GetComponent<Animator>();
		}
		//t = Instantiate(currentQuestion.soal, soalText.transform.position, soalText.transform.rotation);
		//t.transform.parent=transform;

		//t2 = Instantiate(currentQuestion2.soal, soalText2.transform.position, soalText2.transform.rotation);
		//t2.transform.parent=transform;

	}

	/* IEnumerator TransitionToNextQuestion(){
		unansweredQuestions.Remove(currentQuestion);

		yield return new WaitForSeconds (timeBetweenQuestions);
		SetCurrentQuestion ();

	}*/

	public void TransitionToNextQuestion(){
		//unansweredQuestions.Remove(currentQuestion);

		//unansweredQuestions = questions.ToList<Question>();

		//yield return new WaitForSeconds (timeBetweenQuestions);
		//SetCurrentQuestion ();
		//Destroy(t[qN]);
		qN += 1;

		if (qN == tempQ.Length) {
			
			if (correctCount == tempQ.Length) {
				jurusON = true;
				btnJurus.SetActive (true);
				Debug.Log ("Jurus on? = " + jurusON);
			} 
			Invoke ("hapusSoal", 0.1f);
			//hapusSoal();
			qN = 0;
			//panah[qN].SetActive (true);
		}
		panah[qN].SetActive (true);
		//Debug.Log (currentQuestion.soal + " adalah " + currentQuestion.jawaban);
	}

	public void hapusSoal(){
		correctCount = 0;

		GameObject[] soalt = GameObject.FindGameObjectsWithTag("Soal");
		foreach(GameObject soalg in soalt)
		Destroy(soalg);
		SetCurrentQuestion ();
	}

	public void clickedJurus(){
		Debug.Log ("Menjalankan jurus, BOOOM!!");
		//anim3.SetTrigger ("serang");
		sr = GameObject.Find("Player").GetComponent<gerak> ();
		sr.tombolJurus= true;
		jr.weaponDamage = 30;

		Invoke("unClickedJurus",delayUsingJurus);
		jurusON = false;
		btnJurus.SetActive (false);
		Debug.Log ("Jurus mati? = " + jurusON);
	}

	public void unClickedJurus(){
		sr = GameObject.Find("Player").GetComponent<gerak> ();
		sr.tombolJurus= false;
		jr.weaponDamage = 10;
	}

}
