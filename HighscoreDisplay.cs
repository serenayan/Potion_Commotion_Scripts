using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreDisplay : MonoBehaviour 
{
	// Displays the highscore

	[SerializeField] private Text highscoreText;

	void Start()
	{
		highscoreText.text = PlayerPrefs.GetInt ("Highscore").ToString () + " potions made before dying!";
	}
}
