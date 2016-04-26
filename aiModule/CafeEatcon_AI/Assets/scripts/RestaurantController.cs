using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public class RestaurantController : MonoBehaviour {

	public RestaurantStatistics localPlayerData = new RestaurantStatistics();
	public GUIText balanceText;

	// Use this for initialization
	void Start () {
	}

	void Awake()
	{
		GlobalControl gc = GlobalControl.Instance;
		print (gc.ToString ());
		localPlayerData = gc.savedPlayerData;
		//Get the ingredientsOnHand from the global controller
		localPlayerData = GlobalControl.Instance.savedPlayerData;
		UpdateBalance ();
	}

	void UpdateBalance()
	{
		balanceText.text = "Balance: $"+ localPlayerData.currentBalance;
	}


	/**************************************
	 * Purpose: Save data to global control
	 * **************************************/  
	public void SaveStats()
	{
		GlobalControl.Instance.savedPlayerData = localPlayerData;
	}

	/**************************************
	 * Purpose: Check ingredient supply
	 * 			Reduce ingredient count
	 * 			Increase balance
	 * **************************************/
	public void Order(string food)
	{
		string[] ingredientList = localPlayerData.recipes [food];

		if (HaveAllIngredients(food)) 
		{
			//For each ingredient in the recipe...
			foreach (string ingredient in ingredientList) 
			{
				localPlayerData.ingredientsOnHand [ingredient]--;
			} 
			localPlayerData.currentBalance += localPlayerData.dishPrices [food];
			UpdateBalance ();
		}
	}

	/*******************************************
	 * Purpose: Check to see if we have all ingredients
	 * 			for a given food
	 * Return: True if we have everything
	 * 			False if we are out of any ingredient
	 * *****************************************/
	bool HaveAllIngredients(string food)
	{
		string[] ingredientList = localPlayerData.recipes [food];

		//For each ingredient in the recipe...
		foreach (string ingredient in ingredientList) 
		{
			//If we are out of any of the ingredients
			if (localPlayerData.ingredientsOnHand [ingredient] <= 0) 
			{
				return false;
				//TO DO: Eventually have some visual showing no more of X ingredient left
			}
		}
		return true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
