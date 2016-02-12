using UnityEngine;
using System.Collections;

public class BackToMainMenu : MonoBehaviour {

	public void BackToStartScene() {
		Application.LoadLevel("StartScene");
	}
}
