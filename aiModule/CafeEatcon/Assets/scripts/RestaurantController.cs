using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public class RestaurantController : MonoBehaviour {

	public RestaurantStatistics localPlayerData;

	public Text bankText;
	public Text revenueText;
	public Text inventoryText;
	
	void Awake()
	{
		//Get the ingredientsOnHand from the global controller
		localPlayerData = GlobalControl.Instance.savedPlayerData;
	}


	void Update()
	{
		revenueText.text = "Today's Profit: $" + (localPlayerData.moneyEarned - localPlayerData.moneySpent);

		bankText.text = "Bank Balance: $" 	+ localPlayerData.currentBalance;

		inventoryText.text = 
			"Bread x" + localPlayerData.ingredientsOnHand ["Bread"].ToString () +
			"\nTurkey x" + localPlayerData.ingredientsOnHand ["Turkey"].ToString () +
			"\nHam x" + localPlayerData.ingredientsOnHand ["Ham"].ToString () +
			"\nVeggies x" + localPlayerData.ingredientsOnHand ["Veggie"].ToString ();
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

		localPlayerData.numCustomers++;

		if (HaveAllIngredients (food)) {
			//For each ingredient in the recipe...
			foreach (string ingredient in ingredientList) {
				localPlayerData.ingredientsOnHand [ingredient]--;
			} 
			//Update the totals from the transaction
			localPlayerData.currentBalance += localPlayerData.dishPrices [food];
			localPlayerData.numCustomersServed++;
			localPlayerData.moneyEarned += localPlayerData.dishPrices [food];

			//Add to the dishesServed counter
			if (DishInDictionary (food)) {
				localPlayerData.dishesServed [food]++;
			} 
			else 
			{
				localPlayerData.dishesServed.Add (food, 1);
			}

		} 
	}

	bool DishInDictionary(string food)
	{
		return localPlayerData.dishesServed.ContainsKey (food);
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

}
