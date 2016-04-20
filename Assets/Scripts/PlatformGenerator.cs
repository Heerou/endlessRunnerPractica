using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;

	private float platformWidth;

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	// Use this for initialization
	void Start () {
		//Asignacion del tamaño de las plataformas
		platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;
			
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			//Sigue la posicion y genera las nuevas plataformas
			transform.position = new Vector3 (transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

			//Crear un objeto que ya existe
			Instantiate (thePlatform, transform.position, transform.rotation);
			
		}
	}
}
