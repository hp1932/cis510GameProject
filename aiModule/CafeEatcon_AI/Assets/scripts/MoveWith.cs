using UnityEngine;
using System.Collections;

public class MoveWith : MonoBehaviour {

	// public RenderLine Renderer;
	// public Transform origin;
	// public Transform destination;

	public int PerCustCostY;
	public int PerCustCostX;

	void Start () { }
		
	public void CostIncrease()
	{
		if (PerCustCostY <= 475) {
			PerCustCostY = PerCustCostY + 5;
			PerCustCostX = PerCustCostX - 10;
			transform.position = new Vector3 (PerCustCostX, PerCustCostY, -3);

		}
	}

		public void CostDecrease()
		{
			if (PerCustCostY >= 225)
			{
				PerCustCostY = PerCustCostY - 5;
				PerCustCostX = PerCustCostX + 10;
				transform.position = new Vector3(PerCustCostX, PerCustCostY, -3);

			}



	// Start by using the Find function to get access to the object in hierarchy that contains the RenderLine line renderer.
		// GameObject r = GameObject.Find("LineRenderer");
		// Then use GetComponentInChildren on the GameObject instantiated above to access the RenderLine script.
		// Renderer = r.GetComponentInChildren<RenderLine>();
		// Ensure that the script we are trying to access is not null before we work on it
		// if (Renderer == null) {
			// Let people know if this is broken
			// Debug.LogError ("Line Renderer is NULL!");
			// return;
			// }
		// o = Renderer.origin;
		// d = Renderer.destination;
		// transform.position = new Vector3(125, 302, -3);

	}

	// Update is called once per frame
	void Update () {



	}

}
