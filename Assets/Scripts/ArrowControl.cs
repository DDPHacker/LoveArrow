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
		float angle = Mathf.Atan2 (rb2d.velocity.y, rb2d.velocity.x);
		Quaternion rot = new Quaternion ();
		rot.eulerAngles = new Vector3 (0, 0, angle*180/Mathf.PI);
		transform.rotation = rot;
	}
}
