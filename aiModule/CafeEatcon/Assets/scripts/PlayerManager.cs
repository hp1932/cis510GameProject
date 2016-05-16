using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public RestaurantStatistics localPlayerData = new RestaurantStatistics();

	void Start()
	{
		//load in data from global instance
		localPlayerData = GlobalControl.Instance.savedPlayerData;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Save data to global control   
	public void SaveStats()
	{
		GlobalControl.Instance.savedPlayerData = localPlayerData;
	}
}
