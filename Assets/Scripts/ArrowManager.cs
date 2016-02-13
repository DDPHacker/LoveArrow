using UnityEngine;
using System.Collections;

public class ArrowManager : MonoBehaviour {

	public Transform stPos;
	public Transform bowT;

	// Use this for initialization
	void Start () {
		transform.position = stPos.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = stPos.position;
		transform.rotation = bowT.rotation;
	}
}
