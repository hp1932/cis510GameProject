using UnityEngine;
using System.Collections;

public class destinationMove : MonoBehaviour {

	public float destX;
	public float destY;
	public float destZ;
	public bool dualDemandCurve;

	void Start ()
	{
		GameObject Middle = GameObject.Find ("Middle");
		destX = transform.position.x;
		destY = transform.position.y;
		destZ = transform.position.z;

		dualDemandCurve = Middle.GetComponent<MoveWith> ().dualDemandCurve;
		// dualDemandCurve = true; // testing only!

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
