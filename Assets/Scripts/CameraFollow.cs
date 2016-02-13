using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float dampTime = 0.15f;
	public Transform target;
	public float MinX, MaxX;
	public float scrollSpeed = 500;

	private float MaxMagnitude = 20;
	private Vector3 stPos;
	private Vector2 offset;
	private ShootArrow sa;
	private Vector3 velocity = Vector3.zero;
	private bool onDrag;

	// Start function
	void Start() {
		sa = GameObject.FindGameObjectWithTag("Bow").GetComponentInChildren<ShootArrow>();
	}

	// Update function
	void Update() {
		if (!sa.Shoot()) {
			if (Input.GetMouseButtonDown(0)) {
				stPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				if (target && ((Vector2)(stPos - target.position)).sqrMagnitude <= MaxMagnitude) return;
				onDrag = true;
			} else if (Input.GetMouseButton(0)) {
				if (onDrag != true) return;
				Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				offset = (mouseWorldPoint - stPos) * Time.deltaTime * scrollSpeed;
				float x = Mathf.Clamp(transform.position.x - offset.x, MinX, MaxX);
				Vector3 destination = new Vector3(x, transform.position.y, transform.position.z);
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
				stPos = mouseWorldPoint;
			} else if (Input.GetMouseButtonUp(0)) {
				if (onDrag != true) return;
				onDrag = false;
			}
		}
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
