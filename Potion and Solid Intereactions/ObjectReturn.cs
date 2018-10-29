using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReturn : MonoBehaviour 
{
	// Returns the potion to the rack when its done

	[SerializeField]private Transform returnPoint;
	[SerializeField] private AudioClip soundEffect;

	[SerializeField]private AudioSource audSource;

	void Start()
	{
		transform.position = returnPoint.position;
		transform.rotation = Quaternion.identity;
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GetComponent<Rigidbody> ().freezeRotation = true;
		GetComponent<Rigidbody> ().freezeRotation = false;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Ground" && col.name == "table 1" && this.name == "Final BOttle") {
			return;
		}
		if(col.tag == "Ground")
		{
			returnToPoint ();
		}
	}

	public void returnToPoint()
	{
		audSource.PlayOneShot (soundEffect);
		transform.position = returnPoint.position;
		transform.rotation = Quaternion.identity;
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GetComponent<Rigidbody> ().freezeRotation = true;
		GetComponent<Rigidbody> ().freezeRotation = false;
	}
}
