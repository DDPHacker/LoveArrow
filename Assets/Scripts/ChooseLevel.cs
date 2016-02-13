﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChooseLevel : MonoBehaviour {

	public void GoToLevel(int level_num) {
		SceneManager.LoadScene("Level_" + level_num.ToString());
	}
}
