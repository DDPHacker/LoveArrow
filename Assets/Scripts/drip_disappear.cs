using UnityEngine;
using System.Collections;

public class drip_disappear : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Drip")) {
			other.gameObject.SetActive(false);
		}
	}
}