using UnityEngine;
using System.Collections;

public class ShootArrow : MonoBehaviour {

	public Rigidbody2D rb2d;
	public ArrowManager am;

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
			am.shootFlag = true;
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
		float v = offset.sqrMagnitude;
		float rot = transform.rotation.eulerAngles.z * Mathf.PI / 180;
		rb2d.velocity = new Vector2(v * Mathf.Cos(rot), v * Mathf.Sin(rot));
	}
}
