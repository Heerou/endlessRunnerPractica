using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Player_Controller thePlayer;

	private Vector3 lastPlayerPosition;
	private float distanceToMove;

	// Use this for initialization
	void Start () {
		//Movimiento del jugador
		thePlayer = FindObjectOfType<Player_Controller> ();
		//La ultima posicion del jugador
		lastPlayerPosition = thePlayer.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

		//Tomo la distancia que hay entre la primera posicione del jugador y la ultima
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
		//Transformo, la posicion de la camara
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);
		//La ultima posicion del jugador
		lastPlayerPosition = thePlayer.transform.position;
	}
}
