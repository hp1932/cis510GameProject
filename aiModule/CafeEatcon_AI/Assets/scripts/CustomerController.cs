using UnityEngine;
using System.Collections;

public class CustomerController : MonoBehaviour {

	public float minSpawnWait; 		// The minimum time between spawns.
	public float maxSpawnWait;		// The maximum time between spawns. Actual spawn time is randomized between thee values
	public int numCustomers;		// The total number of customers for the day/phase
	public GameObject[] customers;	// Array of random customers to spawn in
	public Vector3 spawnValues;		//Where to start spawning in customers

	private int customersSpawned;	// The number of customers actually spawned currently

	/*************************************************
	 * Function: Start
	 * Purpose: Instantiate variables. 
	 * 			Call spawnCustomers as coroutine
	 * ***********************************************/
	void Start () 
	{
		customersSpawned = 0;
		//Spawn in some customers! 
		StartCoroutine (SpawnCustomers ());
	}

	/*************************************************
	 * Function: SpanwCustomers()
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
		Vector3 spawnPosition;
		Quaternion spawnRotation;
		//While there are customers left
		while (customersSpawned < numCustomers) 
		{
			// Pick a random customer to spawn in
			customer = customers [Random.Range (0, customers.Length)];
			//Figure out the actual spawn wait between the min and max
			actualSpawnWait = Random.Range (minSpawnWait, maxSpawnWait);
			spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			spawnRotation = Quaternion.identity;
			Instantiate (customer, spawnPosition, spawnRotation);
			customersSpawned++;
			yield return new WaitForSeconds (actualSpawnWait);
		}
	}
}
