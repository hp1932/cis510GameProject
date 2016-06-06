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
		normalStories.Add (6, "In Metro Business News:\nA water main broke on 1st Ave\nlate last night causing major flooding \nin some downtown areas, city officials\nsaid it will take the entire day to fix.");
		normalStories.Add (7, "In Metro Business News:\nToday, the world renowned\nballoon sculpture Finnigan\nZyphese will be sculpting\ndowntown for free!");
		normalStories.Add (8, "In Metro Business News:\nThe World Series of Juggling will\nbe holding its final competition today\nat the historic Courthouse area downtown\nfrom 10am through 6pm, all are welcome!");
		normalStories.Add (9, "In National News Headlines:\nThat one candidate running for president\nSaid something really bad about that other\ncandidate running for president. This is\nNot really a breaking story.");

		economyStories.Add (0, "In Local Metro News:\nAn alligator has escaped from the Metro Zoo and park area along the riverfront! Avoid the entire downtown area if possible!");
		economyStories.Add (6, "In Local Metro News:\nLocal poultry farm under investigation for unsanitary working conditions. Many local restaurants using their turkey and chicken products!");
		economyStories.Add (1, "In Local Metro News:\nNational SuperCon comic book convention is coming to the metro area today, expect large crowds in the downtown area all day!");
		economyStories.Add (2, "In Local Metro News:\nLocal MPEU Employees Union today announced an immediate strike today, which will grind metro area work and traffic to a halt today!");
		economyStories.Add (3, "In Local Metro News:\nThe metro area Farmers Market is back for its spring season today, you may want to avoid downtown today because of the thousands of people attending!");
		economyStories.Add (5, "In Local Metro News:\nThe Downtown Metro Area Vegan Animal Rescue Society is having a pet adoption extravaganza starting at 9am!");
		economyStories.Add (4, "In Local Metro News:\nStarting today and continuing through the weekend is the All Metro Area Homestead and Gardening Conference at Pioneer Square!");
		economyStories.Add (7, "In Local Metro News:\nThe first local incidents of Hoof and Mouth disease were Recently reported to local health officials. Please be advised this is a continuing story.");
		economyStories.Add (8, "In Metro Business News:\nThe Metro Stadium opens the\n13th Annual Video Game Expo\nand is expecting huge crowds\nfor the next several days!");
		economyStories.Add (9, "In Metro Business News:\nThe Circus is coming to town!\nThe downtown metro area is\nexpecting thousands of visitors\nto the circus starting today!");
		economyStories.Add (10, "In Metro Business News:\nAll Main Street shops are starting\nup their 'Evening Walk' staying open\nlater for shopping, and will be offering\nsales as well as food and drink samples.");
		economyStories.Add (11, "In Metro Business News:\nThe World Championship BBQ & Chili\nCookoff starts today at the historic \nCourthouse and will continue through Sunday \nevening where winners will be announced!");
		economyStories.Add (12, "In Metro Business News:\nThe Chamber of Commerce released a \nreport today stating our downtown metro \narea as the safest and most friendly \nshopping area in the tri-state area.");
		economyStories.Add (13, "In Metro Business News:\nSad news today in metro news. \nThe world famous Princesses on Ice\nannounced its cancellation of\ntodays show due to lack of interest.");
		economyStories.Add (14, "In Metro Business News:\nCity officials state that a solar\nflare is threatening the entire\nMetro Areas power grid. They are\nasking all residents to stay home.");
		economyStories.Add (15, "In Metro Business News:\nA bed bug infestation has\ntaken over the downtown metro\narea. City officials are asking\neverybody to stay home!");
		economyStories.Add (16, "In International News:\nThe World Health Organization\njust announced the widespread contamination of pork products\nstemming from a Canadian meat\nprocessing plant.");
		economyStories.Add (17, "In Metro Business News:\nState officials suspend poultry \nimports due to bird flu concerns\nfrom midwest processing plants");
		economyStories.Add (18, "In Metro Business News:\nState officials suspend vegetable imports\nfrom California due to a Salmonella outbreak");
		economyStories.Add (19, "In National News Headlines:\nPoultry-linked Salmonella sickens 324 in 35 states. This is a breaking story.");
		economyStories.Add (20, "In National News Headlines:\nBig Ham International, the world’s second\nLargest producer of ham and pork products\nnationally, just announced a major move to\nmore organic and sustainable products.");
		economyStories.Add (21, "In National News Headlines:\nThe government of Australia has just announced a complete halt to all pork exports across the globe as news breaks of widespread contamination at multiple sites.");
		economyStories.Add (22, "In National News Headlines:\nThe National Farmer Workers United (NFWU) has called for a national strike for all farm workers across the country to demand better wages and treatment. This is a breaking story.");
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
				if (economyStories.Count > 0) {
					while (retVal == "NULL") {
						randIndex = Random.Range (0, economyStories.Count);
						retVal = economyStories [randIndex];
						GlobalControl.Instance.savedPlayerData.randEvent = randIndex;
					}
					GlobalControl.Instance.savedPlayerData.economyEventCond = true;
					economyStories[randIndex] = "NULL";
					localPlayerData.lavaLevelTimer++;
				}
			} else {
				if (normalStories.Count > 0) {
					while (retVal == "NULL") {
						randIndex = Random.Range (0, normalStories.Count);
						retVal = normalStories [randIndex];
					}
					normalStories[randIndex] = "NULL";
					localPlayerData.lavaLevelTimer++;
				}
			}
		}
		newsText.text = retVal;
		return retVal;
	}

}
