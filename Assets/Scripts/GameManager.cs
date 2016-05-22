using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform platFormGenerator;
	private Vector3 platFormStartPoint;

	public Player_Controller thePlayer;
	private Vector3 playerStartPoint;	

	private PlatformDestroyer[] platformList;

	// Use this for initialization
	void Start () {

		platFormStartPoint = platFormGenerator.position;
		playerStartPoint = thePlayer.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Corutina, para que se pueda usar en otras partes
	public void RestartGame(){

		StartCoroutine ("RestartGameCo");
	}

	public IEnumerator RestartGameCo(){

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
	}
}
