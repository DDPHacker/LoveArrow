using UnityEngine;
using System.Collections;

public class NnControl : MonoBehaviour {
	
	public bool nnflag;

	void Start () {
		nnflag = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("NormalArrow") || other.CompareTag ("SplittedArrow")) {
			nnflag = true;
			transform.FindChild("Heart").gameObject.SetActive(true);
		}
	}

}
