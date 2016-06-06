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
	private readonly string LAVA_LEVEL_TEXT = "ALERT: VOLCANIC MT.NACHO IS ERUPTING! TRAFFIC IS BACKED UP AND MANY REPORT EXTREME HUNGER ALONG THE EVACUATION ROUTE."; 

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
		normalStories.Add (6, "In Metro Business News:\nA water main broke on 1st Ave late last night causing major flooding in some downtown areas, city officials said it will take the entire day to fix.");
		normalStories.Add (7, "In Metro Business News:\nToday, the world renowned balloon sculpture Finnigan Zyphese will be sculpting downtown for free!");
		normalStories.Add (8, "In Metro Business News:\nThe World Series of Juggling will be holding its final competition today at the historic courthouse area downtown from 10am through 6pm, all are welcome!");
		normalStories.Add (9, "In National News Headlines:\nThat one candidate running for president said something really bad about that other candidate running for president. This is not really a breaking story.");

		economyStories.Add (0, "In Local Metro News:\nAn alligator has escaped from the Metro Zoo and park area along the riverfront! Avoid the entire downtown area if possible!");
		economyStories.Add (6, "In Local Metro News:\nLocal poultry farm under investigation for unsanitary working conditions. Many local restaurants using their turkey and chicken products!");
		economyStories.Add (1, "In Local Metro News:\nNational SuperCon comic book convention is coming to the metro area today, expect large crowds in the downtown area all day!");
		economyStories.Add (2, "In Local Metro News:\nLocal MPEU Employees Union today announced an immediate strike today, which will grind metro area work and traffic to a halt today!");
		economyStories.Add (3, "In Local Metro News:\nThe metro area Farmers Market is back for its spring season today, you may want to avoid downtown today because of the thousands of people attending!");
		economyStories.Add (5, "In Local Metro News:\nThe Downtown Metro Area Vegan Animal Rescue Society is having a pet adoption extravaganza starting at 9am!");
		economyStories.Add (4, "In Local Metro News:\nStarting today and continuing through the weekend is the All Metro Area Homestead and Gardening Conference at Pioneer Square!");
		economyStories.Add (7, "In Local Metro News:\nThe first local incidents of Hoof and Mouth disease were Recently reported to local health officials. Please be advised this is a continuing story.");
		economyStories.Add (8, "In Metro Business News:\nThe Metro Stadium opens the 13th Annual Video Game Expo and is expecting huge crowds for the next several days!");
		economyStories.Add (9, "In Metro Business News:\nThe Circus is coming to town! The downtown metro area is expecting thousands of visitors to the circus starting today!");
		economyStories.Add (10, "In Metro Business News:\nAll Main Street shops are starting up their 'Evening Walk' staying open later for shopping, and will be offering sales as well as food and drink samples.");
		economyStories.Add (11, "In Metro Business News:\nThe World Championship BBQ & Chili Cookoff starts today at the historic courthouse and will continue through Sunday evening where winners will be announced!");
		economyStories.Add (12, "In Metro Business News:\nThe Chamber of Commerce released a report today stating our downtown metro area as the safest and most friendly shopping area in the tri-state area.");
		economyStories.Add (13, "In Metro Business News:\nSad news today in metro news. The world famous Princesses on Ice announced its cancellation of todays show due to lack of interest.");
		economyStories.Add (14, "In Metro Business News:\nCity officials state that a solar flare is threatening the entire Metro Areas power grid. They are asking all residents to stay home.");
		economyStories.Add (15, "In Metro Business News:\nA bed bug infestation has taken over the downtown metro area. City officials are asking everybody to stay home!");
		economyStories.Add (16, "In International News:\nThe World Health Organization just announced the widespread contamination of pork products stemming from a Canadian meat processing plant.");
		economyStories.Add (17, "In Metro Business News:\nState officials suspend poultry imports due to bird flu concerns from midwest processing plants");
		economyStories.Add (18, "In Metro Business News:\nState officials suspend vegetable imports from California due to a Salmonella outbreak");
		economyStories.Add (19, "In National News Headlines:\nPoultry-linked Salmonella sickens 324 in 35 states. This is a breaking story.");
		economyStories.Add (20, "In National News Headlines:\nBig Ham International, the world’s second Largest producer of ham and pork products nationally, just announced a major move to more organic and sustainable products.");
		economyStories.Add (21, "In National News Headlines:\nThe government of Australia has just announced a complete halt to all pork exports across the globe as news breaks of widespread contamination at multiple sites.");
		economyStories.Add (22, "In National News Headlines:\nThe National Farmer Workers United (NFWU) has called for a national strike for all farm workers across the country to demand better wages and treatment. This is a breaking story.");
	}	

	private void reinitializeStories()
	{
		normalStories[0] = "In Local Metro News:\nThe metro unemployment report came out showing minimal job growth, and a current unemployment rate at 5.4% - could be worse...";
		normalStories[1] = "In Local Metro News:\nThe traffic signals at Main and 3rd Ave have been malfunctioning since yesterday afternoon causing traffic jams and delays downtown today.";
		normalStories[2] = "In Local Metro News:\nNew construction has started today at 3rd Ave and Morrison St downtown which will be causing traffic delays at that intersection for the next few weeks.";
		normalStories[3] = "In Local Metro News:\n Batboy has returned! Will he help settle the stock market?";
		normalStories[4] = "In Sports News:\n The Middle Valley Senior High Football team clinched a playoff berth with a last second hail mary against Easton Prep.";
		normalStories[5] = "In Local News:\nThe Middleton Police Academy is looking for new applicants for their dog training division. Contact (555)DOG-COPS for more information.";
		normalStories[6] = "In Metro Business News:\nA water main broke on 1st Ave late last night causing major flooding in some downtown areas, city officials said it will take the entire day to fix.";
		normalStories[7] = "In Metro Business News:\nToday, the world renowned balloon sculpture Finnigan Zyphese will be sculpting downtown for free!";
		normalStories[8] = "In Metro Business News:\nThe World Series of Juggling will be holding its final competition today at the historic courthouse area downtown from 10am through 6pm, all are welcome!";
		normalStories[9] = "In National News Headlines:\nThat one candidate running for president said something really bad about that other candidate running for president. This is not really a breaking story.";

		economyStories[0] = "In Local Metro News:\nAn alligator has escaped from the Metro Zoo and park area along the riverfront! Avoid the entire downtown area if possible!";
		economyStories[6] = "In Local Metro News:\nLocal poultry farm under investigation for unsanitary working conditions. Many local restaurants using their turkey and chicken products!";
		economyStories[1] = "In Local Metro News:\nNational SuperCon comic book convention is coming to the metro area today, expect large crowds in the downtown area all day!";
		economyStories[2] = "In Local Metro News:\nLocal MPEU Employees Union today announced an immediate strike today, which will grind metro area work and traffic to a halt today!";
		economyStories[3] = "In Local Metro News:\nThe metro area Farmers Market is back for its spring season today, you may want to avoid downtown today because of the thousands of people attending!";
		economyStories[5] = "In Local Metro News:\nThe Downtown Metro Area Vegan Animal Rescue Society is having a pet adoption extravaganza starting at 9am!";
		economyStories[4] = "In Local Metro News:\nStarting today and continuing through the weekend is the All Metro Area Homestead and Gardening Conference at Pioneer Square!";
		economyStories[7] = "In Local Metro News:\nThe first local incidents of Hoof and Mouth disease were Recently reported to local health officials. Please be advised this is a continuing story.";
		economyStories[8] = "In Metro Business News:\nThe Metro Stadium opens the 13th Annual Video Game Expo and is expecting huge crowds for the next several days!";
		economyStories[9] = "In Metro Business News:\nThe Circus is coming to town! The downtown metro area is expecting thousands of visitors to the circus starting today!";
		economyStories[10] = "In Metro Business News:\nAll Main Street shops are starting up their 'Evening Walk' staying open later for shopping, and will be offering sales as well as food and drink samples.";
		economyStories[11] = "In Metro Business News:\nThe World Championship BBQ & Chili Cookoff starts today at the historic courthouse and will continue through Sunday evening where winners will be announced!";
		economyStories[12] = "In Metro Business News:\nThe Chamber of Commerce released a report today stating our downtown metro area as the safest and most friendly shopping area in the tri-state area.";
		economyStories[13] = "In Metro Business News:\nSad news today in metro news. The world famous Princesses on Ice announced its cancellation of todays show due to lack of interest.";
		economyStories[14] = "In Metro Business News:\nCity officials state that a solar flare is threatening the entire Metro Areas power grid. They are asking all residents to stay home.";
		economyStories[15] = "In Metro Business News:\nA bed bug infestation has taken over the downtown metro area. City officials are asking everybody to stay home!";
		economyStories[16] = "In International News:\nThe World Health Organization just announced the widespread contamination of pork products stemming from a Canadian meat processing plant.";
		economyStories[17] = "In Metro Business News:\nState officials suspend poultry imports due to bird flu concerns from midwest processing plants";
		economyStories[18] = "In Metro Business News:\nState officials suspend vegetable imports from California due to a Salmonella outbreak";
		economyStories[19] = "In National News Headlines:\nPoultry-linked Salmonella sickens 324 in 35 states. This is a breaking story.";
		economyStories[20] = "In National News Headlines:\nBig Ham International, the world’s second Largest producer of ham and pork products nationally, just announced a major move to more organic and sustainable products.";
		economyStories[21] = "In National News Headlines:\nThe government of Australia has just announced a complete halt to all pork exports across the globe as news breaks of widespread contamination at multiple sites.";
		economyStories[22] = "In National News Headlines:\nThe National Farmer Workers United (NFWU) has called for a national strike for all farm workers across the country to demand better wages and treatment. This is a breaking story.";
	}	

	public string pickStory()
	{
		string retVal = "NULL";
		if (localPlayerData.lavaLevelTimer >= localPlayerData.lavaLevelLimit) 
		{
			retVal = LAVA_LEVEL_TEXT;
			localPlayerData.isLavaLevel = true;
			localPlayerData.lavaLevelTimer = 0;
			localPlayerData.lavaLevelLimit = localPlayerData.lavaLevelLimit * 2;
		} 
		else
		{
			float percentRand = Random.Range (0f, 1f);
			int randIndex;
			randIndex = 0;


			if (percentRand < econStoryRate) {
				if (GlobalControl.Instance.savedPlayerData.econStoriesAccessed < (economyStories.Count)) {
					while (retVal == "NULL") {
						randIndex = Random.Range (0, economyStories.Count);
						retVal = economyStories [randIndex];
						GlobalControl.Instance.savedPlayerData.randEvent = randIndex;
					}
					GlobalControl.Instance.savedPlayerData.econStoriesAccessed += 1;
					GlobalControl.Instance.savedPlayerData.economyEventCond = true;
					economyStories [randIndex] = "NULL";
					localPlayerData.lavaLevelTimer++;
				} else {
					reinitializeStories();
					GlobalControl.Instance.savedPlayerData.econStoriesAccessed = 0;
					GlobalControl.Instance.savedPlayerData.normStoriesAccessed = 0;
					pickStory ();
				}
			} else {
				if (GlobalControl.Instance.savedPlayerData.normStoriesAccessed < (normalStories.Count)) {
					while (retVal == "NULL") {
						randIndex = Random.Range (0, normalStories.Count);
						retVal = normalStories [randIndex];
					}
					normalStories [randIndex] = "NULL";
					localPlayerData.lavaLevelTimer++;
				} else {
					reinitializeStories();
					GlobalControl.Instance.savedPlayerData.normStoriesAccessed = 0;
					GlobalControl.Instance.savedPlayerData.econStoriesAccessed = 0;
					pickStory ();
				}
			}
		}
		newsText.text = retVal;
		return retVal;
	}

}
