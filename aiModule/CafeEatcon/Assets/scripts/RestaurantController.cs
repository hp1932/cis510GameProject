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

	public Text customersServed;
	public Text custmomerMood;
	public bool orderFulfilled;

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
			"\nVeggies x" + localPlayerData.ingredientsOnHand ["Veggie"].ToString () +
			"\nSoda x" + localPlayerData.ingredientsOnHand ["Soda"].ToString ();

		customersServed.text = "Customers Served: " + localPlayerData.numCustomersServed.ToString();

		if (orderFulfilled)
			custmomerMood.text = ":)";
		else
			custmomerMood.text = ":(";
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
	 * 			Also order soda if applicable
	 * **************************************/
	public void Order(string food)
	{
		float rand = UnityEngine.Random.Range (0f, 1f);

		//If we have all the ingredients,
		if (HaveAllIngredients (food)) 
		{
			//Check if we want to order a soda.
			if (rand < localPlayerData.sodaDemand) 
			{
				//If so, check to make sure we have enough soda
				if (HaveAllIngredients ("Soda")) 
				{
					processOrder (food);
					processOrder ("Soda");
					localPlayerData.numCustomersServed++;
				}
			} 
			//If we don't want soda, just serve the food
			else 
			{
				processOrder (food);
				localPlayerData.numCustomersServed++;
			}

		} 
		//If we don't have enough ingredients, add to missed stats
		else 
		{
			if (food == "Ham Sandwich") 
			{
				localPlayerData.dishServedMissedStats [1] += 1;
			} 
			else if (food == "Turkey Sandwich") 
			{
				localPlayerData.dishServedMissedStats [3] += 1;
			} 
			else if (food == "Veggie Sandwich") 
			{
				localPlayerData.dishServedMissedStats [5] += 1;
			}

			orderFulfilled = false;
		}
	}

	/********************************************************
	 * Purpose: Helper method to subtract the ingredients
	 * 			And add the cash for a dish
	 * Called by: To be called only by Order()
	 * *****************************************************/
	private void processOrder(string food)
	{
		string[] ingredientList = localPlayerData.recipes [food];

		if (food == "Ham Sandwich") {
			localPlayerData.dishServedMissedStats [0] += 1;
		} else if (food == "Turkey Sandwich") {
			localPlayerData.dishServedMissedStats [2] += 1;
		} else if (food == "Veggie Sandwich") {
			localPlayerData.dishServedMissedStats [4] += 1;
		}
		//For each ingredient in the recipe...
		foreach (string ingredient in ingredientList) {
			localPlayerData.ingredientsOnHand [ingredient]--;
		} 
		//Update the totals from the transaction
		localPlayerData.currentBalance += localPlayerData.dishPrices [food];
		localPlayerData.moneyEarned += localPlayerData.dishPrices [food];

		//Add to the dishesServed counter
		if (DishInDictionary (food)) {
			localPlayerData.dishesServed [food]++;
		} 
		else 
		{
			localPlayerData.dishesServed.Add (food, 1);
		}

		orderFulfilled = true;
		print("Served "+food+" left: "+ localPlayerData.ingredientsOnHand ["Soda"]);
	}

	/********************************************************************
	 * Check to see if a dish is already in the dishesServed dictionary
	 * TO DO: Rename this function to be more intuitive
	 * *****************************************************************/
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
