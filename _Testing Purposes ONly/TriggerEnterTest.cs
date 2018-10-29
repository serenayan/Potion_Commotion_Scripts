using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterTest : MonoBehaviour
{
	// Testing the trigger enter function with the hands!

	void OnTriggerEnter(Collider other)
	{
		// Moved the IsHand function to the Config file ease of acess later on
		if(Config.IsHand(other))
		{
			this.GetComponent<Material> ().color = Random.ColorHSV ();
		}
	}

	public void working(Collider other)
	{
		if(Config.IsHand(other))
		{
			this.GetComponent<Material> ().color = Random.ColorHSV ();
		}
	}
}
