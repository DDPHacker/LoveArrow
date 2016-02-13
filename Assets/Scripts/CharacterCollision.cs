using UnityEngine;
using System.Collections;

public class CharacterCollision : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other){
		//gameObject.SetActive (false);
		transform.Find("heart").gameObject.SetActive(true);
	}
}
