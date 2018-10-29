using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Recipes : MonoBehaviour
{
	// Handles the recipes and crap like that

	[SerializeField] private Recipe[] levelRecipes;
	[SerializeField] private List<Ingredient> inCauldon;

	[SerializeField] private Recipe currentRecipe;
	[SerializeField] private CurrentlyInPotDisplay CID;

	[SerializeField] private Text descriptionUIText;

	[SerializeField] private AudioClip winningSound;
	[SerializeField] private AudioClip losingSound;

	[SerializeField] private ParticleSystem winningThing;
	[SerializeField] private ParticleSystem losingThing;

	[SerializeField] private Timer t;

	private AudioSource audSource;

	private bool isEnabled = true;

	public void addToPot (IngredientInfo II)
	{
		bool found = false; 
		foreach (Ingredient i in inCauldon) {
			if (i.type == II.type) {
				i.count += II.amount;
				found = true;
			}
		}
		if (!found) {
			Ingredient newIngred = new Ingredient ();
			newIngred.count = II.amount;
			newIngred.type = II.type;
			inCauldon.Add (newIngred);
		}
		CID.updateRecipeUI (inCauldon);
	}

	void Start ()
	{
		audSource = GetComponent<AudioSource> ();
		getNewRecipe ();
	}

	bool isRecipe ()
	{
		bool[] isGoodToGo = new bool[currentRecipe.ingredients.Length];
		for (int i = 0; i < currentRecipe.ingredients.Length; i++) {
			bool containsIngred = false;
			foreach (Ingredient cauldronI in inCauldon) {
				if (cauldronI.type == currentRecipe.ingredients [i].type) {
					if (cauldronI.count >= currentRecipe.ingredients [i].count) {
						containsIngred = true;
					}
				}
			}
			if (containsIngred) {
				isGoodToGo [i] = true;
			}
		}

		bool allClear = true;
		for (int i = 0; i < currentRecipe.ingredients.Length; i++) {
			if (isGoodToGo [i] == false) {
				allClear = false;
			}
		}
		if (allClear) {
			return true;
		}
		return false;
	}

	public void finishRecipe ()
	{
		if (!isEnabled)
			return;
		if (isRecipe ()) {
			inCauldon.Clear ();
			CID.updateRecipeUI (inCauldon);
			getNewRecipe ();
			if (!audSource.isPlaying)
				audSource.PlayOneShot (winningSound);
			winningThing.Play ();
			Config.curScore++;
		} else {
			inCauldon.Clear ();
			CID.updateRecipeUI (inCauldon);
			if (!audSource.isPlaying)
				audSource.PlayOneShot (losingSound);
			losingThing.Play ();
			StartCoroutine (waitAndDIE ());
			Config.endGame ();
		}

	}

	void getNewRecipe ()
	{
		currentRecipe = levelRecipes [Random.Range (0, levelRecipes.Length)];
		if (t)
			t.time = currentRecipe.timeToMake;
		if (descriptionUIText)
			descriptionUIText.text = currentRecipe.descriptionText;
	}

	IEnumerator waitAndDIE ()
	{
		yield return new WaitForSeconds (4F);
		SceneManager.LoadScene ("Main Menu");
	}

	public void gameEnd ()
	{
		inCauldon.Clear ();
		if (!audSource.isPlaying)
			audSource.PlayOneShot (losingSound);

		losingThing.Play ();

		StartCoroutine (waitAndDIE ());
		Config.endGame ();
	}

	public void clearAll ()
	{
		inCauldon.Clear ();
	}

	IEnumerator waitForEnable ()
	{
		isEnabled = false;
		yield return new WaitForSeconds (10F);
		isEnabled = true;
	}
}

[System.Serializable]
public class Recipe
{
	public string name;
	public string descriptionText;
	public Ingredient[] ingredients;
	public int timeToMake;
}

[System.Serializable]
public class Ingredient
{
	public enum IngredientType
	{
		Frog_Legs,
		Snake_Venom,
		Dragon_Scales,
		Myrrh_Leaves,
		Saffron,
		Mermaid_Tears,
		Pig_Blood,
		Mercury,
		Coconut_Oil,
		Baby_Turtle_Shell,
		Unicorn_Horns,
		Devils_Whisper,
		Holy_Water
	}

	public IngredientType type;
	public int count;
}