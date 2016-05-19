using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveWith : MonoBehaviour {

	public float avgMealCost;
	public float hamSandwichCost;
	public float turkeySandwichCost;
	public float veggieSandwichCost;
	public float PerCustCostX = -8.4f;
	public float PerCustCostY = 14.5f;
	public float PerCustCostXAnchor = -8.4f;
	public float PerCustCostYAnchor = 14.5f;
	public float PerCustCostYMove;
	public float PerCustCostXMove;
	public float yforAvgCostPrint;
	public float guiLabelMultiplier;
	public float middleZPos;
	private double customerSlice;
	private double maxCustomers = 50;
	private double potentialCustomers;
	private double potentialIncome;



	public int yOfGUI;
	public int xOfGUI;

	RestaurantStatistics localPlayerData;


	void Start () 

	{ 
		localPlayerData = GlobalControl.Instance.savedPlayerData;
		hamSandwichCost = localPlayerData.dishPrices[localPlayerData.HAM_SANDWICH];
		turkeySandwichCost = localPlayerData.dishPrices[localPlayerData.TURKEY_SANDWICH];
		veggieSandwichCost = localPlayerData.dishPrices[localPlayerData.VEGGIE_SANDWICH];
		avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;

		moveMiddle ();


	}

	// Top left of demand line X -8.4 Y 14.5
	// Bottom right of demand line X 475 Y 290
	// avg>smallestNumber&&avg<largestNumber

	void moveMiddle ()
	{
		if (avgMealCost >= 18.00) // STEP 1 TOP
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 0f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 0f;
			customerSlice = 0.00;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=17.50&&avgMealCost<=17.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * .25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * .25f;
			customerSlice = 0.03;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=17.00&&avgMealCost<=17.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * .50f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * .50f;
			customerSlice = 0.06;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=16.50&&avgMealCost<=16.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * .75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * .75f;
			customerSlice = 0.09;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=16.00&&avgMealCost<=16.49) // 5
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 1f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 1f;
			customerSlice = 0.13;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=15.50&&avgMealCost<=15.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 1.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 1.25f;
			customerSlice = 0.16;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=15.00&&avgMealCost<=15.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 1.50f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 1.50f;
			customerSlice = 0.19;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=14.50&&avgMealCost<=14.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 1.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 1.75f;
			customerSlice = 0.22;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=14.00&&avgMealCost<=14.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 2f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 2f;
			customerSlice = 0.24;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=13.50&&avgMealCost<=13.99) // 10
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 2.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 2.25f;
			customerSlice = 0.27;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=13.00&&avgMealCost<=13.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 2.5f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 2.5f;
			customerSlice = 0.30;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=12.50&&avgMealCost<=12.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 2.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 2.75f;
			customerSlice = 0.32;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=12.00&&avgMealCost<=12.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 3f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 3f;
			customerSlice = 0.35;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=11.50&&avgMealCost<=11.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 3.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 3.25f;
			customerSlice = 0.38;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=11.00&&avgMealCost<=11.49) //15
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 3.5f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 3.5f;
			customerSlice = 0.41;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=10.50&&avgMealCost<=10.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 3.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 3.75f;
			customerSlice = 0.43;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=10.00&&avgMealCost<=10.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 4f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 4f;
			customerSlice = 0.46;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=9.50&&avgMealCost<=9.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 4.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 4.25f;
			customerSlice = 0.49;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=9.00&&avgMealCost<=9.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 4.5f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 4.5f;
			customerSlice = 0.51;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=8.50&&avgMealCost<=8.99) // 20
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 4.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 4.75f;
			customerSlice = 0.54;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=8.00&&avgMealCost<=8.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 5f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 5f;
			customerSlice = 0.57;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=7.50&&avgMealCost<=7.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 5.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 5.25f;
			customerSlice = 0.59;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=7.00&&avgMealCost<=7.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 5.5f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 5.5f;
			customerSlice = 0.62;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=6.50&&avgMealCost<=6.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 5.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 5.75f;
			customerSlice = 0.65;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=6.00&&avgMealCost<=6.49) // 25
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 6f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 6f;
			customerSlice = 0.68;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=5.50&&avgMealCost<=5.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 6.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 6.25f;
			customerSlice = 0.70;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=5.00&&avgMealCost<=5.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 6.5f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 6.5f;
			customerSlice = 0.73;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=4.50&&avgMealCost<=4.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 6.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 6.75f;
			customerSlice = 0.76;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=4.00&&avgMealCost<=4.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 7f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 7f;
			customerSlice = 0.78;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=3.50&&avgMealCost<=3.99) // 30
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 7.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 7.25f;
			customerSlice = 0.81;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=3.00&&avgMealCost<=3.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 7.50f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 7.50f;
			customerSlice = 0.84;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=2.50&&avgMealCost<=2.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 7.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 7.75f;
			customerSlice = 0.86;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=2.00&&avgMealCost<=2.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 8f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 8f;
			customerSlice = 0.89;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=1.50&&avgMealCost<=1.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 8.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 8.25f;
			customerSlice = 0.92;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=1.00&&avgMealCost<=1.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 8.5f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 8.5f;
			customerSlice = 0.95;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=0.50&&avgMealCost<=0.99) // 36
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 8.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 8.75f;
			customerSlice = 0.97;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}
		if (avgMealCost>=0.00&&avgMealCost<=0.49) // 37
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 9f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 9f;
			customerSlice = 1.00;
			potentialCustomers = maxCustomers * customerSlice;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, middleZPos);
		}

		yforAvgCostPrint = PerCustCostY;
	}

	public void hamUP() 
	{
		if (hamSandwichCost <= 17.50) {
			hamSandwichCost = hamSandwichCost + .50f;
			avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;

			moveMiddle ();

		}
	}

	public void hamDOWN() 
	{
		if (hamSandwichCost >= 0.50) {
			hamSandwichCost = hamSandwichCost - .50f;
			avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;

			moveMiddle ();

		}
	}
	public void turkeyUP() 
	{
		if (turkeySandwichCost <= 17.50) {
			turkeySandwichCost = turkeySandwichCost + .50f;
			avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;

			moveMiddle ();

		}
	}

	public void turkeyDOWN() 
	{
		if (turkeySandwichCost >= 0.50) {
			turkeySandwichCost = turkeySandwichCost - .50f;
			avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;

			moveMiddle ();

		}
	}
	public void veggieUP() 
	{
		if (veggieSandwichCost <= 17.50) {
			veggieSandwichCost = veggieSandwichCost + .50f;
			avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;

			moveMiddle ();

		}
	}

	public void veggieDOWN() 
	{
		if (veggieSandwichCost >= 0.50) {
			veggieSandwichCost = veggieSandwichCost - .50f;
			avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;


			moveMiddle ();

		}
	}
	// Update is called once per frame
	void Update () {

		potentialIncome = potentialCustomers * avgMealCost;

	}

	void OnGUI ()
	{

		GUI.color = Color.black;
		GUI.Label (new Rect (40, 105, 308, 20), "Potential Total Next Day Sales: $ " + potentialIncome.ToString("#.00"));
		GUI.color = Color.red;
		GUI.Label(new Rect(xOfGUI,yOfGUI,200,20), "Price of Ham Sandwich: $ " + hamSandwichCost.ToString());
		GUI.Label(new Rect(xOfGUI,yOfGUI + 25,200,20), "Price of Turkey Sandwich: $ " + turkeySandwichCost.ToString());
		GUI.Label(new Rect(xOfGUI,yOfGUI + 50,200,20), "Price of Veggie Sandwich: $ " + veggieSandwichCost.ToString());
		GUI.Label(new Rect(xOfGUI,yOfGUI - 25,200,20), "Average Meal Cost: $ ");
		GUI.Label(new Rect(xOfGUI + 130,yOfGUI - 25,30,20), avgMealCost.ToString());
		GUI.Label(new Rect(23, 435 - (PerCustCostY * guiLabelMultiplier), 35, 20), "$" + avgMealCost.ToString()); // Not sure why PerCustCostY is not working on its own here...
		GUI.Label (new Rect (200 + (PerCustCostX * guiLabelMultiplier), 373, 40, 20), potentialCustomers.ToString ()); // Not sure why PerCustCostX is not working on its own here either...

	}


	public void finalSubmit ()
	{
		if (avgMealCost >=0.50){
			localPlayerData.dishPrices[localPlayerData.HAM_SANDWICH] = hamSandwichCost;
			localPlayerData.dishPrices[localPlayerData.TURKEY_SANDWICH] = turkeySandwichCost;
			localPlayerData.dishPrices[localPlayerData.VEGGIE_SANDWICH] = veggieSandwichCost;
			GlobalControl.Instance.savedPlayerData = localPlayerData;
			SceneManager.LoadScene ("phase2");
			print ("Well, that might have worked");


			// **** NEED COMMAND TO SWTICH SCENES HERE ****
		}
	}

	// From Adam's button controller

	// public void SwitchToScene(string scene)
	// {
	// 	SceneManager.LoadScene (scene);
	// }
	//
	// public void SwitchToSimulation()
	// {
	// 	SceneManager.LoadScene ("phase1");
	// 	GlobalControl.Instance.savedPlayerData.ResetValuesForPhase1 ();
	// }
}
