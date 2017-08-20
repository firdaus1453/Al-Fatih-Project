using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class SoalManager : MonoBehaviour {
	//Animasi
	Animator anim2;

	//Serang

	//Soal
	public Question[] questions;
	public static List<Question> unansweredQuestions;
	public List<GameObject> tempQ;
	public int qN = 0;

	public Question currentQuestion;

	[SerializeField]
	public GameObject soalText;
	public GameObject soalText2;

	[SerializeField]
	private float timeBetweenQuestions = 1f;

	public GameObject t;
	float po;
	float pa;


	// Use this for initialization
	void Start () {
		//Soal
		//if (unansweredQuestions == null || unansweredQuestions.Count == 0){
		//tempQ = GameObject.FindGameObjectsWithTag("Soal");
		unansweredQuestions = questions.ToList<Question>();
		//}
		SetCurrentQuestion();
		Debug.Log (currentQuestion.soal + " adalah " + currentQuestion.jawaban);
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



		//soalText.gameObject = currentQuestion.soal;
		for(int i = 0;i < unansweredQuestions.Count;i++){
			//unansweredQuestions = questions.ToList<Question>();
			int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
			currentQuestion = unansweredQuestions[randomQuestionIndex];
			tempQ[i] = currentQuestion.soal;
			po = soalText.transform.position.x-0.2f*-1*2+i+i*0.4f;
			pa = soalText.transform.position.y;
			t = Instantiate(currentQuestion.soal,new Vector3 (po,pa,0), soalText.transform.rotation); //-1.5f*2+i+i*0.4f,3.40f,0
			t.transform.parent=transform;
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
		qN += 1;
		if (qN == tempQ.Count) {	
			hapusSoal();
			qN = 0;
		}
		//Destroy.(tmpQ[qN]);
		Debug.Log (currentQuestion.soal + " adalah " + currentQuestion.jawaban);
	}

	public void hapusSoal(){
		GameObject[] soalt = GameObject.FindGameObjectsWithTag("Soal");
		foreach(GameObject soalg in soalt)
			Destroy(soalg);
		SetCurrentQuestion ();
	}
}
