using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PurchaseController : MonoBehaviour {

	public RestaurantStatistics localPlayerData;
	public Dictionary<string,int> purchaseCount;

	public Text breadStock_Text;
	public Text turkeyStock_Text;
	public Text hamStock_Text;
	public Text veggieStock_Text;

	public Text breadCount_Text;
	public Text turkeyCount_Text;
	public Text hamCount_Text;
	public Text veggieCount_Text;

	public Text breadResult_Text;
	public Text turkeyResult_Text;
	public Text hamResult_Text;
	public Text veggieResult_Text;

	public Text breadPrice_Text;
	public Text turkeyPrice_Text;
	public Text hamPrice_Text;
	public Text veggiePrice_Text;

	private float breadPrice;

	void Start () {

		localPlayerData = GlobalControl.Instance.savedPlayerData;

		purchaseCount = new Dictionary<string, int>();
		InitializePurchaseCount ();
	}

	void Update()
	{
		breadStock_Text.text 	= localPlayerData.ingredientsOnHand ["Bread"].ToString();
		turkeyStock_Text.text 	= localPlayerData.ingredientsOnHand ["Turkey"].ToString();
		hamStock_Text.text 		= localPlayerData.ingredientsOnHand ["Ham"].ToString();
		veggieStock_Text.text 	= localPlayerData.ingredientsOnHand ["Veggie"].ToString();

		breadPrice_Text.text 	= "$" + localPlayerData.ingredientPrices ["Bread"].ToString ();
		turkeyPrice_Text.text 	= "$" + localPlayerData.ingredientPrices ["Turkey"].ToString ();
		hamPrice_Text.text 		= "$" + localPlayerData.ingredientPrices ["Ham"].ToString ();
		veggiePrice_Text.text 	= "$" + localPlayerData.ingredientPrices ["Veggie"].ToString ();

		breadCount_Text.text = purchaseCount ["Bread"].ToString ();
		turkeyCount_Text.text = purchaseCount ["Turkey"].ToString ();
		hamCount_Text.text = purchaseCount ["Ham"].ToString ();
		veggieCount_Text.text = purchaseCount ["Veggie"].ToString ();
	}

	private void InitializePurchaseCount()
	{
		purchaseCount.Add ("Bread", 0);
		purchaseCount.Add ("Turkey", 0);
		purchaseCount.Add ("Ham", 0);
		purchaseCount.Add ("Veggie", 0);
	}

	public void Purchase(string food)
	{
		
		float ingredientPrice = localPlayerData.ingredientPrices [food];
		
		if (localPlayerData.currentBalance < ingredientPrice * purchaseCount [food]) {
			print ("[Purchase Error]: Insufficient Funds");
			return;
		} else {
			localPlayerData.currentBalance -= (ingredientPrice * purchaseCount [food]); // subtract total
			localPlayerData.ingredientsOnHand [food] += purchaseCount [food]; 			// add purchased ingredients to invetory
			purchaseCount [food] = 0;
		}
	}

	public void incrementCount(string food)
	{
		purchaseCount [food] += 1;
	}

	public void decrementCount(string food)
	{
		if (purchaseCount [food] > 0)
			purchaseCount [food] -= 1;
	}
}
