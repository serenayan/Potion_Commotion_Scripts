using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class Config : MonoBehaviour 
{
	// A configuration file
	public static bool inDebugMode = true;

	public static int curScore;
	public static int highScore;

	void Start()
	{
		highScore = PlayerPrefs.GetInt ("Highscore");
	}

	public static bool IsHand(Collider other)
	{
		if (other.transform.parent && other.transform.parent.GetComponent<HandModel>())
			return true;
		else
			return false;
	}

	public static void endGame()
	{
		if(curScore > highScore)
		{
			highScore = curScore;
		}

		PlayerPrefs.SetInt ("Highscore", highScore);
	}
}
