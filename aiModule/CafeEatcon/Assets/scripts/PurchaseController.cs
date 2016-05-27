using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PurchaseController : MonoBehaviour {

	public RestaurantStatistics localPlayerData;
	public Dictionary<string,int> purchaseCount;

	public Text inventoryText;

	public Text breadCount_Text;
	public Text turkeyCount_Text;
	public Text hamCount_Text;
	public Text veggieCount_Text;
	public Text sodaCount_Text;

	public Text breadResult_Text;
	public Text turkeyResult_Text;
	public Text hamResult_Text;
	public Text veggieResult_Text;
	public Text sodaResult_Text;

	public Text breadPrice_Text;
	public Text turkeyPrice_Text;
	public Text hamPrice_Text;
	public Text veggiePrice_Text;
	public Text sodaPrice_Text;

	public Text balanceText;
	public Text profitText;

	public AudioClip buttonSound;
	public AudioClip purchaseSound;
	public AudioClip failSound;

	public int breadIncrement;
	public int fillingIncrement;
	

	void Start () {

		localPlayerData = GlobalControl.Instance.savedPlayerData;
		localPlayerData.moneySpent = 0;	//Reset the money spent for this round 

		purchaseCount = new Dictionary<string, int>();
		InitializePurchaseCount ();
	}

	void Update()
	{
		breadPrice_Text.text 	= localPlayerData.ingredientPrices ["Bread"].ToString ("C2");
		turkeyPrice_Text.text 	= localPlayerData.ingredientPrices ["Turkey"].ToString ("C2");
		hamPrice_Text.text 		= localPlayerData.ingredientPrices ["Ham"].ToString ("C2");
		veggiePrice_Text.text 	= localPlayerData.ingredientPrices ["Veggie"].ToString ("C2");
		sodaPrice_Text.text 	= localPlayerData.ingredientPrices ["Soda"].ToString ("C2");

		breadCount_Text.text 	= purchaseCount ["Bread"].ToString ();
		turkeyCount_Text.text 	= purchaseCount ["Turkey"].ToString ();
		hamCount_Text.text 		= purchaseCount ["Ham"].ToString ();
		veggieCount_Text.text 	= purchaseCount ["Veggie"].ToString ();
		sodaCount_Text.text 	= purchaseCount ["Soda"].ToString ();

		breadResult_Text.text 	= "x        =  " + (localPlayerData.ingredientPrices ["Bread"] * purchaseCount ["Bread"]).ToString ("C2");
		turkeyResult_Text.text 	= "x        =  " + (localPlayerData.ingredientPrices ["Turkey"] * purchaseCount ["Turkey"]).ToString ("C2");
		hamResult_Text.text 	= "x        =  " + (localPlayerData.ingredientPrices ["Ham"] * purchaseCount ["Ham"]).ToString ("C2");
		veggieResult_Text.text 	= "x        =  " + (localPlayerData.ingredientPrices ["Veggie"] * purchaseCount ["Veggie"]).ToString ("C2");
		sodaResult_Text.text 	= "x        =  " + (localPlayerData.ingredientPrices ["Soda"] * purchaseCount ["Soda"]).ToString ("C2");


		balanceText.text = "Bank Balance: $" + localPlayerData.currentBalance.ToString ();
		profitText.text = "Today's Revenue: $" + (localPlayerData.moneyEarned).ToString ();

		inventoryText.text = 
			localPlayerData.ingredientsOnHand ["Bread"].ToString () +
			"\n" + localPlayerData.ingredientsOnHand ["Turkey"].ToString () +
			"\n" + localPlayerData.ingredientsOnHand ["Ham"].ToString () +
			"\n" + localPlayerData.ingredientsOnHand ["Veggie"].ToString () +
			"\n" + localPlayerData.ingredientsOnHand ["Soda"].ToString ();
	}

	private void InitializePurchaseCount()
	{
		purchaseCount.Add ("Bread", 0);
		purchaseCount.Add ("Turkey", 0);
		purchaseCount.Add ("Ham", 0);
		purchaseCount.Add ("Veggie", 0);
		purchaseCount.Add ("Soda", 0);
	}

	public void Purchase(string food)
	{
		
		float ingredientPrice = localPlayerData.ingredientPrices [food];
		if (purchaseCount [food] == 0) {
			SoundManager.instance.PlaySingle (failSound);
		}
		else if (localPlayerData.currentBalance < ingredientPrice * purchaseCount [food]) {
			SoundManager.instance.PlaySingle (failSound);
			print ("[Purchase Error]: Insufficient Funds");
			return;
		} else {
			SoundManager.instance.PlaySingle (purchaseSound);
			float cost = (ingredientPrice * purchaseCount [food]);
			localPlayerData.currentBalance -= cost; // subtract total
			localPlayerData.moneySpent += cost;
			localPlayerData.ingredientsOnHand [food] += purchaseCount [food]; 			// add purchased ingredients to invetory
			purchaseCount [food] = 0;
			GlobalControl.Instance.savedPlayerData = localPlayerData;
		}
	}

	public void incrementCount(string food)
	{
		SoundManager.instance.PlaySingle (buttonSound);
		if (food == "Bread" || food == "Soda")
			purchaseCount [food] += breadIncrement;
		else
			purchaseCount [food] += fillingIncrement;
	}

	public void decrementCount(string food)
	{
		SoundManager.instance.PlaySingle (buttonSound);
		if (food == "Bread" || food == "Soda") {
			if (purchaseCount[food] >= breadIncrement) purchaseCount [food] -= breadIncrement;
		} else {
			if (purchaseCount[food] >= fillingIncrement) purchaseCount [food] -= fillingIncrement;
		}
	
	}
}
