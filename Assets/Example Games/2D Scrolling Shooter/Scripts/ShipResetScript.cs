using UnityEngine;
using System.Collections;

//This script ensures that the enemy ships return to the proper positions each wave
public class ShipResetScript : MonoBehaviour 
{
	Vector3 originalPosition;			//Original position of the ship
	Quaternion originalRotation;		//Original rotation of the ship


	void OnEnable()
	{
		//Record the position and rotation
		originalPosition = transform.position;
		originalRotation = transform.rotation;
	}

	void OnDisable()
	{
		//Return to original position and rotation
		transform.position = originalPosition;
		transform.rotation = originalRotation;
	}
}
