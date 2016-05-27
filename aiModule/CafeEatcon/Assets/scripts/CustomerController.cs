using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerController : MonoBehaviour {

	public float minSpawnWait; 		// The minimum time between spawns.
	public float maxSpawnWait;		// The maximum time between spawns. Actual spawn time is randomized between thee values
	public int numCustomers;		// The total number of customers for the day/phase
	public Vector3 spawnValues;		//Where to start spawning in customers
	public GameObject[] customerTypes;		// Array of random customers to spawn in
	public Vector3[] customerWaitPositions;	// Array containing positions in line for customers. 0th position is window

	private GameObject[] customersInLine;	//Tracks all the customers on screen/ in line
	private int customersSpawned;			// The number of customers actually spawned 
	private int openSpaceIndex;				//The index of the next open space in line
	private readonly int MAX_LINE_LENGTH = 5;	//The max number of customers in line
	/*************************************************
	 * Function: Start
	 * Purpose: Instantiate variables. 
	 * 			Call spawnCustomers as coroutine
	 * ***********************************************/
	void Start () 
	{
		customersSpawned = 0;
		openSpaceIndex = 0;
		customersInLine = new GameObject[MAX_LINE_LENGTH];
		numCustomers = GlobalControl.Instance.savedPlayerData.numCustomers;
		GlobalControl.Instance.savedPlayerData.lastNumCustomers = numCustomers;
		//Spawn in some customers! 
		StartCoroutine (SpawnCustomers ());
	}

	/*************************************************
	 * Function: SpawnCustomers()
	 * Purpose: Pick a random customer type to spawn in
	 * 			Choose random delay between spawns
	 * 			Instantiate new customer
	 * Called: 	As a coroutines in Start()
	 * TO DO:	Have customers move and queue up at drive thru
	 * 			Right now they just spawn in on top of one another
	 * 			as a first iteration
	 * ***********************************************/
	IEnumerator SpawnCustomers()
	{
		float actualSpawnWait;
		GameObject customer;
		GameObject spawnedCustomer;
		CustomerMover spawnedCustomerMover;
		List<DishDemand> sortedDemands;
		Vector3 spawnPosition;
		Quaternion spawnRotation;

		/* Yarrr Matey, Tharr be some BUGGY Code below. Watch Yer Footing.
		if (GlobalControl.Instance.savedPlayerData.tempDemand) {
			GlobalControl.Instance.savedPlayerData.SortTempDemands ();
			sortedDemands = GlobalControl.Instance.savedPlayerData.tempDemandsSorted;
		} else {
			sortedDemands = GlobalControl.Instance.savedPlayerData.dishDemandsSorted;
		}
		*/
		sortedDemands = GlobalControl.Instance.savedPlayerData.dishDemandsSorted;

		/* This 'ere be a map ter 'elp find BUGS
		foreach (DishDemand db in sortedDemands){
			Debug.Log ("Demand" + db.name + ": " + db.probability);
		}*/

		float rand;

		//While there are customers left
		while (customersSpawned <= numCustomers) 
		{
			//Figure out the actual spawn wait between the min and max
			actualSpawnWait = Random.Range (minSpawnWait, maxSpawnWait);

			//Check to see if there is a space to spawn in
			if (openSpaceIndex < MAX_LINE_LENGTH) 
			{
				// Pick a random customer to spawn in
				customer = customerTypes [Random.Range (0, customerTypes.Length)];

				//Set up spawn values
				spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
				spawnRotation = Quaternion.identity;

				//Spawn it in and grab a reference to it
				spawnedCustomer = (GameObject)Instantiate (customer, spawnPosition, spawnRotation);
				spawnedCustomerMover = spawnedCustomer.GetComponent<CustomerMover> ();
				customersSpawned++;

				//set the customer's place in line. The customer will take care of moving to that spot
				spawnedCustomerMover.SetTarget(customerWaitPositions[openSpaceIndex]);
				customersInLine [openSpaceIndex] = spawnedCustomer;
				openSpaceIndex++;

				rand = Random.Range (0f, 1f);
				float cumulativeProb = 0;
				//Assign an order based on dish probabilities
				foreach (DishDemand dd in sortedDemands) 
				{
					cumulativeProb += dd.probability;
					if (rand <= cumulativeProb) 
					{
						spawnedCustomerMover.order = dd.name;
						break;
					}
				}

				//Set flag on last customer
				//print("Customer "+customersSpawned+ "/"+numCustomers);
				if (customersSpawned == numCustomers) 
				{
					//print ("SET LAST CUSTOMER!");
					spawnedCustomerMover.SetLastCustomer (true);
				}

			}

			yield return new WaitForSeconds (actualSpawnWait);
		}
		yield return new WaitForSeconds (maxSpawnWait);

	}

	/***************************************
	 * Purpose: "pop" the 0th element of the array
	 * 			Move all customers in array up
	 * 			Assign new targets for each customer
	 * 			Reduce openSpaceIndex by one
	 * **************************************/
	public void MoveLineForward()
	{
		for (int i = 0; i < customersInLine.Length - 1; ++i) 
		{
			customersInLine [i] = customersInLine [i + 1];
			if (customersInLine [i] != null) 
			{
				customersInLine [i].GetComponent<CustomerMover> ().SetTarget (customerWaitPositions [i]);
			}
		}
		openSpaceIndex = openSpaceIndex - 1;
	}

}
