using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text>().text = "Highscore: " + LoadScore();
	}

	private int LoadScore(){
		if (PlayerPrefs.HasKey ("Highscore"))
			return PlayerPrefs.GetInt ("Highscore");
		else
			return 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
