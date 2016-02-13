using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageSwitch : MonoBehaviour {

	public Sprite mute; 
	public Sprite voice;

	private Image im;

	// Use this for initialization
	void Start () {
		im = GetComponent<Image>();
	}

	// Switch function
	public void Switch() {
		if (im.sprite.name.CompareTo("voice") == 0) {
			im.sprite = mute;
		} else {
			im.sprite = voice;
		}
	}
}
