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

	//Variables to be reported in phase 2
	public int numCustomers;
	public int numCustomersServed;
	public float moneySpent;
	public float moneyEarned;

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
		dishDemandsSorted = new List<DishDemand>();
		dishDemands = new Dictionary<string, float> ();
		ingredientPrices = new Dictionary<string, float>();
		dishPrices = new Dictionary<string, float>();
		ingredientsOnHand = new Dictionary<string, int>();
		recipes = new Dictionary<string, string[]> ();

		InitializeIngredientsOnHand ();
		InitializeIngredientPrices ();
		InitializeRecipes ();
		InitializePrices ();
		InitializeDishDemands ();
		SortDemands ();

		favorabilityRating = 50f;
		currentBalance = 0.00f;
		numCustomers = 0;
		numCustomersServed = 0;
		moneyEarned = 0.0f;
		moneySpent = 0.0f;

	}

	/**************************************
	 * Purpose: Initialize recipe hash table
	 * 			with string name and array of ingredients
	 * **************************************/
	private void InitializeRecipes()
	{
		recipes.Add (HAM_SANDWICH, new string[] {BREAD, HAM, CHEESE, CONDIMENTS });
		recipes.Add (TURKEY_SANDWICH, new string[] {BREAD, TURKEY, CHEESE, CONDIMENTS });
		recipes.Add (VEGGIE_SANDWICH, new string[] {BREAD, VEGGIE,CHEESE,CONDIMENTS });	
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
		ingredientPrices.Add (HAM, 1f);
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
	public void setDishDemand(string dish, int demand)
	{
		dishDemands [dish] = demand;
	}

}

	