using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ReportController : MonoBehaviour {

	public Text reportText;
	public Text unitsSoldText;
	public RestaurantStatistics localPlayerData;

	// Use this for initialization
	void Start () {
		localPlayerData = GlobalControl.Instance.savedPlayerData;

		reportText.text = 
			"Total Balance: $"+localPlayerData.currentBalance + 
			"\nDaily profits: $"+(localPlayerData.moneyEarned - localPlayerData.moneySpent) +
			"\nDaily expenses: $"+localPlayerData.moneySpent +
			"\nCustomers served: " + localPlayerData.numCustomersServed + "/"+ localPlayerData.numCustomers +
		 	"\nMoney Earned: $" + localPlayerData.moneyEarned;	

		unitsSoldText.text = 
			"Units Sold: \n";
		foreach (KeyValuePair<string, int> dish in localPlayerData.dishesServed) 
		{
			unitsSoldText.text = unitsSoldText.text + dish.Key +" "+ dish.Value +"\n";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
