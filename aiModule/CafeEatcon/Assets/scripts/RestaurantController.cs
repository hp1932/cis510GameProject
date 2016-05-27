using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public class RestaurantController : MonoBehaviour {

	public RestaurantStatistics localPlayerData;

	public Text bankText;
	public Text profitText;
	public Text inventoryCounts;
	public GameObject newspaper;

	public Text customersServed;
	public Text custmomerMood;
	public bool orderFulfilled;
	private float profit;

	void Awake()
	{
		//Get the ingredientsOnHand from the global controller
		localPlayerData = GlobalControl.Instance.savedPlayerData;
	}


	void Update()
	{
		profit = localPlayerData.moneyEarned - localPlayerData.moneySpent;
		profitText.text = "Today's Profit: " + profit.ToString("C2");

		bankText.text = "Bank Balance: " + localPlayerData.currentBalance.ToString("C2");

		inventoryCounts.text = 
			localPlayerData.ingredientsOnHand ["Bread"].ToString () +
			"\n" + localPlayerData.ingredientsOnHand ["Turkey"].ToString () +
			"\n" + localPlayerData.ingredientsOnHand ["Ham"].ToString () +
			"\n" + localPlayerData.ingredientsOnHand ["Veggie"].ToString () +
			"\n" + localPlayerData.ingredientsOnHand ["Soda"].ToString ();
		
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
			localPlayerData.levelFavorability += calculateCustomerFavorability (true, food);
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
			//levelFavorability only here in case we want a non zero result on missed dish
			localPlayerData.levelFavorability += calculateCustomerFavorability (false, food);
			orderFulfilled = false;
		}
	}

	private float calculateCustomerFavorability(bool served, string food){
		if (served == true) {
			float tempPrice = localPlayerData.dishPrices [food];
			float halfMax =  localPlayerData.maxPrice * 0.5f;
			float favorability = (1.0f - ((tempPrice - halfMax)/halfMax));
			if (favorability > 1.0f) {
				favorability = 1.0f;
			}
			return favorability;
			//calculate
		} else {
			return 0f;
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

	public void finishScene()
	{
		Time.timeScale = 1.0f;
		localPlayerData.checkAchievementProgress (); 
		localPlayerData.UpdateCustomers();
		localPlayerData.UpdateDishDemands();
		localPlayerData.updateFavorabilityRating ();
		newspaper.SetActive (true);
		//Call newspaper's setup here!
		NewspaperController newsController = newspaper.GetComponent<NewspaperController>();
		newsController.init ();
		newsController.pickStory();
	}
		
}
