using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReportController : MonoBehaviour {

	public Text reportText;
	public RestaurantStatistics localPlayerData;

	// Use this for initialization
	void Start () {
		localPlayerData = GlobalControl.Instance.savedPlayerData;
		reportText.text = "Balance: $"+localPlayerData.currentBalance + 
					"\nCustomers served: " + localPlayerData.numCustomersServed + "/"+ localPlayerData.numCustomers +
		 "\nMoney Earned: $" + localPlayerData.moneyEarned;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
