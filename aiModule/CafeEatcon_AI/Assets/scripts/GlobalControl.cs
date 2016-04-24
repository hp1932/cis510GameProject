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
	public RestaurantStatistics savedPlayerData = new RestaurantStatistics();
	public bool allCustomersDone;	//flag to tell if scene should be finished. Triggered by CustomerController
	public int phase;

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
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}

	void Start()
	{
		allCustomersDone = false;
		phase = 1;
	}

	void Update()
	{
		if ( (1==phase)&& (allCustomersDone)) 
		{
			SceneManager.LoadScene ("phase2");
			allCustomersDone = false;
		}
	}
}
