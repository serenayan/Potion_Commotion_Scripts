using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class VRLaw : MonoBehaviour
{
	// Enforces the VR LAW

	void Start()
	{
		if(VRDevice.isPresent==true && string.IsNullOrEmpty(VRDevice.model))
		{
			Debug.Log("EMPTY VR DEVICE DETECTED!");
			VRSettings.LoadDeviceByName(VRDeviceType.Oculus.ToString());
			VRSettings.enabled = true;
			VRSettings.showDeviceView = true; 
		}   
	}
}
