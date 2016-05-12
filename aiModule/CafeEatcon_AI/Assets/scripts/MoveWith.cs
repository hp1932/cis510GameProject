using UnityEngine;
using System.Collections;

public class MoveWith : MonoBehaviour {

	public float avgMealCost;
	public float hamSandwichCost;
	public float turkeySandwichCost;
	public float veggieSandwichCost;
	public int PerCustCostY;
	public int PerCustCostX;

	RestaurantStatistics localPlayerData;


	void Start () 

	{ 
		localPlayerData = GlobalControl.Instance.savedPlayerData;
		hamSandwichCost = localPlayerData.dishPrices[localPlayerData.HAM_SANDWICH];
		turkeySandwichCost = localPlayerData.dishPrices[localPlayerData.TURKEY_SANDWICH];
		veggieSandwichCost = localPlayerData.dishPrices[localPlayerData.VEGGIE_SANDWICH];
		avgMealCost = (hamSandwichCost + turkeySandwichCost + veggieSandwichCost) / 3;
		// avgMealCost = Random.Range(18.1f, 0.00f); // this was just for testing before individual item prices were changing - remove later

		// print ("price of ham sandwich: " + hamSandwichCost);
		// print ("price of turkey sandwich: " + turkeySandwichCost);
		// print ("price of veggie sandwich: " + veggieSandwichCost);
		print ("Avg meal cost: " + avgMealCost);

		moveMiddle ();
	
	}

	// 36 total steps from top to bottom of demand line - NEED total of 18 .50 cent steps from top to bottom
	// Top left of demand line X 115 Y 470
	// Bottom right of demand line X 475 Y 290
	// avg>smallestNumber&&avg<largestNumber

	void moveMiddle ()
	{
		if (avgMealCost >= 18.00) // STEP 1 TOP
		{
			PerCustCostX = 115;
			PerCustCostY = 470;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=17.50&&avgMealCost<=17.99) 
		{
			PerCustCostX = 125;
			PerCustCostY = 465;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=17.00&&avgMealCost<=17.49) 
		{
			PerCustCostX = 135;
			PerCustCostY = 460;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=16.50&&avgMealCost<=16.99) 
		{
			PerCustCostX = 145;
			PerCustCostY = 455;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=16.00&&avgMealCost<=16.49) // 5
		{
			PerCustCostX = 155;
			PerCustCostY = 450;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=15.50&&avgMealCost<=15.99) 
		{
			PerCustCostX = 165;
			PerCustCostY = 445;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=15.00&&avgMealCost<=15.49) 
		{
			PerCustCostX = 175;
			PerCustCostY = 440;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=14.50&&avgMealCost<=14.99) 
		{
			PerCustCostX = 185;
			PerCustCostY = 435;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=14.00&&avgMealCost<=14.49) 
		{
			PerCustCostX = 195;
			PerCustCostY = 430;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=13.50&&avgMealCost<=13.99) // 10
		{
			PerCustCostX = 205;
			PerCustCostY = 425;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=13.00&&avgMealCost<=13.49) 
		{
			PerCustCostX = 215;
			PerCustCostY = 420;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=12.50&&avgMealCost<=12.99) 
		{
			PerCustCostX = 225;
			PerCustCostY = 415;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=12.00&&avgMealCost<=12.49) 
		{
			PerCustCostX = 235;
			PerCustCostY = 410;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=11.50&&avgMealCost<=11.99) 
		{
			PerCustCostX = 245;
			PerCustCostY = 405;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=11.00&&avgMealCost<=11.49) //15
		{
			PerCustCostX = 255;
			PerCustCostY = 400;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=10.50&&avgMealCost<=10.99) 
		{
			PerCustCostX = 265;
			PerCustCostY = 395;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=10.00&&avgMealCost<=10.49) 
		{
			PerCustCostX = 275;
			PerCustCostY = 390;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=9.50&&avgMealCost<=9.99) 
		{
			PerCustCostX = 285;
			PerCustCostY = 385;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=9.00&&avgMealCost<=9.49) 
		{
			PerCustCostX = 295;
			PerCustCostY = 380;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=8.50&&avgMealCost<=8.99) // 20
		{
			PerCustCostX = 305;
			PerCustCostY = 375;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=8.00&&avgMealCost<=8.49) 
		{
			PerCustCostX = 315;
			PerCustCostY = 370;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=7.50&&avgMealCost<=7.99) 
		{
			PerCustCostX = 325;
			PerCustCostY = 365;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=7.00&&avgMealCost<=7.49) 
		{
			PerCustCostX = 335;
			PerCustCostY = 360;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=6.50&&avgMealCost<=6.99) 
		{
			PerCustCostX = 345;
			PerCustCostY = 355;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=6.00&&avgMealCost<=6.49) // 25
		{
			PerCustCostX = 355;
			PerCustCostY = 350;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=5.50&&avgMealCost<=5.99) 
		{
			PerCustCostX = 365;
			PerCustCostY = 345;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=5.00&&avgMealCost<=5.49) 
		{
			PerCustCostX = 375;
			PerCustCostY = 340;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=4.50&&avgMealCost<=4.99) 
		{
			PerCustCostX = 385;
			PerCustCostY = 335;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=4.00&&avgMealCost<=4.49) 
		{
			PerCustCostX = 395;
			PerCustCostY = 330;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=3.50&&avgMealCost<=3.99) // 30
		{
			PerCustCostX = 405;
			PerCustCostY = 325;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=3.00&&avgMealCost<=3.49) 
		{
			PerCustCostX = 415;
			PerCustCostY = 320;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=2.50&&avgMealCost<=2.99) 
		{
			PerCustCostX = 425;
			PerCustCostY = 315;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=2.00&&avgMealCost<=2.49) 
		{
			PerCustCostX = 435;
			PerCustCostY = 310;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=1.50&&avgMealCost<=1.99) 
		{
			PerCustCostX = 445;
			PerCustCostY = 305;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=1.00&&avgMealCost<=1.49) 
		{
			PerCustCostX = 455;
			PerCustCostY = 300;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=0.50&&avgMealCost<=0.99) // 36
		{
			PerCustCostX = 465;
			PerCustCostY = 295;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);
		}
		if (avgMealCost>=0.00&&avgMealCost<=0.49) // 36
		{
			PerCustCostX = 475;
			PerCustCostY = 290;
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







	// Below is the increase descrease... ignore for now

	public void CostIncrease()
	{
		if (PerCustCostY <= 465) {
			PerCustCostY = PerCustCostY + 5;
			PerCustCostX = PerCustCostX - 10;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -4);

		}
	}

		public void CostDecrease()
		{
			if (PerCustCostY >= 295)
			{
				PerCustCostY = PerCustCostY - 5;
				PerCustCostX = PerCustCostX + 10;
				transform.position = new Vector3(PerCustCostX, PerCustCostY, -4);

			}


	}

	// Update is called once per frame
	void Update () {



	}

}
