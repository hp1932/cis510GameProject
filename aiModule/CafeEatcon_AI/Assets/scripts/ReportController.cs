using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ReportController : MonoBehaviour {

	public RestaurantStatistics localPlayerData;

	public Text balanceText;
	public Text profitText;

	public Text turkeyPrice_Text;
	public Text turkeyUnits_Text;
	public Text turkeyResult_Text;
	public Text hamPrice_Text;
	public Text hamUnits_Text;
	public Text hamResult_Text;
	public Text veggiePrice_Text;
	public Text veggieUnits_Text;
	public Text veggieResult_Text;
	public Text salesResult_Text;

	private float turkeyTotal;
	private float hamTotal;
	private float veggieTotal;

	// Use this for initialization
	void Start () {
		localPlayerData = GlobalControl.Instance.savedPlayerData;

		balanceText.text = "Current Balance: $" + localPlayerData.currentBalance.ToString ();
		profitText.text = "Today's Profit: $" + (localPlayerData.moneyEarned - localPlayerData.moneySpent).ToString ();

		turkeyPrice_Text.text 	= "$" + localPlayerData.dishPrices ["Turkey Sandwich"].ToString ();
		turkeyUnits_Text.text 	= localPlayerData.dishesServed ["Turkey Sandwich"].ToString ();
		turkeyTotal 			= localPlayerData.dishPrices ["Turkey Sandwich"] * localPlayerData.dishesServed ["Turkey Sandwich"];
		turkeyResult_Text.text 	= turkeyTotal.ToString ();

		hamPrice_Text.text 	= "$" + localPlayerData.dishPrices ["Ham Sandwich"].ToString ();
		hamUnits_Text.text 	= localPlayerData.dishesServed ["Ham Sandwich"].ToString ();
		hamTotal 			= localPlayerData.dishPrices ["Ham Sandwich"] * localPlayerData.dishesServed ["Ham Sandwich"];
		hamResult_Text.text = hamTotal.ToString ();

		veggiePrice_Text.text 	= "$" + localPlayerData.dishPrices ["Veggie Sandwich"].ToString ();
		veggieUnits_Text.text 	= localPlayerData.dishesServed ["Veggie Sandwich"].ToString ();
		veggieTotal 			= localPlayerData.dishPrices ["Veggie Sandwich"] * localPlayerData.dishesServed ["Veggie Sandwich"];
		veggieResult_Text.text 	= hamTotal.ToString ();

		salesResult_Text.text = "$" + (turkeyTotal + hamTotal + veggieTotal).ToString ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
