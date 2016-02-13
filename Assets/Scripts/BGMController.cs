using UnityEngine;
using System.Collections;

public class BGMController : MonoBehaviour {

	private static BGMController instance = null;
	public static BGMController Instance {
		get { 
			return instance;
		}
	}
	private AudioSource audios;

	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

	void Start() {
		audios = GetComponent<AudioSource>();
	}

	public void Switch() {
		if (audios.isPlaying) {
			audios.Stop();
		} else {
			audios.Play();
		}
	}
}
