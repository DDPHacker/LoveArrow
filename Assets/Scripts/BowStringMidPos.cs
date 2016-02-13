using UnityEngine;
using System.Collections;

public class BowStringMidPos : MonoBehaviour {

	public float maxStretch;

	private Vector3 stPos;
	private ShootArrow sa;

	// Use this for initialization
	void Start () {
		stPos = transform.localPosition;
		sa = GetComponent<ShootArrow>();
	}
	
	// Update is called once per frame
	void Update () {
		if (sa.OnDrop()) {
			Vector2 offset = sa.OffSet();
			offset = offset / 5;
			float stretch = offset.sqrMagnitude;
			if (offset.sqrMagnitude > maxStretch)
				stretch = maxStretch;
			transform.localPosition = stPos + new Vector3(-stretch, 0, 0);
		} else {
			transform.localPosition = stPos;
		}
	}
}
