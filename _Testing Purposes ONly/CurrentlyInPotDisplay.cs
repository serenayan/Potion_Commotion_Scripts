using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentlyInPotDisplay : MonoBehaviour
{
	// Debuging what is in the pot for the TAs

	[SerializeField] private GameObject ingredientCardPrefab;
	[SerializeField] private GameObject ingredientCardHub;

	public void updateRecipeUI(List<Ingredient> curIngredient)
	{
		foreach (Transform childTransform in ingredientCardHub.transform) Destroy(childTransform.gameObject);

		foreach(Ingredient I in curIngredient)
		{
			GameObject newCard = Instantiate (ingredientCardPrefab, ingredientCardHub.transform) as GameObject;
			// GameObject hub = newCard.GetComponentInChildren<GameObject> ();
			Text[] allCardText = newCard.GetComponentsInChildren<Text> ();
			foreach(Text t in allCardText)
			{
				if(t.name == "Ingredient Name")
				{
					t.text = I.type.ToString ();
					t.text = t.text.Replace ('_', ' ');
				}else if(t.name == "Ingredient Count")
				{
					t.text = "x" + I.count.ToString();
				}
			}
		}
	}
}
