using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

public class RestaurantStatistics
{
	public float currentBalance;	//The current amount of money available. Is updated during phase 1
	public float startingBalance;	//The amount of money at the start of phase 1. Needs to be persistent to calculate the profits/losses
	public GameObject[] supplies;	//A list of current supplies. This will be populated with actual gameObjects representing the ingredient

	//NOTE May want to change string name identifier to enum later in each dictionary
	public List<DishDemand> dishDemandsSorted; 		// demand for each dish
	public Dictionary<string, float> dishDemands;
	public Dictionary<string, float> ingredientPrices;	// Cost of each ingredient
	public Dictionary<string, float> dishPrices;		//Cost of each dish.
	public Dictionary<string, int> ingredientsOnHand;	//Name of eahc ingredient and count 
	public Dictionary<string, string[]> recipes;
	public float favorabilityRating;

	// list holding served and missed stats per each dish
	// 0,1 are served and missed for ham
	// 2,3 are served and missed for turkey
	// 4,5 are served and missed for veggie
	public List<int> dishServedMissedStats;

	//Variables to be reported in phase 2
	public int maxCustomers;
	public int hamCustomers;
	public int turkeyCustomers;
	public int veggieCustomers;
	public int numCustomers;
	public int numCustomersServed;
	public float moneySpent;
	public float moneyEarned;
	public float balanceIndex;
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


	public RestaurantStatistics()
	{
		dishDemandsSorted 	  = new List<DishDemand>();
		dishServedMissedStats = new List<int> ();
		dishDemands 		  = new Dictionary<string, float> ();
		ingredientPrices 	  = new Dictionary<string, float>();
		dishPrices 			  = new Dictionary<string, float>();
		ingredientsOnHand 	  = new Dictionary<string, int>();
		recipes 			  = new Dictionary<string, string[]> ();
		dishesServed 		  = new Dictionary<string, int> ();

		InitializeIngredientsOnHand ();
		InitializeIngredientPrices ();
		InitializeRecipes ();
		InitializePrices ();
		InitializeDishDemands ();
		InitializeDishServedMissedStats ();
		SortDemands ();

		favorabilityRating = 50f;
		currentBalance = 10.00f;	//start with some cash just to see the difference from daily profit to start
		maxCustomers = 50; 			//initially set to 20
		hamCustomers = 25;
		turkeyCustomers = 15;
		veggieCustomers = 10;
		numCustomers = 25;
		averagePrice = 4.33f;
		numCustomersServed = 0;
		moneyEarned = 0.0f;
		moneySpent = 0.0f;
		balanceIndex = 0.90f;
		slope = 5.55f;

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
	}

	/**************************************
	 * Purpose: Initialize price hash table
	 * 			with string name and float price
	 * **************************************/
	private void InitializePrices()
	{
		dishPrices.Add (HAM_SANDWICH, 4.50f);
		dishPrices.Add (TURKEY_SANDWICH, 5.00f);
		dishPrices.Add (VEGGIE_SANDWICH,  3.50f);	
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
	}

	/**************************************
	 * Purpose: Initialize demands hash table
	 * 			with string name and float probability
	 * **************************************/
	private void InitializeDishDemands()
	{
		dishDemands.Add (HAM_SANDWICH, 0.50f);
		dishDemands.Add (TURKEY_SANDWICH, 0.30f);
		dishDemands.Add (VEGGIE_SANDWICH, 0.20f);
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

		Debug.Log ("hamDemand: " + hamDemand);
		Debug.Log ("turkeyDemand: " + turkeyDemand);
		Debug.Log ("veggieDemand: " + veggieDemand);

		setDishDemand (HAM_SANDWICH, hamDemand);
		setDishDemand (TURKEY_SANDWICH, turkeyDemand);
		setDishDemand (VEGGIE_SANDWICH, veggieDemand);
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

		Debug.Log ("hamServed: " + hamServed);
		Debug.Log ("hamMissed: " + hamMissed);
		Debug.Log ("turkeyServed: " + turkeyServed);
		Debug.Log ("turkeyMissed: " + turkeyMissed);
		Debug.Log ("veggieServed: " + veggieServed);
		Debug.Log ("veggieMissed: " + veggieMissed);

		float hamChange = ChangeIndex(hamCustomers, hamServed, hamMissed, balanceIndex);
		float turkeyChange = ChangeIndex(turkeyCustomers, turkeyServed, turkeyMissed, balanceIndex);
		float veggieChange = ChangeIndex(veggieCustomers, veggieServed, veggieMissed, balanceIndex);

		Debug.Log ("hamChange: " + hamChange);
		Debug.Log ("turkeyChange: " + turkeyChange);
		Debug.Log ("veggieChange: " + veggieChange);

		hamCustomers = (int)Math.Floor(hamCustomers * hamChange);
		turkeyCustomers = (int)Math.Floor(turkeyCustomers * turkeyChange);
		veggieCustomers = (int)Math.Floor(veggieCustomers * veggieChange);
		maxCustomers = hamCustomers + turkeyCustomers + veggieCustomers;

		Debug.Log ("hamCustomers: " + hamCustomers);
		Debug.Log ("turkeyCustomers: " + turkeyCustomers);
		Debug.Log ("veggieCustomers: " + veggieCustomers);
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
	public void SortDemands()
	{
		dishDemandsSorted = new List<DishDemand> ();
		foreach (KeyValuePair<string, float> kvp in dishDemands) {
			dishDemandsSorted.Add (new DishDemand (kvp.Key, kvp.Value));
		}
		dishDemandsSorted.Sort ();
	}

	/************************************
	 * Purpose: Set up ingredients for initial round
	 * 			ONLY call in constructor
	 * ***********************************/
	private void InitializeIngredientsOnHand()
	{
		//Set up ingredients on hand for first round.
		ingredientsOnHand.Add(BREAD, 5);
		ingredientsOnHand.Add(CHEESE, 5);
		ingredientsOnHand.Add(CONDIMENTS, 5);
		ingredientsOnHand.Add(TURKEY, 2);
		ingredientsOnHand.Add(HAM, 3);
		ingredientsOnHand.Add(VEGGIE, 2);
	}

	/***********************************
	 * Purpose: Update the demand for a dish
	 * 
	 * *********************************/
	public void setDishDemand(string dish, float demand)
	{
		dishDemands [dish] = demand;
	}


	private void updateAveragePrice()
	{
		float hamPrice = dishPrices[HAM_SANDWICH];
		float turkeyPrice = dishPrices[TURKEY_SANDWICH];
		float veggiePrice = dishPrices [VEGGIE_SANDWICH];
		averagePrice = (hamPrice + turkeyPrice + veggiePrice) / 3;
	}


	private void updateNumCustomers()
	{
		//Q = maxCustomers - Slope * (AvgPrice)
		numCustomers = (int) ((float) maxCustomers - (slope * averagePrice));
		Debug.Log ("numCustomers: " + numCustomers);
	}

	/**********************************
	 * Purpose: Reset daily variables
	 * 			for phase 1
	 * *********************************/
	public void ResetValuesForPhase1 ()
	{
		moneyEarned = 0;
		numCustomersServed = 0;
		dishesServed = new Dictionary<string, int> ();
		for (int i = 0; i < 6; i++)
		{
			dishServedMissedStats[i] = 0;
		}
	}

}

	