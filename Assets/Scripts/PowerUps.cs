using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	//PowerUps
	public bool doublePoints;
	public bool safeMode;

	//Tiempo del power up
	public float powerUpLenght;


	private PowerUpManager thePowerUpManager;

	public Sprite[] powerUpSprites;

	// Use this for initialization
	void Start () {

		thePowerUpManager = FindObjectOfType<PowerUpManager> ();
	}

	void Awake(){

		int powerUpSelector = Random.Range (0, 2);

		//Casos para que sea escoga el powerup
		switch(powerUpSelector){
		case 0:
			doublePoints = true;
			break;
		case 1:
			safeMode = true;
			break;		
		}

		GetComponent<SpriteRenderer> ().sprite = powerUpSprites [powerUpSelector];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.name == "Player") {

			thePowerUpManager.ActivatePowerUp (doublePoints, safeMode, powerUpLenght);
		}

		gameObject.SetActive (false);
	}
}
