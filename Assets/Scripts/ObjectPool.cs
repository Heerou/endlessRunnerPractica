﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

	public GameObject pooledObject;

	public int pooledAmount;

	List<GameObject> pooledObjects;

	// Use this for initialization
	void Start () {

		pooledObjects = new List<GameObject>();

		for(int i = 0; i < pooledAmount; i++){

			//Hace una piscina decimal objetos
			GameObject obj = (GameObject)Instantiate (pooledObject);
			obj.SetActive (false);
			pooledObjects.Add (obj);
		}
	
	}
	
	public GameObject GetPooledGameObject(){

		//Retornando los objetos, para guardar la memoria, los mismo que el instantiate
		for(int i = 0; i < pooledObjects.Count; i++){

			if(!pooledObjects[i].activeInHierarchy){

				return pooledObjects [i];
			}
		}

		GameObject obj = (GameObject)Instantiate (pooledObject);
		obj.SetActive (false);
		pooledObjects.Add (obj);
		return obj;
	}
}
