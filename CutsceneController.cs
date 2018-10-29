using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour 
{
	// Controls the cutscene at the begining of the game

	[SerializeField] private cutsceneImage[] allImages;

	[SerializeField] private Image cutsceneProjectionImage;
	private int currentImageIndex = 0;

	void Start()
	{
		StartCoroutine (waitAndDisplayImage ());
	}

	IEnumerator waitAndDisplayImage()
	{
		while (true) {

			if (currentImageIndex >= allImages.Length) {
				SceneManager.LoadScene ("Potion Commotion Demo");
			}

			cutsceneProjectionImage.sprite = allImages [currentImageIndex].image;

			yield return new WaitForSeconds (allImages [currentImageIndex].timeInImage);
			currentImageIndex++;
		}
	}

}
[System.Serializable]
public class cutsceneImage
{
	public Sprite image;
	public float timeInImage;
}
