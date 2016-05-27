using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NewspaperController : MonoBehaviour {

	private Dictionary<int,string> economyStories;
	private Dictionary<int,string> normalStories;
	private float econStoryRate;

	public Text newsText;

	// Use this for initialization
	void Start () 
	{
		init ();
	}

	public void init()
	{
		economyStories = new Dictionary<int, string> ();
		normalStories = new Dictionary<int, string> ();
		initializeStories();
		econStoryRate = 0.3f;
	}

	private void initializeStories()
	{
		normalStories.Add (0, "In Local Metro News:\nThe metro unemployment report\ncame out showing minimal job\ngrowth, and a current unemployment\nrate at 5.4% - could be worse...");
		normalStories.Add (1, "In Local Metro News:\nThe traffic signals at Main\nand 3rd Ave have been malfunctioning\nsince yesterday afternoon causing\ntraffic jams and delays downtown today.");
		normalStories.Add (2, "In Local Metro News:\nNew construction has started today\nat 3rd Ave and Morrison St downtown\nwhich will be causing traffic delays at\nthat intersection for the next few weeks.");
		normalStories.Add (3, "In Local Metro News:\n Batboy has returned!\n Will he help settle the stock market?");

		economyStories.Add (0, "In Local Metro News:\nAn alligator has escaped from\nthe Metro Zoo and park area\nalong the riverfront! Avoid the\nentire downtown area if possible!");
		economyStories.Add (1, "In Local Metro News:\nLocal poultry farm under investigation\nfor unsanitary working conditions.\nMany local restaurants using their\nturkey and chicken products!");
		economyStories.Add (2, "In Local Metro News:\nNational SuperCon comic book\nconvention is coming to the metro\narea today, expect large crowds in the\ndowntown area all day!");
		economyStories.Add (3, "In Local Metro News:\nLocal MPEU Employees Union \ntoday announced an immediate\nstrike today, which will grind metro\narea work and traffic to a halt today!");
		economyStories.Add (4, "In Local Metro News:\nThe metro area Farmers Market is back \nfor its spring season today, you may \nwant to avoid downtown today because\nof the thousands of people attending!");
		economyStories.Add (5, "In Local Metro News:\nThe Downtown Metro Area\nVegan Animal Rescue Society \nIs having a pet adoption\nextravaganza starting at 9am!");
		economyStories.Add (6, "In Local Metro News:\nStarting today and continuing\nthrough the weekend is the\nAll Metro Area Homestead and\nGardening Conference at \nPioneer Square!");
		economyStories.Add (7, "In Local Metro News:\nThe first local incidents of\nHoof and Mouth disease were\nRecently reported to local health\nofficials. Please be advised this is a\ncontinuing story.");
	}	

	public string pickStory()
	{
		float percentRand = Random.Range (0f, 1f);
		string retVal = "";
		int randIndex;

		if (percentRand < econStoryRate) {
			randIndex = Random.Range (0, economyStories.Count);
			retVal = economyStories [randIndex];
		} 
		else 
		{
			randIndex = Random.Range (0, normalStories.Count);
			retVal = normalStories [randIndex];
		}
		newsText.text = retVal;
		return retVal;
	}

}
