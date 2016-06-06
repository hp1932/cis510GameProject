using UnityEngine;
using System.Collections;

public class destinationMove : MonoBehaviour {

	public float destX;
	public float destY;
	public float destZ;
	public bool dualDemandCurve;


	RestaurantStatistics localPlayerData;

	void Start ()
	{
		localPlayerData = GlobalControl.Instance.savedPlayerData;

		// GameObject Middle = GameObject.Find ("Middle");
		// dualDemandCurve = Middle.GetComponent<MoveWith> ().dualDemandCurve;
		dualDemandCurve = localPlayerData.dualDemandCurve;


		// dualDemandCurve = Middle.GetComponent<MoveWith> ().dualDemandCurve;
		// dualDemandCurve = true; // testing only!
		destX = transform.position.x;
		destY = transform.position.y;
		destZ = transform.position.z;



		if (dualDemandCurve == true)
		{


			transform.position = new Vector3 (transform.position.x +2, transform.position.y, transform.position.z);
		}

		if (dualDemandCurve == false)
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		}


	}

}
