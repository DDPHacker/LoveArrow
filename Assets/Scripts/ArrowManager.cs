using UnityEngine;
using System.Collections;

public class ArrowManager : MonoBehaviour {

	[HideInInspector] public bool shootFlag;
	public float minVelocity = 0;

	private Transform stPos;
	private Transform bowT;
	private ShootArrow sa;
	private bool collisionFlag;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		bowT = GameObject.FindGameObjectWithTag("Bow").transform;
		stPos = GameObject.FindGameObjectWithTag("Bow").transform.FindChild("MidPos").transform;
		sa = GameObject.FindGameObjectWithTag("Bow").GetComponentInChildren<ShootArrow>();
		transform.position = stPos.position;
		shootFlag = false;
		collisionFlag = false;
	}
		
	void Shoot() {
		shootFlag = true;
		float v = sa.OffSet().sqrMagnitude;
		float rot = transform.rotation.eulerAngles.z * Mathf.PI / 180;
		Debug.Log(v);
		if (v < minVelocity)
			v = minVelocity;
		rb2d.velocity = new Vector2(v * Mathf.Cos(rot), v * Mathf.Sin(rot));
	}

	// Update is called once per frame
	void Update () {
		if (collisionFlag) return;
		if (!shootFlag && !sa.Shoot()) {
			transform.position = stPos.position;
			transform.rotation = bowT.rotation;
		} else if (!shootFlag && sa.Shoot()) {
			Shoot();
		} else {
			float angle = Mathf.Atan2 (rb2d.velocity.y, rb2d.velocity.x);
			Quaternion rot = new Quaternion ();
			rot.eulerAngles = new Vector3 (0, 0, angle * 180 / Mathf.PI);
			transform.rotation = rot;
		}
	}

	// Collision detect
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground" && shootFlag) {
			rb2d.gravityScale = 0.0f;
			rb2d.velocity = Vector2.zero;
			collisionFlag = true;
			rb2d.isKinematic = true;
		}
	}
}
