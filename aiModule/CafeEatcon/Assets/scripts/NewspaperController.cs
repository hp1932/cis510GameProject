using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NewspaperController : MonoBehaviour {

	public RestaurantStatistics localPlayerData;

	private Dictionary<int,string> economyStories;
	private Dictionary<int,string> normalStories;
	private float econStoryRate;

	public Text newsText;
	public Text dayText;
	public Text ratingText;
	public Text achievementText;
	public Text achievementNumber;

	private float acheivementProgress;
	private float acheivementProgressRemaining;
	private float restaurantRating;

	// Use this for initialization
	void Start () 
	{
		init ();
	}

	public void init()
	{
		localPlayerData = GlobalControl.Instance.savedPlayerData;

		economyStories = new Dictionary<int, string> ();
		normalStories = new Dictionary<int, string> ();
		initializeStories();
		econStoryRate = 0.5f;

		dayText.text = "Day " + localPlayerData.currentDay;

		ratingText.text = "";
		restaurantRating = localPlayerData.favorabilityRating;
		while (restaurantRating > 0) {
			ratingText.text += "*";
			restaurantRating -= 0.2f;
		}

		achievementNumber.text = "\"" + localPlayerData.nextCustomerAchievementLevel.ToString() + " Customers Served\"";
		acheivementProgress = localPlayerData.customerAchievementProgress;
		acheivementProgressRemaining = 1.0f - acheivementProgress;
		achievementText.text = "";
		while (acheivementProgress > 0) {
			achievementText.text += "*";
			acheivementProgress -= 0.1f;
		}
		while (acheivementProgressRemaining > 0) {
			achievementText.text += "-";
			acheivementProgressRemaining -= 0.1f;
		}

	}

	private void initializeStories()
	{
		normalStories.Add (0, "In Local Metro News:\nThe metro unemployment report came out showing minimal job growth, and a current unemployment rate at 5.4% - could be worse...");
		normalStories.Add (1, "In Local Metro News:\nThe traffic signals at Main and 3rd Ave have been malfunctioning since yesterday afternoon causing traffic jams and delays downtown today.");
		normalStories.Add (2, "In Local Metro News:\nNew construction has started today at 3rd Ave and Morrison St downtown which will be causing traffic delays at that intersection for the next few weeks.");
		normalStories.Add (3, "In Local Metro News:\n Batboy has returned! Will he help settle the stock market?");
		normalStories.Add (4, "In Sports News:\n The Middle Valley Senior High Football team clinched a playoff berth with a last second hail mary against Easton Prep.");
		normalStories.Add (5, "In Local News:\nThe Middleton Police Academy is looking for new applicants for their dog training division. Contact (555)DOG-COPS for more information.");

		economyStories.Add (0, "In Local Metro News:\nAn alligator has escaped from the Metro Zoo and park area along the riverfront! Avoid the entire downtown area if possible!");
		//economyStories.Add (6, "In Local Metro News:\nLocal poultry farm under investigation for unsanitary working conditions. Many local restaurants using their turkey and chicken products!");
		economyStories.Add (1, "In Local Metro News:\nNational SuperCon comic book convention is coming to the metro area today, expect large crowds in the downtown area all day!");
		economyStories.Add (2, "In Local Metro News:\nLocal MPEU Employees Union today announced an immediate strike today, which will grind metro area work and traffic to a halt today!");
		economyStories.Add (3, "In Local Metro News:\nThe metro area Farmers Market is back for its spring season today, you may want to avoid downtown today because of the thousands of people attending!");
		//economyStories.Add (5, "In Local Metro News:\nThe Downtown Metro Area Vegan Animal Rescue Society is having a pet adoption extravaganza starting at 9am!");
		economyStories.Add (4, "In Local Metro News:\nStarting today and continuing through the weekend is the All Metro Area Homestead and Gardening Conference at Pioneer Square!");
		//economyStories.Add (7, "In Local Metro News:\nThe first local incidents of Hoof and Mouth disease were Recently reported to local health officials. Please be advised this is a continuing story.");
	}	

	public string pickStory()
	{
		float percentRand = Random.Range (0f, 1f);
		string retVal = "";
		int randIndex;

		if (percentRand < econStoryRate) 
		{
			if (economyStories.Count > 0) 
			{
				randIndex = Random.Range (0, economyStories.Count);
				retVal = economyStories [randIndex];
				GlobalControl.Instance.savedPlayerData.economyEventCond = true;
				GlobalControl.Instance.savedPlayerData.randEvent = randIndex;
				//economyStories.Remove (randIndex);
			}
		} 
		else 
		{
			if (normalStories.Count > 0) 
			{
				randIndex = Random.Range (0, normalStories.Count);
				retVal = normalStories [randIndex];
				//normalStories.Remove (randIndex);
			}
		}
		newsText.text = retVal;
		return retVal;
	}

}
