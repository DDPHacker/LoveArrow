using UnityEngine;
using System.Collections;

public class BowManager : MonoBehaviour {

	private Quaternion stPos;
	private ShootArrow sa;

	// Use this for initialization
	void Start () {
		stPos = transform.rotation;
		sa = GetComponentInChildren<ShootArrow>();
	}

	// Update is called once per frame
	void Update () {
		if (sa.OnDrag()) {
			Vector2 offset = sa.OffSet();
			if (offset.sqrMagnitude != 0) {
				Vector3 newRot = stPos.eulerAngles + new Vector3(0, 0, Mathf.Atan2(offset.y, offset.x) * 180 / Mathf.PI + 180);
				transform.rotation = Quaternion.Euler(newRot);
			}
		} else {
			transform.rotation = stPos;
		}
	}
}
