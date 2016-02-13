using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackToMainMenu : MonoBehaviour {

	public void BackToStartScene() {
		SceneManager.LoadScene("StartScene");
	}
}
