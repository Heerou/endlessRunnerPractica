using UnityEngine;
using System.Collections;

public class pickupPoints : MonoBehaviour {

	public int scoreToGive;

	//Referencia al scoreManager
	private ScoreManager theScocreManager;

	//sonido de monedas
	private AudioSource coinSource;

	// Use this for initialization
	void Start () {

		theScocreManager = FindObjectOfType<ScoreManager> ();
		//Busca el audio de las monedas
		coinSource = GameObject.Find ("CoinSound").GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.name == "Player"){

			theScocreManager.AddScore (scoreToGive);
			gameObject.SetActive (false);

			//Basicamente si el sonido se reproduce muchas veces, pues lo cancela y lo reinicia
			if (coinSource.isPlaying) {
				coinSource.Stop ();
				coinSource.Play ();
			}else{
				coinSource.Play ();
			}
		}
	}
}
