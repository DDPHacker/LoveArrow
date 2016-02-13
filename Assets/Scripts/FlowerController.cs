using UnityEngine;
using System.Collections;

public class FlowerController : MonoBehaviour {
	private GameObject yumeiren,rose;

	void LateUpdate () {

		if (GetComponent<ArrowManager>().shootFlag && Input.GetMouseButtonDown (0)) {
			yumeiren = transform.parent.Find ("yumeiren").gameObject;
			rose = transform.parent.Find ("rose").gameObject;
			//yumeiren = GameObject.FindGameObjectWithTag ("yumeiren");
			// = GameObject.FindGameObjectWithTag ("rose");
			print (yumeiren);
			Quaternion qy, qr;
			qy = new Quaternion ();
			qr = new Quaternion ();
			qy.eulerAngles = new Vector3 (0, 0, transform.rotation.eulerAngles.z - 20);
			qr.eulerAngles = new Vector3 (0, 0, transform.rotation.eulerAngles.z + 20);
			yumeiren.transform.rotation = qy;
			rose.transform.rotation = qr;
			yumeiren.GetComponent<ArrowManager> ().shootFlag = true;
			rose.GetComponent<ArrowManager> ().shootFlag = true;
			gameObject.SetActive (false);
			yumeiren.SetActive (true);
			rose.SetActive (true);
			yumeiren.transform.position = transform.position;
			rose.transform.position = transform.position;
		}
	}
}