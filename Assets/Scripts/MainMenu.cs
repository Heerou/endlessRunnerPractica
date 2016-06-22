using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//String que tendra el nombre del nombre del nivel
	public string playGameLevel;

	//Abre otra escena
	public void playGame(){

		Application.LoadLevel (playGameLevel);
	}

	//Cerrar el juego
	public void quitGame(){

		Application.Quit();		
	}
}
