using UnityEngine;
using System.Collections;

public class CustomerMove : MonoBehaviour {

	public int CustXPosition;

	public void DestinationIncrease()
	{
		if (CustXPosition <= 615)
		{

			CustXPosition = CustXPosition + 10;
			transform.position = new Vector3(CustXPosition, 218, -3);
		}
	}

	public void DestinationDecrease()
	{
		if (CustXPosition >= 135) {
			CustXPosition = CustXPosition - 10;
			transform.position = new Vector3 (CustXPosition, 218, -3);
		}
	}

}
