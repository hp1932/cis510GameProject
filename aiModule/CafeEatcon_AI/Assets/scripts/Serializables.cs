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
	public Dictionary<string, float> dishDemands; 		// demand for each dish
	public Dictionary<string, float> ingredientPrices;	// Cost of each ingredient
	public Dictionary<string, float> dishPrices;		//Cost of each dish.
	public Dictionary<string, int> ingredientsOnHand;	//Name of eahc ingredient and count 
	public Dictionary<string, string[]> recipes;
	public float favorabilityRating;

	public RestaurantStatistics()
	{
		dishDemands = new Dictionary<string, float>();
		ingredientPrices = new Dictionary<string, float>();
		dishPrices = new Dictionary<string, float>();
		ingredientsOnHand = new Dictionary<string, int>();
		recipes = new Dictionary<string, string[]> ();

		InitializeIngredientsOnHand ();
		InitializeIngredientPrices ();
		InitializeRecipes ();
		InitializePrices ();
		InitializeDishDemands ();
		sortDemandsByValue ();

		favorabilityRating = 50f;
		currentBalance = 0.00f;

	}

	/**************************************
	 * Purpose: Initialize recipe hash table
	 * 			with string name and array of ingredients
	 * **************************************/
	private void InitializeRecipes()
	{
		recipes.Add ("Ham Sandwich", new string[] {"bread","ham","cheese","condiments" });
		recipes.Add ("Turkey Sandwich", new string[] {"bread","turkey","cheese","condiments" });
		recipes.Add ("Veggie Sandwich", new string[] {"bread","veggie","cheese","condiments" });	
	}

	/**************************************
	 * Purpose: Initialize price hash table
	 * 			with string name and float price
	 * **************************************/
	private void InitializePrices()
	{
		dishPrices.Add ("Ham Sandwich", 4.50f);
		dishPrices.Add ("Turkey Sandwich", 5.00f);
		dishPrices.Add ("Veggie Sandwich",  3.50f);	
	}

	private void InitializeIngredientPrices()
	{
		ingredientPrices.Add ("bread", 1.5f);
		ingredientPrices.Add ("cheese", 0.5f);
		ingredientPrices.Add ("condiments", 0.5f);
		ingredientPrices.Add ("turkey", 1.5f);
		ingredientPrices.Add ("ham", 1f);
	}

	private void InitializeDishDemands()
	{
		dishDemands.Add ("Ham Sandwich",0.50f);
		dishDemands.Add ("Turkey Sandwich", 0.25f);
		dishDemands.Add ("Veggie Sandwich", 0.25f);
	}

	/************************************
	 * Purpose: Set up ingredients for initial round
	 * 			ONLY call in constructor
	 * ***********************************/
	private void InitializeIngredientsOnHand()
	{
		//Set up ingredients on hand for first round.
		ingredientsOnHand.Add("bread", 5);
		ingredientsOnHand.Add("cheese", 5);
		ingredientsOnHand.Add("condiments", 5);
		ingredientsOnHand.Add("turkey", 2);
		ingredientsOnHand.Add("ham", 3);
		ingredientsOnHand.Add("veggie", 2);
	}

	/***********************************
	 * Purpose: Update the demand for a dish
	 * 
	 * *********************************/
	public void setDishDemand(string dish, float demand)
	{
		//Make sure dish is valid first
		if (dishDemands.ContainsKey (dish)) 
		{
			dishDemands [dish] = demand;
		}
	}

}
	