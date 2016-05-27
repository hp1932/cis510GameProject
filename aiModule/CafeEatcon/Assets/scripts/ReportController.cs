using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ReportController : MonoBehaviour {

	public RestaurantStatistics localPlayerData;

	public Text balanceText;
	public Text profitText;

	public Text customersServed;
	public Text customersMissed;

	public Text turkeyPrice_Text;
	public Text turkeyUnits_Text;
	public Text turkeyResult_Text;
	public Text hamPrice_Text;
	public Text hamUnits_Text;
	public Text hamResult_Text;
	public Text veggiePrice_Text;
	public Text veggieUnits_Text;
	public Text veggieResult_Text;
	public Text sodaPrice_Text;
	public Text sodaResult_Text;
	public Text sodaUnits_Text;
	public Text salesResult_Text;

	private float turkeyTotal;
	private float hamTotal;
	private float veggieTotal;
	private float sodaTotal;

	public Text inventoryText;

	// Use this for initialization
	void Awake ()
	{
		localPlayerData = GlobalControl.Instance.savedPlayerData;
		UpdateSalesReport ();
	}

	void UpdateSalesReport() 
	{
		
		balanceText.text = "Bank Balance: " + localPlayerData.currentBalance.ToString ("C2");
		profitText.text = "Today's Revenue: " + (localPlayerData.moneyEarned - localPlayerData.moneySpent).ToString ("C2");

		customersServed.text = localPlayerData.numCustomersServed.ToString();
		customersMissed.text = (localPlayerData.numCustomers - localPlayerData.numCustomersServed).ToString();

		//-----TURKEY-----
		turkeyPrice_Text.text 	= "" + localPlayerData.dishPrices ["Turkey Sandwich"].ToString ("C2");
		if (localPlayerData.dishesServed.ContainsKey("Turkey Sandwich")) {
			turkeyUnits_Text.text = localPlayerData.dishesServed ["Turkey Sandwich"].ToString ();
			turkeyTotal = localPlayerData.dishPrices ["Turkey Sandwich"] * localPlayerData.dishesServed ["Turkey Sandwich"];
		} else {
			turkeyTotal = 0;
		}
		turkeyResult_Text.text 	= turkeyTotal.ToString ("C2");

		//-------HAM----
		hamPrice_Text.text 	= "" + localPlayerData.dishPrices ["Ham Sandwich"].ToString ("C2");
		if (localPlayerData.dishesServed.ContainsKey("Ham Sandwich")) {
			hamUnits_Text.text = localPlayerData.dishesServed ["Ham Sandwich"].ToString ();
			hamTotal = localPlayerData.dishPrices ["Ham Sandwich"] * localPlayerData.dishesServed ["Ham Sandwich"];
		} else {
			hamTotal = 0;
		}
		hamResult_Text.text = hamTotal.ToString ("C2");

		//------VEGGIE-----
		veggiePrice_Text.text 	= "" + localPlayerData.dishPrices ["Veggie Sandwich"].ToString ("C2");
		if (localPlayerData.dishesServed.ContainsKey("Veggie Sandwich")) {
			veggieUnits_Text.text = localPlayerData.dishesServed ["Veggie Sandwich"].ToString ();
			veggieTotal = localPlayerData.dishPrices ["Veggie Sandwich"] * localPlayerData.dishesServed ["Veggie Sandwich"];
		} else {
			veggieTotal = 0;
		}
		veggieResult_Text.text 	= veggieTotal.ToString ("C2");

		//-------SODA----
		sodaPrice_Text.text 	= "" + localPlayerData.dishPrices ["Soda"].ToString ("C2");
		if (localPlayerData.dishesServed.ContainsKey("Soda")) {
			sodaUnits_Text.text = localPlayerData.dishesServed ["Soda"].ToString ();
			sodaTotal = localPlayerData.dishPrices ["Soda"] * localPlayerData.dishesServed ["Soda"];
		} else {
			sodaTotal = 0;
		}
		sodaResult_Text.text 	= sodaTotal.ToString ("C2");

		salesResult_Text.text = "" + (turkeyTotal + hamTotal + veggieTotal).ToString ("C2");

		//-----INVENTORY----
		inventoryText.text = 
			localPlayerData.ingredientsOnHand ["Bread"].ToString () +
			"\n" + localPlayerData.ingredientsOnHand ["Turkey"].ToString () +
			"\n" + localPlayerData.ingredientsOnHand ["Ham"].ToString () +
			"\n" + localPlayerData.ingredientsOnHand ["Veggie"].ToString () +
			"\n" + localPlayerData.ingredientsOnHand ["Soda"].ToString ();

	}

}
