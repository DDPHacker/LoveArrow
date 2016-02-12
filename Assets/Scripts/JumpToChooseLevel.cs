using UnityEngine;
using System.Collections;

public class JumpToChooseLevel : MonoBehaviour {

	public void GoToChooseLevel() {
		Application.LoadLevel("ChooseLevelScene");
	}
}
