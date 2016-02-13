using UnityEngine;
using System.Collections;

public class ArrowControl : MonoBehaviour {
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();	
		float rot = transform.rotation.eulerAngles.z*Mathf.PI/180;
		rb2d.velocity= new Vector2(10*Mathf.Cos(rot),10*Mathf.Sin(rot));
	}
	
	// Update is called once per frame
	void Update () {
	}
}
