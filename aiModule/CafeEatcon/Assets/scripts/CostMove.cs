﻿using UnityEngine;
using System.Collections;

public class CostMove : MonoBehaviour {

	public float originX;
	public float originY;
	public float originZ;
	public bool dualDemandCurve;


	void Start ()
	{



		GameObject Middle = GameObject.Find ("Middle");
		GameObject GhostofOrigin = GameObject.Find ("GhostofOrigin");

		dualDemandCurve = Middle.GetComponent<MoveWith> ().dualDemandCurve;
		// dualDemandCurve = true; // testing only!
		originX = transform.position.x;
		originY = transform.position.y;
		originZ = transform.position.z;

		// GhostofOrigin.GetComponent<GhostOriginScript> ().originX = originX - 2;
		// GhostofOrigin.GetComponent<GhostOriginScript> ().originY = originY;
		// GhostofOrigin.GetComponent<GhostOriginScript> ().originZ = originZ;



		if (dualDemandCurve == true)
		{

			transform.position = new Vector3 (transform.position.x +2, transform.position.y, transform.position.z);
		}

		if (dualDemandCurve == false)
		{

			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		}


	}

	void Update () {
	}
}
