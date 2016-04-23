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
	public float favorabilityRating;

}
	