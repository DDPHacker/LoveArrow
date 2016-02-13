using UnityEngine;
using System.Collections;

public class FlowerController : MonoBehaviour {
	private Rigidbody2D rb2d;
	private GameObject yumeiren,rose;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void LateUpdate () {

		if (GetComponent<ArrowManager>().shootFlag && Input.GetMouseButtonDown (0)) {
			GameObject yumeiren = (GameObject)Instantiate(Resources.Load("yumeiren"));
			GameObject rose = (GameObject)Instantiate(Resources.Load("rose"));
			Quaternion qy, qr;
			qy = new Quaternion ();
			qr = new Quaternion ();
			qy.eulerAngles = new Vector3 (0, 0, transform.rotation.eulerAngles.z - 20);
			qr.eulerAngles = new Vector3 (0, 0, transform.rotation.eulerAngles.z + 20);
			yumeiren.transform.rotation = qy;
			rose.transform.rotation = qr;

			yumeiren.SetActive (true);
			rose.SetActive (true);
			yumeiren.transform.position = transform.position;
			rose.transform.position = transform.position;
			float angle = Mathf.Atan2 (rb2d.velocity.y, rb2d.velocity.x);
			float angley = angle - Mathf.PI / 3;
			float angler = angle + Mathf.PI / 18;
			float v = rb2d.velocity.magnitude;
			yumeiren.GetComponent<Rigidbody2D> ().velocity = new Vector2 (v * Mathf.Cos (angley), v * Mathf.Sin (angley));
			rose.GetComponent<Rigidbody2D> ().velocity = new Vector2 (v * Mathf.Cos (angler), v * Mathf.Sin (angler));
			gameObject.SetActive (false);
		}
	}
}