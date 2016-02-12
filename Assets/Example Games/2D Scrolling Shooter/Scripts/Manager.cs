using UnityEngine;

//This is the manager for the game
public class Manager : MonoBehaviour
{
	public static Manager current;			//A public static reference to itself (make's it visible to other objects without a reference)
	public GameObject player;				//The player ship
	public GameObject titleObject;			//The game object containing the title text
	public GUIText scoreGUIText;			//The score text
	public GUIText highScoreGUIText;		//The high score text
	
	int score;								//The player's score
	int highScore;							//The high score
	string highScoreKey = "highScore";		//Name of the high score


	void Awake()
	{
		//Ensure that there is only one manager
		if(current == null)
			current = this;
		else
			Destroy (gameObject);
	}

	void Start ()
	{
		Initialize ();
	}

	void Update ()
	{
		//Start the game if it isn't already going and the player presses the x key
		if (IsPlaying () == false && Input.GetKeyDown (KeyCode.X)) {
			GameStart ();
		}

		//if the player beats the high score, the high score is set to their score
		if (highScore < score) {
			highScore = score;
		}

		//Set the GUI to relfect the current score and high score
		scoreGUIText.text = score.ToString ();
		highScoreGUIText.text = "HighScore : " + highScore.ToString ();
	}
	
	void GameStart ()
	{
		//Deactivate the title and activate the player
		titleObject.SetActive (false);
		player.SetActive (true);
	}
	
	public void GameOver ()
	{
		//Call the save method
		Save();
		//Activate the title
		titleObject.SetActive (true);
	}
	
	public bool IsPlaying ()
	{
		//if the title is active, then the player isn't playing
		return titleObject.activeSelf == false;
	}

	private void Initialize ()
	{
		//Reset the score and get the high score from the playerprefs
		score = 0;
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
	}
	
	public void AddPoint (int point)
	{
		//Add points to the player's score
		score += point;
	}
	
	public void Save ()
	{
		//Save the highscore to the player prefs
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();
		//Re initialize the score
		Initialize ();
	}
}