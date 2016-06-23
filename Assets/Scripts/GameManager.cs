using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform platFormGenerator;
	private Vector3 platFormStartPoint;

	public Player_Controller thePlayer;
	private Vector3 playerStartPoint;	

	private PlatformDestroyer[] platformList;

	//Referencia al ScoreManager
	private ScoreManager theScoreManager;

	//Referencia al main menu
	public DeathMenu theDeathScreen;

	// Use this for initialization
	void Start () {

		platFormStartPoint = platFormGenerator.position;
		playerStartPoint = thePlayer.transform.position;

		theScoreManager = FindObjectOfType <ScoreManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Corutina, para que se pueda usar en otras partes
	public void RestartGame(){

		//Hacer que se reinicie el score
		theScoreManager.scoreIncreasing = false;

		//Hace invisible al player
		thePlayer.gameObject.SetActive (false);

		theDeathScreen.gameObject.SetActive (true);

		//StartCoroutine ("RestartGameCo");
	}

	//Reinicio del juego
	public void Reset(){

		//Desaparece la pantalla de "moriste" y aca reinicio el juego
		theDeathScreen.gameObject.SetActive (false);
		//Encuentra una lista de objetos con el tipo, este caso PlatformDestroyer
		platformList = FindObjectsOfType<PlatformDestroyer>();
		//Por cada objeto que, lo desactiva
		for(int i = 0; i < platformList.Length; i++){

			platformList [i].gameObject.SetActive (false);
		}

		thePlayer.transform.position = playerStartPoint;
		platFormGenerator.position = platFormStartPoint;
		//Hace visible al player
		thePlayer.gameObject.SetActive (true);		

		//Aca reincio el contador
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	
	}

	/*public IEnumerator RestartGameCo(){

		//Hacer que se reinicie el score
		theScoreManager.scoreIncreasing = false;

		//Hace invisible al player
		thePlayer.gameObject.SetActive (false);

		//Delay en el inicio de la corutina
		yield return new WaitForSeconds (0.5f);

		//Encuentra una lista de objetos con el tipo, este caso PlatformDestroyer
		platformList = FindObjectsOfType<PlatformDestroyer>();
		//Por cada objeto que, lo desactiva
		for(int i = 0; i < platformList.Length; i++){

			platformList [i].gameObject.SetActive (false);
		}

		thePlayer.transform.position = playerStartPoint;
		platFormGenerator.position = platFormStartPoint;
		//Hace visible al player
		thePlayer.gameObject.SetActive (true);		

		//Aca reincio el contador
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}*/
}
