using UnityEngine;
using System.Collections;

public class HT_Restart : MonoBehaviour {

	public void OnMouseDown () {
		Application.LoadLevel (Application.loadedLevel);
	}
}
