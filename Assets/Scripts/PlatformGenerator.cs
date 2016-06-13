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

	//public GameObject[] thePlatforms;
	private int platformSelector;

	//Piscina de objetos
	public ObjectPool[] theObjectPool;

	//altura de las plataformas
	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	//Generador de Coins
	private CoinGenerator theCoinGenerator;
	public float randomCoinThreshold;

	// Use this for initialization
	void Start () {
		//Asignacion del tamaño de las plataformas
		//platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;

		//Asignacion del tamaño de las plataformas
		platformWitdhs = new float[theObjectPool.Length];

		for(int i = 0; i < theObjectPool.Length; i++){

			//Distancia entre las columnas
			platformWitdhs[i] = theObjectPool[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}

		//Altura minima y maxima de las plataformas
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;			

		//Generador de monedas
		theCoinGenerator = FindObjectOfType<CoinGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			//Selecciona aleatoriamente la plataformas
			platformSelector = Random.Range (0, theObjectPool.Length);

			//Sigue la posicion y genera las nuevas plataformas
			//transform.position = new Vector3 (transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

			//Variacion de la altura
			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			//Determina que el heightChange no se pase del maximo o el minimo
			if(heightChange > maxHeight){

				heightChange = maxHeight;
			}else if(heightChange < minHeight){

				heightChange = minHeight;
			}

			//Distancia entre las plataformas en base del ancho de estas, se multiplica por la mitad, para no pasarse de verga
			transform.position = new Vector3 (transform.position.x + (platformWitdhs[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

			//Crear un objeto que ya existe
			//Instantiate (thePlatform, transform.position, transform.rotation);
			//Crea la serie de objetos usados con el array
			//Instantiate (thePlatforms[platformSelector], transform.position, transform.rotation);

			//Hace lo mismo que la instancia, pero de forma mas optima
			GameObject newPlatform = theObjectPool[platformSelector].GetPooledGameObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			if(Random.Range(0f, 100f) < randomCoinThreshold){
				theCoinGenerator.SpawnCoins (new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
			}

			//Distancia entre las plataformas en base del ancho de estas, se multiplica por la mitad, para no pasarse de verga
			transform.position = new Vector3 (transform.position.x + (platformWitdhs[platformSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);
		}
	}
}
