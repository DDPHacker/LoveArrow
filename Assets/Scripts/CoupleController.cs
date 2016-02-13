using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoupleController : MonoBehaviour {

	public Text Result;

	void Start () {
		Result.text = "";
	}

	IEnumerator level(int level) {
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene ("Level_" + level.ToString());
	}

	IEnumerator win() {
		SceneManager.LoadScene ("StartScene");
		yield return null;
	}

	bool checkAllCollide(){
		GameObject[] go = GameObject.FindGameObjectsWithTag ("NormalArrow");
		for (int i = 0; i < go.Length; ++i) {
			if (!go [i].GetComponent<NormalArrowController> ().collisionFlag)
				return false;
		}
		go = GameObject.FindGameObjectsWithTag ("SplittedArrow");
		print (go.Length);
		for (int i = 0; i < go.Length; ++i) {
			if (!go [i].GetComponent<SplitArrowController> ().collisionFlag)
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
					StartCoroutine(win());
				} else {
					Result.text = "Good job!";
					StartCoroutine(level(next));
				}
			} else {
				Result.text = "You lose! Try again";
				StartCoroutine(level(next - 1));
			}
		}
			
	}
}
