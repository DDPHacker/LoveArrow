using UnityEngine;
using System.Collections;

//This script manages each wave of enemies
public class WaveScript : MonoBehaviour 
{
	GameObject[] waveShips;		//The ships that are in this wave


	void Awake()
	{
		//Get a reference to each ship (for efficiency)
		waveShips = new GameObject[transform.childCount];
		for(int i = 0; i < transform.childCount; i++)
		{
			waveShips[i] = transform.GetChild(i).gameObject;
		}
	}

	void OnEnable()
	{
		//When enabled, activate each child
		foreach(GameObject obj in waveShips)
		{
			obj.SetActive(true);
		}
	}

	public bool ShipsStillAlive()
	{
		//Check to see if any of the child ships are still active
		for(int i = 0; i < waveShips.Length; i++)
		{
			//If so, return true
			if(waveShips[i].activeSelf)
				return true;
		}
		//Otherwise, return false
		return false;
	}
}
