using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfGame : MonoBehaviour {

	private GameObject canvasToDestroy;

	// Use this for initialization
	void Start () {
		canvasToDestroy = GameObject.FindWithTag ("Destroy");
		GetComponent<Text>().text = "Highscore: " + DB.Database.getScore ();
		SaveHighscore(DB.Database.getScore());
	}

	public void BackToMainMenu () {
		DB.Database.DestroyDB();
		Destroy (canvasToDestroy);
		Application.LoadLevel (0);
	}
		
	private void SaveHighscore(int score){
		if (PlayerPrefs.HasKey ("Highscore")) {
			if (PlayerPrefs.GetInt ("Highscore") < score)
				PlayerPrefs.SetInt ("Highscore", score);
		} else 
			PlayerPrefs.SetInt ("Highscore", score);
	}
}
