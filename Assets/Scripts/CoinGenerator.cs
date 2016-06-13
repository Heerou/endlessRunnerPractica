using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

	//Piscina de coins
	public ObjectPool coinPool;

	//Distancia entre las monedas
	public float distanceBetweenCoins;

	//Metodo que genera las coins, en este caso, genera 3 a la vez y la coloca en una posicion en el Vector3
	public void SpawnCoins(Vector3 startPosition){

		//Objeto coin1 generada con ayuda del object pool y seteada con la posicion inicial
		GameObject coin1 = coinPool.GetPooledGameObject ();
		coin1.transform.position = startPosition;
		coin1.SetActive (true);

		GameObject coin2 = coinPool.GetPooledGameObject ();
		coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
		coin2.SetActive (true);

		GameObject coin3 = coinPool.GetPooledGameObject ();
		coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
		coin3.SetActive (true);
	}
}
