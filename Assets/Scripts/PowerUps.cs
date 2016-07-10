using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	//PowerUps
	public bool doublePoints;
	public bool safeMode;

	//Tiempo del power up
	public float powerUpLenght;


	private PowerUpManager thePowerUpManager;
	// Use this for initialization
	void Start () {

		thePowerUpManager = FindObjectOfType<PowerUpManager> ();
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
