using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

public class RestaurantStatistics
{
	public int currentDay;		//The current day in the game.

	public float currentBalance;	//The current amount of money available. Is updated during phase 1
	public float startingBalance;	//The amount of money at the start of phase 1. Needs to be persistent to calculate the profits/losses
	public GameObject[] supplies;	//A list of current supplies. This will be populated with actual gameObjects representing the ingredient
	public bool dualDemandCurve;

	//NOTE May want to change string name identifier to enum later in each dictionary
	public List<DishDemand> dishDemandsSorted; 		// demand for each dish
	public List<DishDemand> tempDemandsSorted; 		// demand for each dish
	public Dictionary<string, float> dishDemands;
	public Dictionary<string, float> tempDemands;
	public float sodaDemand;
	public Dictionary<string, float> ingredientPrices;	// Cost of each ingredient
	public Dictionary<string, float> dishPrices;		//Cost of each dish.
	public Dictionary<string, int> ingredientsOnHand;	//Name of eahc ingredient and count 
	public Dictionary<string, string[]> recipes;

	// list holding served and missed stats per each dish
	// 0,1 are served and missed for ham
	// 2,3 are served and missed for turkey
	// 4,5 are served and missed for veggie
	public List<int> dishServedMissedStats;

	//Variables to be reported in phase 2
	public int maxCustomers;
	public int oldMaxCustomers;
	public int hamCustomers;
	public int turkeyCustomers;
	public int veggieCustomers;
	public int lastNumCustomers;
	public int numCustomers;
	public int numCustomersServed;
	public float moneySpent;
	public float moneyEarned;
	public float profit;
	public float balanceIndex;
	public float maxPrice;
	public float averagePrice;
	public float slope;
	public Dictionary<string, int> dishesServed;	//A list of dishes served and their counts

	//TO DO: Make these into an array or something more dynamic
	public readonly string HAM_SANDWICH = "Ham Sandwich";
	public readonly string TURKEY_SANDWICH = "Turkey Sandwich";
	public readonly string VEGGIE_SANDWICH = "Veggie Sandwich";
	public readonly string BREAD = "Bread";
	public readonly string CHEESE = "Cheese";
	public readonly string CONDIMENTS = "Condiments";
	public readonly string TURKEY = "Turkey";
	public readonly string HAM = "Ham";
	public readonly string VEGGIE = "Veggie";
	public readonly string SODA = "Soda";

	//FOR ACHIEVEMENTS
	public int lastCustomerAchievementLevel;
	public int nextCustomerAchievementLevel;
	public float customerAchievementProgress;
	public readonly int CUSTOMER_ACHIEVEMENT_LEVEL_INCREMENT = 20;
	public readonly float MAX_PRICE_INCREMENT = 2f;

	//Favorability Variables
	public float levelFavorability;
	public float favorabilityRating;

	//Random Events
	public int randEvent;
	public bool economyEventCond;
	public bool tempDemand;
	public bool isLavaLevel;
	public int lavaLevelTimer;
	public int lavaLevelLimit;

	public RestaurantStatistics()
	{
		dishDemandsSorted 	  = new List<DishDemand>();
		tempDemandsSorted 	  = new List<DishDemand>();
		dishServedMissedStats = new List<int> ();
		dishDemands 		  = new Dictionary<string, float> ();
		ingredientPrices 	  = new Dictionary<string, float>();
		dishPrices 			  = new Dictionary<string, float>();
		ingredientsOnHand 	  = new Dictionary<string, int>();
		recipes 			  = new Dictionary<string, string[]> ();
		dishesServed 		  = new Dictionary<string, int> ();
		tempDemands			  = new Dictionary<string, float> ();

		//For lava level
		isLavaLevel = false;
		lavaLevelLimit = 2;
		lavaLevelTimer = 0;

		dualDemandCurve = false;
		economyEventCond = false;
		tempDemand = false;
		randEvent = 0;
		InitializeIngredientsOnHand ();
		InitializeIngredientPrices ();
		InitializeRecipes ();
		InitializePrices ();
		InitializeDishDemands ();
		InitializeDishServedMissedStats ();
		SortDishDemands ();
		SortTempDemands ();

		currentDay = 0;
		favorabilityRating = 1.0f;
		levelFavorability = 0f;
		currentBalance = 10.00f;	//start with some cash just to see the difference from daily profit to start
		maxCustomers = 40; 			//initially set to 40
		oldMaxCustomers = 20;
		hamCustomers = 20;
		turkeyCustomers = 10;
		veggieCustomers = 10;
		lastNumCustomers = 0;
		numCustomers = 25;
		averagePrice = 3.40f;
		maxPrice = 6.00f;
		numCustomersServed = 0;
		moneyEarned = 0.0f;
		moneySpent = 0.0f;
		balanceIndex = 0.90f;
		slope = 6.66f;

		lastCustomerAchievementLevel = 40;
		nextCustomerAchievementLevel = 60;
		customerAchievementProgress = 0f;

	}

	/**************************************
	 * Purpose: Initialize recipe hash table
	 * 			with string name and array of ingredients
	 * **************************************/
	private void InitializeRecipes()
	{
		recipes.Add (HAM_SANDWICH, new string[] {BREAD, HAM });
		recipes.Add (TURKEY_SANDWICH, new string[] {BREAD, TURKEY });
		recipes.Add (VEGGIE_SANDWICH, new string[] {BREAD, VEGGIE });	
		recipes.Add (SODA, new string[] { SODA });
	}

	/**************************************
	 * Purpose: Initialize price hash table
	 * 			with string name and float price
	 * **************************************/
	private void InitializePrices()
	{
		dishPrices.Add (HAM_SANDWICH, 3.60f);
		dishPrices.Add (TURKEY_SANDWICH, 3.60f);
		dishPrices.Add (VEGGIE_SANDWICH,  3.00f);	
		dishPrices.Add (SODA, 1.00f);
	}

	/**************************************
	 * Purpose: Initialize price hash table
	 * 			with string name and float price
	 * **************************************/
	private void InitializeIngredientPrices()
	{
		ingredientPrices.Add (BREAD, 1.5f);
		ingredientPrices.Add (CHEESE, 0.5f);
		ingredientPrices.Add (CONDIMENTS, 0.5f);
		ingredientPrices.Add (TURKEY, 1.5f);
		ingredientPrices.Add (HAM, 1.0f);
		ingredientPrices.Add (VEGGIE, 0.5f);
		ingredientPrices.Add (SODA, 0.5f);
	}

	/**************************************
	 * Purpose: Initialize demands hash table
	 * 			with string name and float probability
	 * **************************************/
	private void InitializeDishDemands()
	{
		dishDemands.Add (HAM_SANDWICH, 0.50f);
		dishDemands.Add (TURKEY_SANDWICH, 0.25f);
		dishDemands.Add (VEGGIE_SANDWICH, 0.25f);
		tempDemands.Add (HAM_SANDWICH, 0.50f);
		tempDemands.Add (TURKEY_SANDWICH, 0.25f);
		tempDemands.Add (VEGGIE_SANDWICH, 0.25f);
		sodaDemand = 0.6f;
	}

	private void InitializeDishServedMissedStats()
	{
		for (int i = 0; i < 6; i++)
		{
			dishServedMissedStats.Add (0);
		}
	}

	private float CalculateDemand(int maxCustomers, int dishCustomers)
	{
		return((float)dishCustomers / (float)maxCustomers);
	}

	/**************************************
	 * Purpose: Update each dishes demand.
	 * Note: This uses the CalculateDemand function 
	 * 		 in DishDemand.cs and is called at the 
	 * 		 conclusion of simulation
	 * **************************************/
	public void UpdateDishDemands()
	{
		float hamDemand = CalculateDemand(maxCustomers, hamCustomers);
		float turkeyDemand = CalculateDemand(maxCustomers, turkeyCustomers);
		float veggieDemand = CalculateDemand(maxCustomers, veggieCustomers);

		/*
		Debug.Log ("hamDemand: " + hamDemand);
		Debug.Log ("turkeyDemand: " + turkeyDemand);
		Debug.Log ("veggieDemand: " + veggieDemand);
		*/

		setDishDemand (HAM_SANDWICH, hamDemand);
		setDishDemand (TURKEY_SANDWICH, turkeyDemand);
		setDishDemand (VEGGIE_SANDWICH, veggieDemand);
	}

	/**************************************
	 * Purpose: Check if economy shifting event has occured
	 * **************************************/
	public void CheckRandEvent(){
		if (tempDemand) {
			tempDemand = false;
		}
		if(economyEventCond){
			float tempCustomers;
			switch (randEvent) {
			case 0:
				//alligator, minus 30% customers
				tempCustomers = (float)numCustomers * 0.7f;
				numCustomers = (int)tempCustomers;
				break;
			
			case 1:
				//Comic Con, up 60% customers
				tempCustomers = (float)numCustomers * 1.6f;
				numCustomers = (int)tempCustomers;
				break;
			case 2:
				//Strike, down 10% customers
				tempCustomers = (float)numCustomers * 0.9f;
				numCustomers = (int)tempCustomers;
				break;
			case 3:
				//farmers market, down 10% customers
				tempCustomers = (float)numCustomers * 0.9f;
				numCustomers = (int)tempCustomers;
				break;
			
			case 4:
				//gardening conference, up 30% customers
				tempCustomers = (float)numCustomers * 1.3f;
				numCustomers = (int)tempCustomers;
				break;
			case 5:
				//vegan animal rescue society, Turkey and Ham down 20%, veggie up 60%
				tempDemand = true;
				tempDemands[HAM_SANDWICH] = 0.2f;
				tempDemands[TURKEY_SANDWICH] = 0.2f;
				tempDemands[VEGGIE_SANDWICH] = 0.6f;
				break;
			case 6:
				//poultry unsanitary, minus 90% turkey demand
				tempDemand = true;
				tempDemands[HAM_SANDWICH] = 0.5f;
				tempDemands[TURKEY_SANDWICH] = 0.1f;
				tempDemands[VEGGIE_SANDWICH] = 0.4f;
				break;
			case 7:
				//hoof and mouth disease Ham down 80%, Turkey down 10 percent, veggie up 30%
				tempDemand = true;
				tempDemands[HAM_SANDWICH] = 0.1f;
				tempDemands[TURKEY_SANDWICH] = 0.3f;
				tempDemands[VEGGIE_SANDWICH] = 0.6f;
				break;
			}
		}
	}

	/**************************************
	 * Purpose: Update number of customers in universe and for dishes.
	 * **************************************/
	public void UpdateCustomers()
	{
		int hamServed = dishServedMissedStats[0];
		int hamMissed = dishServedMissedStats[1];
		int turkeyServed = dishServedMissedStats[2];
		int turkeyMissed = dishServedMissedStats[3];
		int veggieServed = dishServedMissedStats[4];
		int veggieMissed = dishServedMissedStats[5];
		/*
		Debug.Log ("hamServed: " + hamServed);
		Debug.Log ("hamMissed: " + hamMissed);
		Debug.Log ("turkeyServed: " + turkeyServed);
		Debug.Log ("turkeyMissed: " + turkeyMissed);
		Debug.Log ("veggieServed: " + veggieServed);
		Debug.Log ("veggieMissed: " + veggieMissed);
		*/

		float hamChange = ChangeIndex(hamCustomers, hamServed, hamMissed, balanceIndex);
		float turkeyChange = ChangeIndex(turkeyCustomers, turkeyServed, turkeyMissed, balanceIndex);
		float veggieChange = ChangeIndex(veggieCustomers, veggieServed, veggieMissed, balanceIndex);

		/*
		Debug.Log ("hamChange: " + hamChange);
		Debug.Log ("turkeyChange: " + turkeyChange);
		Debug.Log ("veggieChange: " + veggieChange);
		*/

		hamCustomers = (int)Math.Floor(hamCustomers * hamChange);
		turkeyCustomers = (int)Math.Floor(turkeyCustomers * turkeyChange);
		veggieCustomers = (int)Math.Floor(veggieCustomers * veggieChange);


		float maxTest = (float)(oldMaxCustomers * 0.75f);
		maxCustomers = hamCustomers + turkeyCustomers + veggieCustomers;
		if ((float)maxCustomers < maxTest) {
			maxCustomers = (int)maxTest;
			oldMaxCustomers = (int)maxTest;
		} else {
			oldMaxCustomers = maxCustomers;
			maxCustomers = hamCustomers + turkeyCustomers + veggieCustomers;
		}
		//div by zero fix
		/*
		if (maxCustomers<lastCustomerAchievementLevel){
			if (maxCustomers < 1) {
				//gameOver
			} else {
				float hamAdjust = hamCustomers / maxCustomers;
				float turkeyAdjust = turkeyCustomers / maxCustomers;
				float veggieAdjust = veggieCustomers / maxCustomers;
				hamCustomers = (int)Math.Ceiling(lastCustomerAchievementLevel * hamAdjust);
				turkeyCustomers = (int)Math.Ceiling(lastCustomerAchievementLevel * turkeyAdjust);
				veggieCustomers = (int)Math.Ceiling(lastCustomerAchievementLevel * veggieAdjust);
				maxCustomers = hamCustomers + turkeyCustomers + veggieCustomers;
			}

		}*/

		/*
		Debug.Log ("hamCustomers: " + hamCustomers);
		Debug.Log ("turkeyCustomers: " + turkeyCustomers);
		Debug.Log ("veggieCustomers: " + veggieCustomers);
		*/
		Debug.Log ("Max Customers (Update Customers): " + maxCustomers);
		Debug.Log ("Old Max Customers (Update Customers): " + oldMaxCustomers);
	}

	/**************************************
	 * Purpose: Generate change index.
	 * **************************************/
	private float ChangeIndex (int customers, int served, int missed, float index)
	{
		int total = served + missed;
		float changeValue = 1.0f;
		if (total == 0) {
			return changeValue;
		}
		try
		{
			changeValue = 1.0f + (((float)served / (float)total) - index);
			if(changeValue > 1.2f){
				changeValue = 1.2f;
			}else if(changeValue < 0.8f){
				changeValue = 0.8f;
			}
		}
		catch(Exception e)
		{
			//trying to divide by zero, probably because nobody likes veggie pattys =[
			Debug.Log("Exception caught in ChangeIndex");
			Console.WriteLine ("Exception caught in ChangeIndex", e);
			//so don't change the demand for that product (for now at least)
		}
		return changeValue;
	}


	/**************************
	 * Purpose: take dishDemands dictionary
	 * 			copy into dishDemandsSorted and sort it
	 * Note: THIS IS NOT THE BEST WAY TO DO THIS
	 * 	But it will work for the POC. I'll refactor later
	 * ***************************/
	public void SortDishDemands()
	{
		dishDemandsSorted = new List<DishDemand> ();
		foreach (KeyValuePair<string, float> kvp in dishDemands) {
			dishDemandsSorted.Add (new DishDemand (kvp.Key, kvp.Value));
		}
		dishDemandsSorted.Sort ();
	}

	/**************************
	 * Purpose: take tempDemands dictionary
	 * 			copy into tempDemandsSorted and sort it
	 * Note: THIS IS NOT THE BEST WAY TO DO THIS
	 * 	But it will work for the POC. I'll refactor later
	 * ***************************/
	public void SortTempDemands()
	{
		tempDemandsSorted = new List<DishDemand> ();
		foreach (KeyValuePair<string, float> kvp in tempDemands) {
			tempDemandsSorted.Add (new DishDemand (kvp.Key, kvp.Value));
		}
		tempDemandsSorted.Sort ();
	}

	/************************************
	 * Purpose: Set up ingredients for initial round
	 * 			ONLY call in constructor
	 * ***********************************/
	private void InitializeIngredientsOnHand()
	{
		//Set up ingredients on hand for first round.
		ingredientsOnHand.Add(BREAD, 25);
		ingredientsOnHand.Add(CHEESE, 5);
		ingredientsOnHand.Add(CONDIMENTS, 5);
		ingredientsOnHand.Add(TURKEY, 8);
		ingredientsOnHand.Add(HAM, 12);
		ingredientsOnHand.Add(VEGGIE, 5);
		ingredientsOnHand.Add (SODA, 10);
	}

	/***********************************
	 * Purpose: Update the demand for a dish
	 * 
	 * *********************************/
	public void setDishDemand(string dish, float demand)
	{
		dishDemands [dish] = demand;
	}

	/***********************************
	 * Purpose: Update the average price after pricing
	 * 			changes finalized.
	 * 
	 * *********************************/
	public void updateAveragePrice()
	{
		float hamPrice = dishPrices[HAM_SANDWICH];
		float turkeyPrice = dishPrices[TURKEY_SANDWICH];
		float veggiePrice = dishPrices [VEGGIE_SANDWICH];
		averagePrice = (hamPrice + turkeyPrice + veggiePrice) / 3;
	}

	/***********************************
	 * Purpose: Update number of customers based
	 * 			on average price and favorability rating
	 * 
	 * *********************************/
	public void updateNumCustomers()
	{
		//Q = maxCustomers - Slope * (AvgPrice)
		int temp = (int)(slope * averagePrice);
		//Debug.Log ("Slope * AveragePrice = " + temp);
		//recalculate favorability rating
		float tempCustomers = ((float) maxCustomers - (float)temp ) * favorabilityRating;
		numCustomers = (int)tempCustomers;
		if (numCustomers < 1) 
		{
			numCustomers = 0;
		}
		Debug.Log ("numCustomers: " + numCustomers);
	}

	/***********************************
	 * Purpose: Update favorability rating at end of
	 * 			simulation 
	 * 			TO-DO:
	 * 			[]Code
	 * 				Favor Rating Updating
	 * 
	 * *********************************/
	public void updateFavorabilityRating(){
		favorabilityRating = levelFavorability / lastNumCustomers;
	}
		
	/**********************************
	 * Purpose: Reset daily variables
	 * 			for phase 1
	 * *********************************/
	public void ResetValuesForPhase1 ()
	{
		moneyEarned = 0;
		numCustomersServed = 0;
		profit = 0;
		dishesServed = new Dictionary<string, int> ();
		levelFavorability = 0f;
		for (int i = 0; i < 6; i++)
		{
			dishServedMissedStats[i] = 0;
		}
	}

	/***********************************************
	 * Purpose: Check for achievement progress
	 * 			Updates achievement levels
	 * *********************************************/
	public void checkAchievementProgress()
	{
		//Customer achievement check
		//Debug.Log("Max Customers (Achievement Check): "+ maxCustomers);
		if (maxCustomers >= nextCustomerAchievementLevel) 
		{
			lastCustomerAchievementLevel = nextCustomerAchievementLevel;
			if(dualDemandCurve==false){
				dualDemandCurve = true;
			}
			//DEBUG
			Debug.Log("Achievement unlocked! Got to "+nextCustomerAchievementLevel + " customers!");

			nextCustomerAchievementLevel += CUSTOMER_ACHIEVEMENT_LEVEL_INCREMENT;
			maxPrice += MAX_PRICE_INCREMENT;

			//THIS WOULD BE WHERE A FLAG WOULD BE SET TO SHOW THE ACHIEVEMENT TO BE SHOWN ON THE NEWSPAPER
		}
		customerAchievementProgress = (float)maxCustomers / (float)nextCustomerAchievementLevel;
		//Make sure progress never goes over 100% for last achievement tiers
		customerAchievementProgress = Mathf.Clamp (customerAchievementProgress, 0.0f, 1.0f);
	}
}

	