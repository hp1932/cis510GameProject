using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PurchaseController : MonoBehaviour {

	public RestaurantStatistics localPlayerData;

	public Text breadCount_Text;
	public Text turkeyCount_Text;
	public Text hamCount_Text;
	public Text veggieCount_Text;

	
	void Start () {

		localPlayerData = GlobalControl.Instance.savedPlayerData;

		breadCount_Text.text = localPlayerData.ingredientsOnHand ["Bread"].ToString();
		turkeyCount_Text.text = localPlayerData.ingredientsOnHand ["Turkey"].ToString();
		hamCount_Text.text = localPlayerData.ingredientsOnHand ["Ham"].ToString();
		veggieCount_Text.text = localPlayerData.ingredientsOnHand ["Veggie"].ToString();

	}

}
