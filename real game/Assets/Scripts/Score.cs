using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Score : MonoBehaviour {

	public static Score Instance; 
	public Text scoreCounter; 

	public int score; 

	void Awake ()
	{
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);

			Instance = this; 
		} else if (Instance != this) {
			Destroy (gameObject); 
		}
	}

	public void IncreaseScore (int points) {
		score = score + points;
		scoreCounter.text = "Score: " + score;
	}
}
