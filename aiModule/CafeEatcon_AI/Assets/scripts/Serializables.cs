using UnityEngine;
using System.Collections;
using System;
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

		//Set up ingredients on hand for first round.
		ingredientsOnHand.Add("bread", 5);
		ingredientsOnHand.Add("cheese", 5);
		ingredientsOnHand.Add("condiments", 5);
		ingredientsOnHand.Add("turkey", 2);
		ingredientsOnHand.Add("ham", 3);
		ingredientsOnHand.Add("veggie", 2);

		favorabilityRating = 50f;
		currentBalance = 0.00f;

	}

}
	