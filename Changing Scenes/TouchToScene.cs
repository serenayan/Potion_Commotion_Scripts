using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using Leap.Unity;
public class TouchToScene : MonoBehaviour 
{
	[SerializeField] private GameObject button;

	[SerializeField] private float distanceAwayMin;
	[SerializeField] private float timeBetweenChecks;

	[SerializeField] private string levelToLoad;

	[SerializeField] private Recipes r;

	private LeapServiceProvider lsp;
	private bool goingNowRunning;

	void Start()
	{
		lsp = FindObjectOfType<LeapServiceProvider> ();
	}

	void Update()
	{
		foreach (Leap.Hand h in lsp.CurrentFrame.Hands) {
			Debug.Log (Vector3.Distance (h.PalmPosition.ToVector3 (), button.transform.position));
			if (Vector3.Distance (h.PalmPosition.ToVector3 (), button.transform.position) <= distanceAwayMin) {
				if(!goingNowRunning)
				{
					StartCoroutine (goingIncrease ());
				}
			}
		}
	}

	IEnumerator goingIncrease()
	{
		goingNowRunning = true;


		if (levelToLoad == "END") {
			Application.Quit ();
		}else if(levelToLoad == "CLEARALL")
		{
			r.clearAll ();
		}else{
			SceneManager.LoadScene (levelToLoad);
		}

		yield return new WaitForSeconds (timeBetweenChecks);
		goingNowRunning = false;
	}
}
