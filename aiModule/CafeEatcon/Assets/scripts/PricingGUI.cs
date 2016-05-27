using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PricingGUI : MonoBehaviour {

	public float avgMealCost;
	public float hamSandwichCost;
	public float turkeySandwichCost;
	public float veggieSandwichCost;
	public double maxCustomers;
	public double potentialCustomers;
	public double potentialIncome;
	public float xofGUI;
	public float yofGUI;
	public Text printHamSandwich;
	public Text printTurkeySandwich;
	public Text printVeggieSandwich;


	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		GameObject middle = GameObject.Find ("Middle");
		// avgMealCost = middle.GetComponent<MoveWith> ().avgMealCost;
		maxCustomers = middle.GetComponent<MoveWith> ().maxCustomers;
		hamSandwichCost = middle.GetComponent<MoveWith> ().hamSandwichCost;
		turkeySandwichCost = middle.GetComponent<MoveWith> ().turkeySandwichCost;
		veggieSandwichCost = middle.GetComponent<MoveWith> ().veggieSandwichCost;

	
	}

	void OnGUI ()
	{

		GUI.color = Color.black;
		// GUI.Label (new Rect (40, 105, 308, 20), "Potential Total Next Day Sales: $ " + potentialIncome.ToString("#.00"));
		GUI.color = Color.red;
		GUI.Label(new Rect(xofGUI,yofGUI - 25,200,20), "Average Meal Cost: $ ");
		GUI.Label(new Rect(xofGUI + 130,yofGUI - 25,30,20), avgMealCost.ToString());
		//GUI.Label(new Rect(23, 435 - (PerCustCostY * guiLabelMultiplier), 35, 20), "$" + avgMealCost.ToString()); // Not sure why PerCustCostY is not working on its own here...
		//GUI.Label (new Rect (200 + (PerCustCostX * guiLabelMultiplier), 373, 40, 20), potentialCustomers.ToString ()); // Not sure why PerCustCostX is not working on its own here either...
		printHamSandwich.text = "Ham Sandwich      $" + hamSandwichCost.ToString("#.00");
		printTurkeySandwich.text = "Turkey Sandwich    $" + turkeySandwichCost.ToString("#.00");
		printVeggieSandwich.text = "Veggie Sandwich    $" + veggieSandwichCost.ToString("#.00");

	}

}
