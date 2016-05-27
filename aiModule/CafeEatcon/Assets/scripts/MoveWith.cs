using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveWith : MonoBehaviour {

	public double avgMealCost;
	public float hamSandwichCost;
	public float turkeySandwichCost;
	public float veggieSandwichCost;
	public double PerCustCostX;
	public double PerCustCostY;
	public float PerCustCostXAnchor = -10;
	public float PerCustCostYAnchor = 15;
	public double PerCustCostYMove = .50;
	public double PerCustCostXMove = .75;
	public float yforAvgCostPrint;
	public float guiLabelMultiplier;
	public float middleZPos;
	public double customerSlice;
	public float maxCustomers;
	public double potentialCustomers; // can this be public
	//double potentialIncome;
	public float startYAnchor;
	public float startXAnchor;
	float yVal;
	float priceincrease;
	float maxSandwichPrice;
	float menuMinus; //The small fraction off each max and min to calculate correctly when rounding

	public float destX;
	public float destY;
	public float destZ;
	public bool dualDemandCurve;


	public int yOfGUI;
	public int xOfGUI;

	public float xTransform;
	public float yTransform;

	RestaurantStatistics localPlayerData;


	void Start () 

	{ 
		localPlayerData = GlobalControl.Instance.savedPlayerData;

		GameObject Destination = GameObject.Find ("Destination");
		hamSandwichCost = localPlayerData.dishPrices[localPlayerData.HAM_SANDWICH];
		turkeySandwichCost = localPlayerData.dishPrices[localPlayerData.TURKEY_SANDWICH];
		veggieSandwichCost = localPlayerData.dishPrices[localPlayerData.VEGGIE_SANDWICH];
		// implementing line render move below

		dualDemandCurve = localPlayerData.dualDemandCurve;
		// dualDemandCurve = true; // for testing only
		if (dualDemandCurve == true) 
		{
			PerCustCostXAnchor = -10 + 2;
		}

		if (dualDemandCurve == false) 
		{
			PerCustCostXAnchor = -10;
		}

		// hamSandwichCost = 3.30f; // This is just for testing!
		// turkeySandwichCost = 3.30f; // This is just for testing!
		// veggieSandwichCost = 3.00f; // This is just for testing!
		avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;
		PerCustCostYMove = .50;
		PerCustCostXMove = .75;
		Vector3 point = Camera.main.WorldToScreenPoint (transform.position);
		startYAnchor = point.y;
		startXAnchor = point.x;
		maxCustomers = localPlayerData.maxCustomers;
		// maxCustomers = 40; // This is just for testing!

		destX = Destination.GetComponent<destinationMove> ().destX;
		destY = Destination.GetComponent<destinationMove> ().destY;
		destZ = Destination.GetComponent<destinationMove> ().destZ;
		print (maxCustomers);
		print (dualDemandCurve);

		moveMiddle ();
		priceUp ();


	}

	void moveMiddle ()
	{
		// LEVEL ONE BELOW - 40 MAX CUSTOMERS ===========================================================================

		if (maxCustomers <= 59) {

			if (avgMealCost >= 6.00) // STARTING STEP 00
			{ 
				PerCustCostX = PerCustCostXAnchor + 0;
				PerCustCostY = PerCustCostYAnchor - 0;
				customerSlice = 0.05;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}

			if (avgMealCost <6.00&&avgMealCost>=5.70) // 01
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 1);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 1);
				customerSlice = 0.1;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <5.70&&avgMealCost>=5.40) // 02
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 2);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 2);
				customerSlice = 0.15;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <5.40&&avgMealCost>=5.10) // 03
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 3);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 3);
				customerSlice = 0.2;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <5.10&&avgMealCost>=4.80) // 04
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 4);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 4);
				customerSlice = 0.25;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <4.80&&avgMealCost>=4.50) // 05
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 5);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 5);
				customerSlice = 0.3;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <4.50&&avgMealCost>=4.20) // 06
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 6);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 6);
				customerSlice = 0.35;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <4.20&&avgMealCost>=3.90) // 07
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 7);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 7);
				customerSlice = 0.4;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <3.90&&avgMealCost>=3.60) // 08
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 8);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 8);
				customerSlice = 0.45;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <3.60&&avgMealCost>=3.30) // 09
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 9);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 9);
				customerSlice = 0.50;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <3.30&&avgMealCost>=3.00) // 10
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 10);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 10);
				customerSlice = 0.55;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <3.00&&avgMealCost>=2.70) // 11
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 11);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 11);
				customerSlice = 0.55;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <2.70&&avgMealCost>=2.40) // 12
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 12);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 12);
				customerSlice = 0.60;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <2.40&&avgMealCost>=2.10) // 13
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 13);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 13);
				customerSlice = 0.65;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <2.10&&avgMealCost>=1.80) // 14
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 14);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 14);
				customerSlice = 0.70;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <1.80&&avgMealCost>=1.50) // 15
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 15);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 15);
				customerSlice = 0.75;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <1.50&&avgMealCost>=1.20) // 16
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 16);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 16);
				customerSlice = 0.80;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <1.20&&avgMealCost>=0.90) // 17
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 17);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 17);
				customerSlice = 0.85;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <0.90&&avgMealCost>=0.60) // 18
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 18);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 18);
				customerSlice = 0.90;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <0.60&&avgMealCost>=0.30) // 19
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 19);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 19);
				customerSlice = 0.95;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <0.30&&avgMealCost>=0.00) // 20
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 20);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 20);
				customerSlice = 1.00;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
		}

		// BELOW - Level TWO maxCustomers 60 ===========================================================================

		if (maxCustomers >= 60 && maxCustomers <= 79) {

			if (avgMealCost >= 8.00) { // STARTING STEP 00
				PerCustCostX = PerCustCostXAnchor + 0;
				PerCustCostY = PerCustCostYAnchor - 0;
				customerSlice = 0.05;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}

			if (avgMealCost < 8.00 && avgMealCost >= 7.60) { // 01
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 1);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 1);
				customerSlice = 0.1;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 7.60 && avgMealCost >= 7.20) { // 02
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 2);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 2);
				customerSlice = 0.15;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 7.20 && avgMealCost >= 6.80) { // 03
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 3);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 3);
				customerSlice = 0.2;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 6.80 && avgMealCost >= 6.40) { // 04
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 4);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 4);
				customerSlice = 0.25;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 6.40 && avgMealCost >= 6.00) { // 05
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 5);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 5);
				customerSlice = 0.3;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 6.00 && avgMealCost >= 5.60) { // 06
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 6);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 6);
				customerSlice = 0.35;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 5.60 && avgMealCost >= 5.20) { // 07
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 7);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 7);
				customerSlice = 0.4;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 5.20 && avgMealCost >= 4.80) { // 08
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 8);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 8);
				customerSlice = 0.45;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 4.80 && avgMealCost >= 4.40) { // 09
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 9);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 9);
				customerSlice = 0.50;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 4.40 && avgMealCost >= 4.00) { // 10
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 10);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 10);
				customerSlice = 0.55;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 4.00 && avgMealCost >= 3.60) { // 11
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 11);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 11);
				customerSlice = 0.55;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 3.60 && avgMealCost >= 3.20) { // 12
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 12);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 12);
				customerSlice = 0.60;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 3.20 && avgMealCost >= 2.80) { // 13
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 13);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 13);
				customerSlice = 0.65;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 2.80 && avgMealCost >= 2.40) { // 14
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 14);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 14);
				customerSlice = 0.70;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 2.40 && avgMealCost >= 2.00) { // 15
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 15);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 15);
				customerSlice = 0.75;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 2.00 && avgMealCost >= 1.60) { // 16
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 16);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 16);
				customerSlice = 0.80;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 1.60 && avgMealCost >= 1.20) { // 17
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 17);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 17);
				customerSlice = 0.85;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 1.20 && avgMealCost >= 0.80) { // 18
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 18);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 18);
				customerSlice = 0.90;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 0.80 && avgMealCost >= 0.40) { // 19
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 19);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 19);
				customerSlice = 0.95;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost < 0.40 && avgMealCost >= 0.00) { // 20
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 20);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 20);
				customerSlice = 1.00;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}

		}
		// BELOW - Level THREE maxCustomers 80 ===========================================================================

		if (maxCustomers >= 80 && maxCustomers <= 99) {

			if (avgMealCost >= 10.00) // STARTING STEP 00
			{ 
				PerCustCostX = PerCustCostXAnchor + 0;
				PerCustCostY = PerCustCostYAnchor - 0;
				customerSlice = 0.05;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}

			if (avgMealCost <10.00&&avgMealCost>=9.50) // 01
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 1);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 1);
				customerSlice = 0.1;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <9.50&&avgMealCost>=9.00) // 02
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 2);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 2);
				customerSlice = 0.15;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <9.00&&avgMealCost>=8.50) // 03
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 3);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 3);
				customerSlice = 0.2;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <8.50&&avgMealCost>=8.00) // 04
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 4);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 4);
				customerSlice = 0.25;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <8.00&&avgMealCost>=7.50) // 05
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 5);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 5);
				customerSlice = 0.3;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <7.50&&avgMealCost>=7.00) // 06
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 6);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 6);
				customerSlice = 0.35;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <7.00&&avgMealCost>=6.50) // 07
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 7);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 7);
				customerSlice = 0.4;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <6.50&&avgMealCost>=6.00) // 08
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 8);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 8);
				customerSlice = 0.45;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <6.00&&avgMealCost>=5.50) // 09
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 9);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 9);
				customerSlice = 0.50;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <5.50&&avgMealCost>=5.00) // 10
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 10);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 10);
				customerSlice = 0.55;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <5.00&&avgMealCost>=4.50) // 11
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 11);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 11);
				customerSlice = 0.55;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <4.50&&avgMealCost>=4.00) // 12
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 12);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 12);
				customerSlice = 0.60;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <4.00&&avgMealCost>=3.50) // 13
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 13);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 13);
				customerSlice = 0.65;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <3.50&&avgMealCost>=3.00) // 14
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 14);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 14);
				customerSlice = 0.70;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <3.00&&avgMealCost>=2.50) // 15
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 15);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 15);
				customerSlice = 0.75;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <2.50&&avgMealCost>=2.00) // 16
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 16);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 16);
				customerSlice = 0.80;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <2.00&&avgMealCost>=1.50) // 17
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 17);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 17);
				customerSlice = 0.85;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <1.50&&avgMealCost>=1.00) // 18
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 18);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 18);
				customerSlice = 0.90;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <1.00&&avgMealCost>=0.50) // 19
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 19);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 19);
				customerSlice = 0.95;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <0.50&&avgMealCost>=0.00) // 20
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 20);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 20);
				customerSlice = 1.00;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
		}

		// BELOW - Level FOUR maxCustomers 100 ===========================================================================

		if (maxCustomers >= 100 && maxCustomers <= 119) {

			if (avgMealCost >= 12.00) // STARTING STEP 00
			{ 
				PerCustCostX = PerCustCostXAnchor + 0;
				PerCustCostY = PerCustCostYAnchor - 0;
				customerSlice = 0.05;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}

			if (avgMealCost <12.00&&avgMealCost>=11.40) // 01
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 1);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 1);
				customerSlice = 0.1;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <11.40&&avgMealCost>=10.80) // 02
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 2);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 2);
				customerSlice = 0.15;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <10.80&&avgMealCost>=10.20) // 03
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 3);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 3);
				customerSlice = 0.2;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <10.20&&avgMealCost>=9.60) // 04
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 4);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 4);
				customerSlice = 0.25;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <9.60&&avgMealCost>=9.00) // 05
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 5);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 5);
				customerSlice = 0.3;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <9.00&&avgMealCost>=8.40) // 06
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 6);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 6);
				customerSlice = 0.35;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <8.40&&avgMealCost>=7.80) // 07
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 7);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 7);
				customerSlice = 0.4;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <7.80&&avgMealCost>=7.20) // 08
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 8);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 8);
				customerSlice = 0.45;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <7.20&&avgMealCost>=6.60) // 09
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 9);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 9);
				customerSlice = 0.50;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <6.60&&avgMealCost>=6.00) // 10
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 10);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 10);
				customerSlice = 0.55;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <6.00&&avgMealCost>=5.40) // 11
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 11);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 11);
				customerSlice = 0.55;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <5.40&&avgMealCost>=4.80) // 12
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 12);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 12);
				customerSlice = 0.60;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <4.80&&avgMealCost>=4.20) // 13
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 13);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 13);
				customerSlice = 0.65;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <4.20&&avgMealCost>=3.60) // 14
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 14);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 14);
				customerSlice = 0.70;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <3.60&&avgMealCost>=3.00) // 15
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 15);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 15);
				customerSlice = 0.75;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <3.00&&avgMealCost>=2.40) // 16
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 16);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 16);
				customerSlice = 0.80;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <2.40&&avgMealCost>=1.80) // 17
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 17);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 17);
				customerSlice = 0.85;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <1.80&&avgMealCost>=1.20) // 18
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 18);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 18);
				customerSlice = 0.90;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <1.20&&avgMealCost>=0.60) // 19
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 19);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 19);
				customerSlice = 0.95;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <0.60&&avgMealCost>=0.00) // 20
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 20);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 20);
				customerSlice = 1.00;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
		}

		// BELOW - Level FIVE maxCustomers 120 ===========================================================================

		if (maxCustomers >= 120 && maxCustomers <= 139) {

			if (avgMealCost >= 14.00) // STARTING STEP 00
			{ 
				PerCustCostX = PerCustCostXAnchor + 0;
				PerCustCostY = PerCustCostYAnchor - 0;
				customerSlice = 0.05;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}

			if (avgMealCost <14.00&&avgMealCost>=13.30) // 01
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 1);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 1);
				customerSlice = 0.1;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <13.30&&avgMealCost>=12.60) // 02
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 2);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 2);
				customerSlice = 0.15;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <12.60&&avgMealCost>=11.90) // 03
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 3);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 3);
				customerSlice = 0.2;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <11.90&&avgMealCost>=11.20) // 04
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 4);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 4);
				customerSlice = 0.25;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <11.20&&avgMealCost>=10.50) // 05
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 5);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 5);
				customerSlice = 0.3;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <10.50&&avgMealCost>=9.80) // 06
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 6);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 6);
				customerSlice = 0.35;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <9.80&&avgMealCost>=9.10) // 07
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 7);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 7);
				customerSlice = 0.4;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <9.10&&avgMealCost>=8.40) // 08
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 8);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 8);
				customerSlice = 0.45;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <8.40&&avgMealCost>=7.70) // 09
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 9);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 9);
				customerSlice = 0.50;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <7.70&&avgMealCost>=7.00) // 10
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 10);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 10);
				customerSlice = 0.55;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <7.00&&avgMealCost>=6.30) // 11
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 11);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 11);
				customerSlice = 0.55;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <6.30&&avgMealCost>=5.60) // 12
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 12);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 12);
				customerSlice = 0.60;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <5.60&&avgMealCost>=4.90) // 13
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 13);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 13);
				customerSlice = 0.65;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <4.90&&avgMealCost>=4.20) // 14
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 14);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 14);
				customerSlice = 0.70;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <4.20&&avgMealCost>=3.50) // 15
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 15);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 15);
				customerSlice = 0.75;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <3.50&&avgMealCost>=2.80) // 16
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 16);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 16);
				customerSlice = 0.80;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <2.80&&avgMealCost>=2.10) // 17
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 17);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 17);
				customerSlice = 0.85;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <2.10&&avgMealCost>=1.40) // 18
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 18);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 18);
				customerSlice = 0.90;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <1.40&&avgMealCost>=0.70) // 19
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 19);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 19);
				customerSlice = 0.95;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <0.70&&avgMealCost>=0.00) // 20
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 20);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 20);
				customerSlice = 1.00;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
		}

		// BELOW - Level SIX maxCustomers 140 ===========================================================================

		if (maxCustomers >=140 && maxCustomers <=159) {

			if (avgMealCost >= 16.00) // STARTING STEP 00
			{ 
				PerCustCostX = PerCustCostXAnchor + 0;
				PerCustCostY = PerCustCostYAnchor - 0;
				customerSlice = 0.05;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}

			if (avgMealCost <16.00&&avgMealCost>=15.20) // 01
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 1);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 1);
				customerSlice = 0.1;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <15.20&&avgMealCost>=14.40) // 02
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 2);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 2);
				customerSlice = 0.15;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <14.40&&avgMealCost>=13.60) // 03
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 3);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 3);
				customerSlice = 0.2;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <13.60&&avgMealCost>=12.80) // 04
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 4);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 4);
				customerSlice = 0.25;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <12.80&&avgMealCost>=12.00) // 05
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 5);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 5);
				customerSlice = 0.3;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <12.00&&avgMealCost>=11.20) // 06
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 6);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 6);
				customerSlice = 0.35;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <11.20&&avgMealCost>=10.40) // 07
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 7);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 7);
				customerSlice = 0.4;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <10.40&&avgMealCost>=9.60) // 08
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 8);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 8);
				customerSlice = 0.45;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <9.60&&avgMealCost>=8.80) // 09
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 9);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 9);
				customerSlice = 0.50;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <8.80&&avgMealCost>=8.00) // 10
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 10);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 10);
				customerSlice = 0.55;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <8.00&&avgMealCost>=7.20) // 11
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 11);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 11);
				customerSlice = 0.55;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <7.20&&avgMealCost>=6.40) // 12
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 12);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 12);
				customerSlice = 0.60;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <6.40&&avgMealCost>=5.60) // 13
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 13);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 13);
				customerSlice = 0.65;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <5.60&&avgMealCost>=4.80) // 14
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 14);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 14);
				customerSlice = 0.70;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <4.80&&avgMealCost>=4.00) // 15
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 15);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 15);
				customerSlice = 0.75;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <4.00&&avgMealCost>=3.20) // 16
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 16);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 16);
				customerSlice = 0.80;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <3.20&&avgMealCost>=2.40) // 17
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 17);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 17);
				customerSlice = 0.85;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <2.40&&avgMealCost>=1.60) // 18
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 18);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 18);
				customerSlice = 0.90;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <1.60&&avgMealCost>=0.80) // 19
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 19);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 19);
				customerSlice = 0.95;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <0.80&&avgMealCost>=0.00) // 20
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 20);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 20);
				customerSlice = 1.00;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
		}

		// BELOW - Level SEVEN maxCustomers 160 ===========================================================================

		if (maxCustomers >= 160) {

			if (avgMealCost >= 18.00) // STARTING STEP 00
			{ 
				PerCustCostX = PerCustCostXAnchor + 0;
				PerCustCostY = PerCustCostYAnchor - 0;
				customerSlice = 0.05;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}

			if (avgMealCost <18.00&&avgMealCost>=17.10) // 01
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 1);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 1);
				customerSlice = 0.1;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <17.10&&avgMealCost>=16.20) // 02
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 2);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 2);
				customerSlice = 0.15;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <16.20&&avgMealCost>=15.30) // 03
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 3);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 3);
				customerSlice = 0.2;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <15.30&&avgMealCost>=14.40) // 04
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 4);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 4);
				customerSlice = 0.25;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <14.40&&avgMealCost>=13.50) // 05
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 5);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 5);
				customerSlice = 0.3;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <13.50&&avgMealCost>=12.60) // 06
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 6);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 6);
				customerSlice = 0.35;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <12.60&&avgMealCost>=11.70) // 07
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 7);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 7);
				customerSlice = 0.4;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <11.70&&avgMealCost>=10.80) // 08
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 8);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 8);
				customerSlice = 0.45;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <10.80&&avgMealCost>=9.90) // 09
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 9);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 9);
				customerSlice = 0.50;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <9.90&&avgMealCost>=9.00) // 10
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 10);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 10);
				customerSlice = 0.55;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <9.00&&avgMealCost>=8.10) // 11
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 11);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 11);
				customerSlice = 0.55;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <8.10&&avgMealCost>=7.20) // 12
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 12);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 12);
				customerSlice = 0.60;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <7.20&&avgMealCost>=6.30) // 13
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 13);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 13);
				customerSlice = 0.65;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <6.30&&avgMealCost>=5.40) // 14
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 14);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 14);
				customerSlice = 0.70;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <5.40&&avgMealCost>=4.50) // 15
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 15);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 15);
				customerSlice = 0.75;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <4.50&&avgMealCost>=3.60) // 16
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 16);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 16);
				customerSlice = 0.80;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <3.60&&avgMealCost>=2.70) // 17
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 17);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 17);
				customerSlice = 0.85;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <2.70&&avgMealCost>=1.80) // 18
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 18);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 18);
				customerSlice = 0.90;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <1.80&&avgMealCost>=0.90) // 19
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 19);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 19);
				customerSlice = 0.95;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
			if (avgMealCost <0.90&&avgMealCost>=0.00) // 20
			{ 
				PerCustCostX = PerCustCostXAnchor + (PerCustCostXMove * 20);
				PerCustCostY = PerCustCostYAnchor - (PerCustCostYMove * 20);
				customerSlice = 1.00;
				potentialCustomers = maxCustomers * customerSlice;
				xTransform = (float)PerCustCostX;
				yTransform = (float)PerCustCostY;
				transform.position = new Vector3 (xTransform, yTransform, middleZPos);
			}
		}
		// yforAvgCostPrint = PerCustCostY;
	}

	public void priceUp()

	{
		if (maxCustomers <= 59)
		{
			priceincrease = .30f;
			maxSandwichPrice = 6f;
			menuMinus = .001f;
		}
		if (maxCustomers >= 60 && maxCustomers <= 79)
		{
			priceincrease = .40f;
			maxSandwichPrice = 8f;
			menuMinus = .001f;
		}
		if (maxCustomers >= 80 && maxCustomers <= 99)
		{
			priceincrease = .50f;
			maxSandwichPrice = 10f;
			menuMinus = .001f;
		}
		if (maxCustomers >= 100 && maxCustomers <= 119)
		{
			priceincrease = .60f;
			maxSandwichPrice = 12f;
			menuMinus = .001f;

		}
		if (maxCustomers >= 120 && maxCustomers <= 139)
		{
			priceincrease = .70f;
			maxSandwichPrice = 14f;
			menuMinus = .001f;
		}
		if (maxCustomers >=140 && maxCustomers <=159)
		{
			priceincrease = .80f;
			maxSandwichPrice = 16f;
			menuMinus = .001f;
		}
		if (maxCustomers >= 160)
		{
			priceincrease = .90f;
			maxSandwichPrice = 18f;
			menuMinus = .001f;
		}
	}


	public void hamUP() 
	{
		priceUp ();

		if (hamSandwichCost <= maxSandwichPrice - menuMinus) {
			hamSandwichCost = hamSandwichCost + priceincrease;
			avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;

			moveMiddle ();
		}

	}

	public void hamDOWN() 
	{
		if (hamSandwichCost >= priceincrease - menuMinus) {
			hamSandwichCost = hamSandwichCost - priceincrease;
			avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;

			moveMiddle ();
		}
	}
	public void turkeyUP() 
	{
		if (turkeySandwichCost <= maxSandwichPrice - menuMinus) {
			turkeySandwichCost = turkeySandwichCost + priceincrease;
			avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;

			moveMiddle ();

		}
	}

	public void turkeyDOWN() 
	{
		if (turkeySandwichCost >= priceincrease - menuMinus) {
			turkeySandwichCost = turkeySandwichCost - priceincrease;
			avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;

			moveMiddle ();

		}
	}

	public void veggieUP() 
	{
		if (veggieSandwichCost <= maxSandwichPrice - menuMinus) {
			veggieSandwichCost = veggieSandwichCost + priceincrease;
			avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;

			moveMiddle ();

		}
	}

	public void veggieDOWN() 
	{
		if (veggieSandwichCost >= priceincrease - menuMinus) {
			veggieSandwichCost = veggieSandwichCost - priceincrease;
			avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;


			moveMiddle ();

		}
	}
	// Update is called once per frame
	void Update () {

		//potentialIncome = potentialCustomers * avgMealCost;

	}

	void OnGUI ()
	{
		// 
		// 	GUI.color = Color.black;
		//	GUI.Label (new Rect (40, 105, 308, 20), "Potential Total Next Day Sales: $ " + potentialIncome.ToString("#.00"));
		GUI.color = Color.red;
		// 	GUI.Label(new Rect(xOfGUI,yOfGUI,200,20), "Price of Ham Sandwich: $ " + hamSandwichCost.ToString());
		// 	GUI.Label(new Rect(xOfGUI,yOfGUI + 25,200,20), "Price of Turkey Sandwich: $ " + turkeySandwichCost.ToString());
		// 	GUI.Label(new Rect(xOfGUI,yOfGUI + 50,200,20), "Price of Veggie Sandwich: $ " + veggieSandwichCost.ToString());
		// 	GUI.Label(new Rect(xOfGUI,yOfGUI - 25,200,20), "Average Meal Cost: $ ");
		// 	GUI.Label(new Rect(xOfGUI + 130,yOfGUI - 25,30,20), avgMealCost.ToString());


		Vector3 point = Camera.main.WorldToScreenPoint (transform.position);
		yVal = Screen.height - point.y - 20;
		GUI.Label (new Rect (startXAnchor - 35, yVal + 9, 35, 20), "$" + avgMealCost.ToString());
		GUI.Label (new Rect (point.x - 5, startYAnchor - 40, 40, 20), potentialCustomers.ToString ());

	}


	public void finalSubmit ()
	{
		if (avgMealCost >=0.50){
			localPlayerData.dishPrices[localPlayerData.HAM_SANDWICH] = hamSandwichCost;
			localPlayerData.dishPrices[localPlayerData.TURKEY_SANDWICH] = turkeySandwichCost;
			localPlayerData.dishPrices[localPlayerData.VEGGIE_SANDWICH] = veggieSandwichCost;
			localPlayerData.updateAveragePrice ();
			GlobalControl.Instance.savedPlayerData = localPlayerData;
			SceneManager.LoadScene ("phase2");

		}
	}

}
