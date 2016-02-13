using UnityEngine;
using System.Collections;

public class BowStringSidePos : MonoBehaviour {

	public Transform edPos;
	public int layerOrder;

	private LineRenderer lr;

	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer>();
		lr.SetPosition(0, transform.position);
		lr.SetPosition(1, edPos.position);
		lr.sortingLayerName = "Player";
		lr.sortingOrder = layerOrder;
	}

	// Update is called once per frame
	void Update() {
		lr.SetPosition(0, transform.position);
		lr.SetPosition(1, edPos.position);
	}
}
