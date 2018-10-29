using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleToPotion : MonoBehaviour {
	// Handles the particles when they collide with the pot's lid

	[SerializeField] private Recipes r;
	[SerializeField] private GameObject plusOne;

//	void OnParticleCollision(GameObject other)
//	{
//		Debug.Log(other.transform.parent.name);
//		if (other.transform.parent.tag == "Potion") {
//			IngredientInfo II = other.transform.parent.GetComponent<IngredientInfo> ();
//			r.addToPot (II);
//		}
//	}

	public void addToPot(IngredientInfo I)
	{
		r.addToPot (I);
		StartCoroutine (waitAndDispaly ());

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Potion")
		{
			if (other.isTrigger)
				return;
			IngredientInfo II = other.GetComponent<IngredientInfo> ();
			addToPot (II);
			other.GetComponent<ObjectReturn> ().returnToPoint ();
		}
		if(other.tag == "Final Bottle")
		{
			other.GetComponent<ObjectReturn> ().returnToPoint ();
			r.finishRecipe ();
		}
	}

	IEnumerator waitAndDispaly()
	{
		plusOne.SetActive (true);
		yield return new WaitForSeconds (1F);
		plusOne.SetActive (false);
	}
}
