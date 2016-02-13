using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CoupleController : MonoBehaviour {

	IEnumerator delay() {
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene ("Level_2");
	}

	void Update () {
		Transform nan = transform.FindChild ("nan");
		Transform nv = transform.FindChild ("nv");
		if (nan.GetComponent<NnControl> ().nnflag && nv.GetComponent<NnControl> ().nnflag &&
		    GameObject.FindGameObjectWithTag ("NormalArrow").GetComponent<ArrowManager> ().collisionFlag) {
			string current = SceneManager.GetActiveScene ().name;
			int next = int.Parse(current.Substring (6))+1;
			SceneManager.LoadScene ("Level_" + next.ToString ());
			print ("hhh");
		}
	}
}
