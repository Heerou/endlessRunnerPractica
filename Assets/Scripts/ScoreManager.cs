using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	//Referencias a los textos en el UI
	public Text scoreText;
	public Text hiScoreText;

	//Contadores
	public float scoreCount;
	public float hiScoreCount;

	//Puntos por segundo
	public float pointPerSecond;

	//Aumentador de puntaje
	public bool scoreIncreasing;

	// Use this for initialization
	void Start () {

		//De esta forma se guarda el highsocre al momento de reiniciar el juego
		if(PlayerPrefs.HasKey("HighScore") ){
			hiScoreCount = PlayerPrefs.GetFloat ("HighScore");
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		//si es true aumenta, sino de malas
		if(scoreIncreasing){
			
			//De esta forma se sumara el puntaje
			scoreCount += pointPerSecond * Time.deltaTime;
		}

		//Si es mayor cambia
		if(scoreCount > hiScoreCount){

			hiScoreCount = scoreCount;
			//Pequela forma de guardar el puntaje maximo
			PlayerPrefs.SetFloat ("HighScore", hiScoreCount);
		}

		//Se setea a los textos. Formato de los numeros Mathf.Round()
		scoreText.text = "Score: " + Mathf.Round(scoreCount);
		hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);
	
	}
}
