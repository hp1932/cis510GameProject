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

		// print ("price of ham sandwich: " + hamSandwichCost);
		// print ("price of turkey sandwich: " + turkeySandwichCost);
		// print ("price of veggie sandwich: " + veggieSandwichCost);
		print ("Avg meal cost: " + avgMealCost);

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
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=17.50&&avgMealCost<=17.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * .25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * .25f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=17.00&&avgMealCost<=17.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * .50f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * .50f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=16.50&&avgMealCost<=16.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * .75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * .75f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=16.00&&avgMealCost<=16.49) // 5
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 1f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 1f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=15.50&&avgMealCost<=15.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 1.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 1.25f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=15.00&&avgMealCost<=15.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 1.50f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 1.50f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=14.50&&avgMealCost<=14.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 1.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 1.75f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=14.00&&avgMealCost<=14.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 2f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 2f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=13.50&&avgMealCost<=13.99) // 10
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 2.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 2.25f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=13.00&&avgMealCost<=13.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 2.5f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 2.5f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=12.50&&avgMealCost<=12.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 2.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 2.75f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=12.00&&avgMealCost<=12.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 3f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 3f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=11.50&&avgMealCost<=11.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 3.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 3.25f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=11.00&&avgMealCost<=11.49) //15
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 3.5f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 3.5f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=10.50&&avgMealCost<=10.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 3.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 3.75f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=10.00&&avgMealCost<=10.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 4f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 4f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=9.50&&avgMealCost<=9.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 4.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 4.25f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=9.00&&avgMealCost<=9.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 4.5f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 4.5f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=8.50&&avgMealCost<=8.99) // 20
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 4.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 4.75f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=8.00&&avgMealCost<=8.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 5f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 5f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=7.50&&avgMealCost<=7.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 5.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 5.25f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=7.00&&avgMealCost<=7.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 5.5f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 5.5f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=6.50&&avgMealCost<=6.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 5.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 5.75f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=6.00&&avgMealCost<=6.49) // 25
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 6f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 6f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=5.50&&avgMealCost<=5.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 6.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 6.25f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=5.00&&avgMealCost<=5.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 6.5f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 6.5f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=4.50&&avgMealCost<=4.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 6.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 6.75f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=4.00&&avgMealCost<=4.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 7f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 7f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=3.50&&avgMealCost<=3.99) // 30
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 7.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 7.25f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=3.00&&avgMealCost<=3.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 7.50f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 7.50f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=2.50&&avgMealCost<=2.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 7.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 7.75f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=2.00&&avgMealCost<=2.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 8f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 8f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=1.50&&avgMealCost<=1.99) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 8.25f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 8.25f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=1.00&&avgMealCost<=1.49) 
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 8.5f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 8.5f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=0.50&&avgMealCost<=0.99) // 36
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 8.75f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 8.75f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=0.00&&avgMealCost<=0.49) // 36
		{
			PerCustCostX = PerCustCostXAnchor + PerCustCostXMove * 9f;
			PerCustCostY = PerCustCostYAnchor - PerCustCostYMove * 9f;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
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



	}

	void OnGUI ()
	{
		GUI.color = Color.red;
		GUI.Label(new Rect(xOfGUI,yOfGUI,200,20), "Price of Ham Sandwich: " + hamSandwichCost.ToString()); // x 185 y 93
		GUI.Label(new Rect(xOfGUI,yOfGUI + 30,200,20), "Price of Turkey Sandwich: " + turkeySandwichCost.ToString()); // x 185
		GUI.Label(new Rect(xOfGUI,yOfGUI + 60,200,20), "Price of Veggie Sandwich: " + veggieSandwichCost.ToString()); // x 185
		GUI.Label(new Rect(xOfGUI,yOfGUI - 30,200,20), "Average Meal Cost: " + avgMealCost.ToString()); // x 185


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
