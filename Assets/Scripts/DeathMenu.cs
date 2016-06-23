using UnityEngine;
using System.Collections;

public class DeathMenu : MonoBehaviour {

	public string mainMenuLevel;

	//Funcion asociada al boton para reiniciar el juego, hace referencia a la funcion Reset
	public void restartGame(){

		FindObjectOfType<GameManager> ().Reset ();
	}

	//Sale al menu principal
	public void quitToMainMenu(){

		Application.LoadLevel (mainMenuLevel);
	}
}
