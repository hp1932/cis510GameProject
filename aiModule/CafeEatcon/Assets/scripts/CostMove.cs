using UnityEngine;
using System.Collections;

public class CostMove : MonoBehaviour {

	public float originX;
	public float originY;
	public float originZ;

	void Start ()
	{
		originX = transform.position.x;
		originY = transform.position.y;
		originZ = transform.position.z;

	}


}
