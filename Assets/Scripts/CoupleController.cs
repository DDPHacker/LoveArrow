using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoupleController : MonoBehaviour {

	public Text Result;

	void Start () {
		Result.text = "";
	}

	IEnumerator delay(int level) {
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene ("Level_" + level.ToString ());
	}

	void Update () {
		Transform nan = transform.FindChild ("nan");
		Transform nv = transform.FindChild ("nv");

		if (GameObject.FindGameObjectWithTag ("NormalArrow").GetComponent<ArrowManager> ().collisionFlag) {
			
			string current = SceneManager.GetActiveScene ().name;
			int next = int.Parse (current.Substring (6)) + 1;

			if (nan.GetComponent<NnControl> ().nnflag && nv.GetComponent<NnControl> ().nnflag) {
				Result.text = "You win!";
				StartCoroutine (delay (next));

			} else {
				Result.text = "You lose! Try again";
				StartCoroutine (delay (next-1));
			}
		}
			
	}
}
