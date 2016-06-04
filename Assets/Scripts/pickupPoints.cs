using UnityEngine;
using System.Collections;

public class pickupPoints : MonoBehaviour {

	public int scoreToGive;

	//Referencia al scoreManager
	private ScoreManager theScocreManager;

	// Use this for initialization
	void Start () {

		theScocreManager = FindObjectOfType<ScoreManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.name == "Player"){

			theScocreManager.AddScore (scoreToGive);
			gameObject.SetActive (false);
		}
	}
}
