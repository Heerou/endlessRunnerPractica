using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;

	public GameObject pauseMenu;

	//Pausar juego
	public void pauseGame(){

		//Detiene el tiempo
		Time.timeScale = 0f;
		pauseMenu.SetActive(true);
	}

	//resumir juego
	public void resumeGame(){

		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
	}

	//Funcion asociada al boton para reiniciar el juego, hace referencia a la funcion Reset
	public void restartGame(){

		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
		FindObjectOfType<GameManager> ().Reset ();
	}

	//Sale al menu principal
	//Cuando se carga un nivel primero se debe colocar el tiempo como estaba sino, el tiempo se quedara congelado
	public void quitToMainMenu(){

		Time.timeScale = 1f;
		Application.LoadLevel (mainMenuLevel);
	}
}
