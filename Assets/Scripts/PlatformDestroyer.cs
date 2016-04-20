using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject platformDestructionPoint;

	// Use this for initialization
	void Start () {

		//Encuentra el gameobject que tenga ese nombre
		platformDestructionPoint = GameObject.Find ("PlatformDestructionPoint");
	
	}
	
	// Update is called once per frame
	void Update () {

		//Destruccion de la plataformas
		if(transform.position.x < platformDestructionPoint.transform.position.x){

			Destroy (gameObject);
		}
	
	}
}
