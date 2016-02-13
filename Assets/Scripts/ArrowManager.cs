using UnityEngine;
using System.Collections;

public class ArrowManager : MonoBehaviour {

	public Transform stPos;
	public Transform bowT;
	[HideInInspector] public bool shootFlag;

	private bool collisionFlag;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		transform.position = stPos.position;
		rb2d = GetComponent<Rigidbody2D>();
		shootFlag = false;
		collisionFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (collisionFlag) return;
		if (!shootFlag) {
			transform.position = stPos.position;
			transform.rotation = bowT.rotation;
		} else {
			float angle = Mathf.Atan2 (rb2d.velocity.y, rb2d.velocity.x);
			Quaternion rot = new Quaternion ();
			rot.eulerAngles = new Vector3 (0, 0, angle * 180 / Mathf.PI);
			transform.rotation = rot;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground" && shootFlag) {
			rb2d.gravityScale = 0.0f;
			rb2d.velocity = Vector2.zero;
			collisionFlag = true;
			rb2d.isKinematic = true;
		}
	}
}
