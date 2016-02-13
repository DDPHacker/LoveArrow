using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SplitArrowControl : MonoBehaviour {

	private GameObject water_drip_1;
	private GameObject water_drip_2;
	private GameObject water_drip_3;

	//public Text Result;

	[HideInInspector] public bool shootFlag;
	public float minVelocity = 8;
	public float maxVelocity = 40;
	[HideInInspector] public bool collisionFlag;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		shootFlag = true;
		collisionFlag = false;

		//Result.text = "";
		water_drip_1 = GameObject.FindGameObjectWithTag("water_drip_1");
		water_drip_2 = GameObject.FindGameObjectWithTag("water_drip_2");
		water_drip_3 = GameObject.FindGameObjectWithTag("water_drip_3");

		if (water_drip_1 && water_drip_2 && water_drip_3) {
			water_drip_1.SetActive (false);
			water_drip_2.SetActive (false);
			water_drip_3.SetActive (false);
		}
	}


	// Update is called once per frame
	void Update () {
		if (collisionFlag) return;

		float angle = Mathf.Atan2 (rb2d.velocity.y, rb2d.velocity.x);
		Quaternion rot = new Quaternion ();
		rot.eulerAngles = new Vector3 (0, 0, angle * 180 / Mathf.PI);
		transform.rotation = rot;
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

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Boundary")) {
			collisionFlag = true;
		}

		if (other.gameObject.CompareTag ("Water")) {
			rb2d.gravityScale = 0.5f;
			float radius = rb2d.transform.rotation.z * Mathf.PI / 180;
			float length = 1.4f;
			water_drip_1.transform.position = new Vector3 (rb2d.transform.position.x + length * Mathf.Cos (radius), -1.8f, 0);
			water_drip_2.transform.position = water_drip_1.transform.position;
			water_drip_3.transform.position = water_drip_1.transform.position;
			water_drip_1.SetActive (true);
			water_drip_2.SetActive (true);
			water_drip_3.SetActive (true);
			water_drip_1.GetComponent<Rigidbody2D> ().velocity = new Vector2 (5, 5);
			water_drip_2.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-5, 5);
			water_drip_3.GetComponent<Rigidbody2D> ().velocity = new Vector2 (3, 3);
			rb2d.velocity = new Vector2 (rb2d.velocity.x * 0.5f, rb2d.velocity.y * 0.5f);
		} else if (other.gameObject.CompareTag ("Block")) {
			rb2d.velocity = new Vector2 (-rb2d.velocity.x, rb2d.velocity.y);
		}
	}
}
