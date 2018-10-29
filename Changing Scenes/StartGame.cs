using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	[SerializeField] private GameObject mainGame;
	[SerializeField] private GameObject tutorial;
	[SerializeField] private GameObject exitGame;

	[SerializeField] private GameObject[] allInteractableThings;

	[SerializeField] private float distanceAwayMin;

	[SerializeField] private float timeBetweenChecks;

	private bool mainGameRunning;
	private bool tutorialRunning;
	private bool exitGameRunning;

	void Update()
	{
		foreach(GameObject g in allInteractableThings)
		{
			if (!g.activeInHierarchy)
				return;
			if(Vector3.Distance(g.transform.position,mainGame.transform.position) <= distanceAwayMin)
			{
				if (Vector3.Distance (g.transform.position, mainGame.transform.position) < Vector3.Distance (g.transform.position, tutorial.transform.position) &&
				   Vector3.Distance (g.transform.position, mainGame.transform.position) < Vector3.Distance (g.transform.position, exitGame.transform.position)) {
					if (!mainGameRunning) {
						StartCoroutine (mainGameIncrease (g));
					}
				}
			}

			if(Vector3.Distance(g.transform.position,tutorial.transform.position) <= distanceAwayMin)
			{
				if (Vector3.Distance (g.transform.position, tutorial.transform.position) < Vector3.Distance (g.transform.position, mainGame.transform.position) &&
				    Vector3.Distance (g.transform.position, tutorial.transform.position) < Vector3.Distance (g.transform.position, exitGame.transform.position)) {
					if (!tutorialRunning) {
						StartCoroutine (tutorialIncrease (g));
					}
				}
			}

			if(Vector3.Distance(g.transform.position,tutorial.transform.position) <= distanceAwayMin)
			{
				if (Vector3.Distance (g.transform.position, exitGame.transform.position) < Vector3.Distance (g.transform.position, tutorial.transform.position) &&
					Vector3.Distance (g.transform.position, exitGame.transform.position) < Vector3.Distance (g.transform.position, mainGame.transform.position)) {
					if (!exitGameRunning) {
						StartCoroutine (tutorialIncrease (g));
					}
				}
			}
		}
	}

	IEnumerator mainGameIncrease(GameObject g)
	{
		mainGameRunning = true;

		yield return new WaitForSeconds (timeBetweenChecks);

		if(Vector3.Distance(g.transform.position,mainGame.transform.position) <= distanceAwayMin)
		{
			SceneManager.LoadScene ("Cutscene");
		}

		mainGameRunning = false;
	}

	IEnumerator exitGameIncrease(GameObject g)
	{
		exitGameRunning = true;

		yield return new WaitForSeconds (timeBetweenChecks);

		if(Vector3.Distance(g.transform.position,mainGame.transform.position) <= distanceAwayMin)
		{
			Application.Quit ();
		}

		exitGameRunning = false;
	}

	IEnumerator tutorialIncrease(GameObject g)
	{
		tutorialRunning = true;

		yield return new WaitForSeconds (timeBetweenChecks);

		if(Vector3.Distance(g.transform.position,tutorial.transform.position) <= distanceAwayMin)
		{
			SceneManager.LoadScene ("Tutorial1");
		}

		tutorialRunning = false;
	}
}
