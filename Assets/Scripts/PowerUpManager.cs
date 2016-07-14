using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour {

	//PowerUps
	private bool doublePoints;
	private bool safeMode;

	private bool powerUpActive;

	private float powerUpLenghtCounter;

	private ScoreManager theScoreManager;
	private PlatformGenerator thePlatformGenerator;

	private float normalPointsPerSecond;
	private float spikeRate;

	private PlatformDestroyer[] spikeList;

	private GameManager theGameManager;

	// Use this for initialization
	void Start () {

		theScoreManager = FindObjectOfType<ScoreManager> ();
		thePlatformGenerator = FindObjectOfType<PlatformGenerator> ();
		theGameManager = FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(powerUpActive){

			powerUpLenghtCounter -= Time.deltaTime;

			if(theGameManager.powerUpReset){
			
				powerUpLenghtCounter = 0;
				theGameManager.powerUpReset = false;
			}

			if(doublePoints){

				theScoreManager.pointPerSecond = normalPointsPerSecond * 2;
				theScoreManager.shouldDouble = true;
			}

			if(safeMode){

				thePlatformGenerator.randomSpikeThreshold = 0;
			}

			if(powerUpLenghtCounter <= 0){

				theScoreManager.pointPerSecond = normalPointsPerSecond;
				theScoreManager.shouldDouble = false;
				thePlatformGenerator.randomSpikeThreshold = spikeRate;

				powerUpActive = false;
			}
		}
	}

	//Metodo para activar el powerUp
	public void ActivatePowerUp(bool points, bool safe, float time){

		doublePoints = points;
		safeMode = safe;
		powerUpLenghtCounter = time;

		normalPointsPerSecond = theScoreManager.pointPerSecond;
		spikeRate = thePlatformGenerator.randomSpikeThreshold;

		//Cuando el saveMode es activado, desactiva las spikes
		if (safeMode) {
			spikeList = FindObjectsOfType<PlatformDestroyer> ();
			//Por cada objeto que, lo desactiva
			for (int i = 0; i < spikeList.Length; i++) {

				if (spikeList[i].gameObject.name.Contains("spikes")) {
					spikeList [i].gameObject.SetActive (false);
				}
			}
		}

		powerUpActive = true;
	}
}
