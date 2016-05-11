using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PurchaseController : MonoBehaviour {

	public RestaurantStatistics localPlayerData;

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

	private int breadPrice;
	private int breadCount;

	void Start () {

		localPlayerData = GlobalControl.Instance.savedPlayerData;

	}

	void Update()
	{
		breadStock_Text.text 	= localPlayerData.ingredientsOnHand ["Bread"].ToString();
		turkeyStock_Text.text 	= localPlayerData.ingredientsOnHand ["Turkey"].ToString();
		hamStock_Text.text 		= localPlayerData.ingredientsOnHand ["Ham"].ToString();
		veggieStock_Text.text 	= localPlayerData.ingredientsOnHand ["Veggie"].ToString();


	}

}
