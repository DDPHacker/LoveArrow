using UnityEngine;
using System.Collections;

public class DripDisappear : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("water_drip_1")||other.gameObject.CompareTag ("water_drip_2")||other.gameObject.CompareTag ("water_drip_3")) {
			other.gameObject.SetActive(false);
		}
	}
}