using UnityEngine;
using System.Collections;

//	Attach this script to the Main Camera.
//	This script will set the transform values for the GameObject it is attached to.
public class ProjectileFollow : MonoBehaviour {

	public Transform projectile;        // The transform of the projectile to follow.
	public Transform farLeft;           // The transform representing the left bound of the camera's position.
	public Transform farRight;          // The transform representing the right bound of the camera's position.

	void Update () {
		// Store the position of the camera.
		Vector3 newPosition = transform.position;
		
		// Set the x value of the stored position to that of the bird.
		newPosition.x = projectile.position.x;
		
		// Clamp the x value of the stored position between the left and right bounds.
		newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);
		
		// Set the camera's position to this stored position.
		transform.position = newPosition;
	}
}
