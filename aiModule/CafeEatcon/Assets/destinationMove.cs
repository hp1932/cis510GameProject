using UnityEngine;
using System.Collections;

public class destinationMove : MonoBehaviour {

	public float destX;
	public float destY;
	public float destZ;

	void Start ()
	{
		destX = transform.position.x;
		destY = transform.position.y;
		destZ = transform.position.z;

	}

}
