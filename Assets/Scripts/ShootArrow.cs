using UnityEngine;
using System.Collections;

public class ShootArrow : MonoBehaviour {

	private Vector3 stPos;
	private Vector2 offset;
	private bool onDrag;

	// Use this for initialization
	void Start () {
		onDrag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			onDrag = true;
			stPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			offset = Vector3.zero;
		} else if (Input.GetMouseButton(0)) {
			if (onDrag != true) return;
			Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			offset = mouseWorldPoint - stPos;
		} else if (Input.GetMouseButtonUp(0)) {
			if (onDrag != true) return;
			onDrag = false;
			Shoot(offset);
		}
	}

	public bool OnDrop() {
		return onDrag;
	}

	public Vector3 OffSet() {
		return offset;
	}

	void Shoot(Vector3 offset) {
		
	}
}
