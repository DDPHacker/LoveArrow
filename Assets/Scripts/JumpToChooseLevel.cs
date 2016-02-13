using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class JumpToChooseLevel : MonoBehaviour {

	public void GoToChooseLevel() {
		SceneManager.LoadScene("ChooseLevelScene");
	}
}
