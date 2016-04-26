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
		print ("GC awake.");
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			print ("Destroying!!!!!!!!");
			Destroy (gameObject);
		}

		allCustomersDone = false;
		phase = 1;

		Instance.SetUpRecipes ();
		Instance.SetUpPrices ();
	}
		
	/**************************************
	 * Purpose: Initialize recipe hash table
	 * 			with string name and array of ingredients
	 * **************************************/
	public void SetUpRecipes()
	{
		savedPlayerData.recipes.Add ("Ham Sandwich", new string[] {"bread","ham","cheese","condiments" });
		savedPlayerData.recipes.Add ("Turkey Sandwich", new string[] {"bread","turkey","cheese","condiments" });
		savedPlayerData.recipes.Add ("Veggie Sandwich", new string[] {"bread","veggie","cheese","condiments" });	
	}

	/**************************************
	 * Purpose: Initialize price hash table
	 * 			with string name and float price
	 * **************************************/
	public void SetUpPrices()
	{
		savedPlayerData.dishPrices.Add ("Ham Sandwich", 4.50f);
		savedPlayerData.dishPrices.Add ("Turkey Sandwich", 5.00f);
		savedPlayerData.dishPrices.Add ("Veggie Sandwich",  3.50f);	
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
