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

	public Text breadInv_Text;
	public Text turkeyInv_Text;
	public Text hamInv_Text;
	public Text veggieInv_Text;
	public Text sodaInv_Text;

	// Use this for initialization
	void Awake ()
	{
		localPlayerData = GlobalControl.Instance.savedPlayerData;
		UpdateSalesReport ();
	}

	void UpdateSalesReport() 
	{
		
		balanceText.text = "Bank Balance: $" + localPlayerData.currentBalance.ToString ();
		profitText.text = "Today's Revenue: $" + (localPlayerData.moneyEarned - localPlayerData.moneySpent).ToString ();

		customersServed.text = localPlayerData.numCustomersServed.ToString();
		customersMissed.text = (localPlayerData.numCustomers - localPlayerData.numCustomersServed).ToString();

		//-----TURKEY-----
		turkeyPrice_Text.text 	= "$" + localPlayerData.dishPrices ["Turkey Sandwich"].ToString ();
		if (localPlayerData.dishesServed.ContainsKey("Turkey Sandwich")) {
			turkeyUnits_Text.text = localPlayerData.dishesServed ["Turkey Sandwich"].ToString ();
			turkeyTotal = localPlayerData.dishPrices ["Turkey Sandwich"] * localPlayerData.dishesServed ["Turkey Sandwich"];
		} else {
			turkeyTotal = 0;
		}
		turkeyResult_Text.text 	= turkeyTotal.ToString ();

		//-------HAM----
		hamPrice_Text.text 	= "$" + localPlayerData.dishPrices ["Ham Sandwich"].ToString ();
		if (localPlayerData.dishesServed.ContainsKey("Ham Sandwich")) {
			hamUnits_Text.text = localPlayerData.dishesServed ["Ham Sandwich"].ToString ();
			hamTotal = localPlayerData.dishPrices ["Ham Sandwich"] * localPlayerData.dishesServed ["Ham Sandwich"];
		} else {
			hamTotal = 0;
		}
		hamResult_Text.text = hamTotal.ToString ();

		//------VEGGIE-----
		veggiePrice_Text.text 	= "$" + localPlayerData.dishPrices ["Veggie Sandwich"].ToString ();
		if (localPlayerData.dishesServed.ContainsKey("Veggie Sandwich")) {
			veggieUnits_Text.text = localPlayerData.dishesServed ["Veggie Sandwich"].ToString ();
			veggieTotal = localPlayerData.dishPrices ["Veggie Sandwich"] * localPlayerData.dishesServed ["Veggie Sandwich"];
		} else {
			veggieTotal = 0;
		}
		veggieResult_Text.text 	= veggieTotal.ToString ();

		//-------SODA----
		sodaPrice_Text.text 	= "$" + localPlayerData.dishPrices ["Soda"].ToString ();
		if (localPlayerData.dishesServed.ContainsKey("Soda")) {
			sodaUnits_Text.text = localPlayerData.dishesServed ["Soda"].ToString ();
			sodaTotal = localPlayerData.dishPrices ["Soda"] * localPlayerData.dishesServed ["Soda"];
		} else {
			sodaTotal = 0;
		}
		sodaResult_Text.text 	= sodaTotal.ToString ();

		salesResult_Text.text = "$" + (turkeyTotal + hamTotal + veggieTotal).ToString ();

		//-----INVENTORY----
		breadInv_Text.text = localPlayerData.ingredientsOnHand ["Bread"].ToString();
		turkeyInv_Text.text = localPlayerData.ingredientsOnHand ["Turkey"].ToString();
		hamInv_Text.text = localPlayerData.ingredientsOnHand ["Ham"].ToString();
		veggieInv_Text.text = localPlayerData.ingredientsOnHand ["Veggie"].ToString();
		sodaInv_Text.text = localPlayerData.ingredientsOnHand ["Soda"].ToString();

	}

}
