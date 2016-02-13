using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float dampTime = 0.15f;
	public Transform target;
	public float MinX, MaxX;

	private ShootArrow sa;
	private Vector3 velocity = Vector3.zero;

	// Start function
	void Start() {
		sa = GameObject.FindGameObjectWithTag("Bow").GetComponentInChildren<ShootArrow>();
	}

	// FixedUpdate function
	void FixedUpdate() {
		if (sa.Shoot() && target) {
			Vector3 point = Camera.main.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.20f, 0.5f, point.z));
			float x = Mathf.Clamp(transform.position.x + delta.x, MinX, MaxX);
			Vector3 destination = new Vector3(x, transform.position.y, transform.position.z);
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
}
