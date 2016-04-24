using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;
	private float[] platformWitdhs;

	private float platformWidth;

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	public GameObject[] thePlatforms;
	private int platformSelector;

	//Piscina de objetos
	//public ObjectPool theObjectPool;

	// Use this for initialization
	void Start () {
		//Asignacion del tamaño de las plataformas
		//platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;

		//Asignacion del tamaño de las plataformas
		platformWitdhs = new float[thePlatforms.Length];

		for(int i = 0; i < thePlatforms.Length; i++){

			//Distancia entre las columnas
			platformWitdhs[i] = thePlatforms[i].GetComponent<BoxCollider2D> ().size.x;
		}
			
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			//Selecciona aleatoriamente la plataformas
			platformSelector = Random.Range (0, thePlatforms.Length);

			//Sigue la posicion y genera las nuevas plataformas
			//transform.position = new Vector3 (transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
			//Distancia entre las plataformas en base del ancho de estas
			transform.position = new Vector3 (transform.position.x + platformWitdhs[platformSelector] + distanceBetween, transform.position.y, transform.position.z);

			//Crear un objeto que ya existe
			//Instantiate (thePlatform, transform.position, transform.rotation);
			//Crea la serie de objetos usados con el array
			Instantiate (thePlatforms[platformSelector], transform.position, transform.rotation);

			//Hace lo mismo que la instancia, pero de forma mas optima
			/*GameObject newPlatform = theObjectPool.GetPooledGameObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);*/

		}
	}
}
