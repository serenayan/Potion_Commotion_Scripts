using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPointDown : MonoBehaviour 
{
	// Dectects if the potion bottle is facing downwards or not
	[SerializeField] private Transform potionBottleNeck;
	[SerializeField] private float heightAboveCauldron;
	[SerializeField] private GameObject cauldron;
	[SerializeField] private GameObject particles;

	[SerializeField] private float timeBetweenPours;

	private bool isOk = false;
	private AudioSource audSource;

	void Start()
	{
		audSource = GetComponent<AudioSource> ();
		cauldron = GameObject.FindWithTag("Cauldron");
		StartCoroutine (wait ());
	}

	void Update()
	{
		if (Vector3.Dot (potionBottleNeck.transform.up, Vector3.down) > 0 && isOk) {
			particles.SetActive (true);

			if(!audSource.isPlaying)
			{
				audSource.Play ();
			}
		} else {
			particles.SetActive (false);
			if(audSource.isPlaying)
			{
				audSource.Stop ();
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Cauldron Zone")
		{
			isOk = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Cauldron Zone")
		{
			isOk = false;
		}
	}

	IEnumerator wait()
	{
		while (true) {
			yield return new WaitForSeconds (timeBetweenPours);

			if (Vector3.Dot (potionBottleNeck.transform.up, Vector3.down) > 0 && isOk)
				cauldron.GetComponentInChildren<ParticleToPotion> ().addToPot (this.GetComponent<IngredientInfo> ());
		}
	}

}
