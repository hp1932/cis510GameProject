using UnityEngine;
using System.Collections;

public class CustomerController : MonoBehaviour {

	public float spawnWait; 	//OPTIMIZATION: Should this be randomized between two values?
	public int numCustomers;	//the total number of customers for the day/phase

	private int customersSpawned;
	private float lastSpawnTime;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnCustomers()
	{
		//While there are customers left (customersSpawned < numCustomers)
		// check if it is time to spawn another customer
		// if so, spawn one and update custoemrsSpawned and lastSpawnTime
		// if not, wait the amount of time for the next spawn.
	}
}
