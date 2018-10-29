using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public int time = 5;
	public Text TimerText;
	public Recipes r;

	// Use this for initialization
	void Start()
	{
		StartCoroutine("CountDownTime");
	}

	// Update is called once per frame
	void Update()
	{
		TimerText.text = ("Time Left = " + time);

		if (time <= 0)
		{
			StopCoroutine("CountDownTime");
			TimerText.text = "Times Ran Out!";
			r.gameEnd ();
		}
	}

	IEnumerator CountDownTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			time--;
		}
	}
}