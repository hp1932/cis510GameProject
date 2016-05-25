/**************************************************************
 * Persistent global singleton
 * Purpose: Store all data needed to be saved between scenes
 * REFERENCES:
 * 			- Saving global data: http://www.sitepoint.com/saving-data-between-scenes-in-unity/
 * ************************************************************/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GlobalControl : MonoBehaviour 
{
	public static GlobalControl Instance;

	//stats to be kept regardless of the scene
	public RestaurantStatistics savedPlayerData;
	public bool allCustomersDone;	//flag to tell if scene should be finished. Triggered by CustomerController

	/**********************************************
	 * Purpose: Initialize instance of singleton
	 * 			Ensure it is only instance
	 * 			and that it will not be destroyed.
	 * ********************************************/
	void Awake ()   
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
			savedPlayerData = new RestaurantStatistics ();
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}

		//Reset variables that need to be cleared each level
		allCustomersDone = false;
		//I need to fix how phases are handled later.....
	}
		
	void Update()
	{
		if (allCustomersDone) 
		{
			Time.timeScale = 1.0f;
			savedPlayerData.checkAchievementProgress (); 
			savedPlayerData.UpdateCustomers();
			savedPlayerData.UpdateDishDemands();
			SceneManager.LoadScene ("phase2");
			allCustomersDone = false;
		}
	}


}
