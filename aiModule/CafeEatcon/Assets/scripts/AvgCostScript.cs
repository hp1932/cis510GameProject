using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AvgCostScript : MonoBehaviour {

	public double avgMealCost;
	public double maxCustomers;
	public double potentialCustomers;
	public double potentialIncome;

	public Text printAvgIncome;



	// Use this for initialization
	void Start () {



	}

	// Update is called once per frame
	void Update () {

		GameObject middle = GameObject.Find ("Middle");
		avgMealCost = middle.GetComponent<MoveWith> ().avgMealCost;
		maxCustomers = middle.GetComponent<MoveWith> ().maxCustomers;
		potentialCustomers = middle.GetComponent<MoveWith> ().potentialCustomers;
		potentialIncome = potentialCustomers * avgMealCost;




	}

	void OnGUI ()
	{
		printAvgIncome.text = "Potential Profit: $ " + potentialIncome.ToString("#.00");


	}

}
