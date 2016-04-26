using UnityEngine;
using System.Collections;

public class CostMove : MonoBehaviour {

	public int costYPosition;


	// void Start (){
	// will need to set costYPosition int variable by total mean average cost of all meals sold in prior day that is grabbed from a variable in another scene
	// needs to have some conversion from mean price in dollars to translate to Y vector, from Y = 250 at BOTTOM which would equal a zero mean average, up to Y = 490 at top
	// costYPosition currently jumps at 10px per click. 240 total px from bottom to top, or 24 clicks. Each increment should be $2.50 per, so total possible would be 60 per customer average at max
	// }

	public void OriginIncrease()
	{
		if (costYPosition <= 474)
		{

			costYPosition = costYPosition + 14;
			transform.position = new Vector3(125, costYPosition, -3);
		}
	}

	public void OriginDecrease()
	{
		if (costYPosition >= 228) {
			costYPosition = costYPosition - 14;
			transform.position = new Vector3 (125, costYPosition, -3);
		}
	}

}
