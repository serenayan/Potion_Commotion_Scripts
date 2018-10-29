using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Leap.Unity;

public class RecipeDisplay : MonoBehaviour
{
	// Cycles through the images to show the recipes

	[SerializeField] private Sprite[] allRecipes;
	[SerializeField] private Image recipeDisplayImage;

	[SerializeField] private GameObject leftButton;

	[SerializeField] private float distanceAwayMin;

	[SerializeField] private float timeBetweenChecks;
	private LeapServiceProvider lsp;

	private bool leftButtonIncreaseRunning;
	private bool rightButtonIncreaseRunning;

	private int currentIndex;

	void Start ()
	{
		lsp = FindObjectOfType<LeapServiceProvider> ();
	}

	void Update ()
	{
		foreach (Leap.Hand h in lsp.CurrentFrame.Hands) {
			if (Vector3.Distance (h.PalmPosition.ToVector3 (), leftButton.transform.position) <= distanceAwayMin) {
				if (!leftButtonIncreaseRunning) {
					StartCoroutine (leftButtonIncrease ());
				}
			}
		}
	}

	IEnumerator leftButtonIncrease ()
	{
		leftButtonIncreaseRunning = true;

		increase ();

		yield return new WaitForSeconds (timeBetweenChecks);

		leftButtonIncreaseRunning = false;
	}

	void decrease ()
	{
		currentIndex--;
		clampIt ();
	}

	void increase ()
	{
		currentIndex++;
		clampIt ();
	}

	void clampIt ()
	{
		if (currentIndex < 0) {
			currentIndex = allRecipes.Length;
		}
		if (currentIndex >= allRecipes.Length) {
			currentIndex = 0;
		}

		recipeDisplayImage.sprite = allRecipes [currentIndex];
	}
}
