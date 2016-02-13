using UnityEngine;
using System.Collections;

public class ShootArrow : MonoBehaviour {

	private Vector3 stPos;
	private Vector2 offset;
	private bool onDrag;
	private bool shoot;

	// Use this for initialization
	void Start () {
		onDrag = false;
		shoot = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			onDrag = true;
			shoot = false;
			stPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			offset = Vector3.zero;
		} else if (Input.GetMouseButton(0)) {
			if (onDrag != true) return;
			Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			offset = mouseWorldPoint - stPos;
		} else if (Input.GetMouseButtonUp(0)) {
			if (onDrag != true) return;
			onDrag = false;
			shoot = true;
		}
	}

	// Get Drog Status
	public bool OnDrag() {
		return onDrag;
	}

	// Get Offset 
	public Vector3 OffSet() {
		return offset;
	}

	// Get shoot status
	public bool Shoot() {
		return shoot;
	}
}
