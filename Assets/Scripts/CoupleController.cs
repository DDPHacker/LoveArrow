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
		if (level == 0) {
			SceneManager.LoadScene ("StartScene");
		}
	}

	bool checkAllCollide(){
		GameObject[] go = GameObject.FindGameObjectsWithTag ("NormalArrow");
		for (int i = 0; i < go.Length; ++i) {
			if (!go [i].GetComponent<ArrowManager> ().collisionFlag)
				return false;
		}
		go = GameObject.FindGameObjectsWithTag ("SplittedArrow");
		print (go.Length);
		for (int i = 0; i < go.Length; ++i) {
			if (!go [i].GetComponent<SplitArrowControl> ().collisionFlag)
				return false;
		}
		return true;
	}

	void Update () {
		Transform nan = transform.FindChild ("nan");
		Transform nv = transform.FindChild ("nv");

		if (checkAllCollide()) {
			
			string current = SceneManager.GetActiveScene ().name;
			int next = int.Parse (current.Substring (6)) + 1;

			if (nan.GetComponent<NnControl> ().nnflag && nv.GetComponent<NnControl> ().nnflag) {
				if (next == 6) {
					Result.text = "You win!";
					StartCoroutine (delay (0));
				} else {
					Result.text = "Good job!";
					StartCoroutine (delay (next));
				}
			} else {
				Result.text = "You lose! Try again";
				StartCoroutine (delay (next-1));
			}
		}
			
	}
}
