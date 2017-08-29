using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour
{
	public BoxCollider2D territory;

	//deteksi tanah
	public bool tanah;
	public LayerMask targetlayer;
	public Transform deteksitanah;
	public float jangkauan;

	GameObject player;
	bool playerInTerritory;

	public GameObject enemy;
	enemy basicenemy;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		basicenemy = enemy.GetComponent <enemy> ();
		playerInTerritory = false;
	}

	// Update is called once per frame
	void Update ()
	{
		tanah = Physics2D.OverlapCircle (deteksitanah.position, jangkauan, targetlayer);


		if (playerInTerritory == true)
		{
			Debug.Log ("Player berada di area");
			basicenemy.MoveToPlayer ();
		}

		if (playerInTerritory == false)
		{
			Debug.Log ("Player di luar area");
			basicenemy.Rest ();
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject == player)
		{
			playerInTerritory = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject == player) 
		{
			playerInTerritory = false;
		}
	}
}
