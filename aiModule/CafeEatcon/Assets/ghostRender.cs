using UnityEngine;
using System.Collections;

public class ghostRender : MonoBehaviour {

	private LineRenderer lineRendererMain;
	private float counter;

	public Transform origin;
	public Transform destination;
	public float lineDrawSpeed = 6f;
	public float lineWidth;
	public Color c1;
	public float distance;
	public bool dualDemandCurve;

	RestaurantStatistics localPlayerData;



	public void Start () {

		if (dualDemandCurve == true) {

			localPlayerData = GlobalControl.Instance.savedPlayerData;
			// Main Origin to Destination Line
			lineRendererMain = GetComponent<LineRenderer> ();
			lineRendererMain.SetPosition (0, origin.position);
			lineRendererMain.SetColors (c1, c1);
			lineRendererMain.SetWidth (lineWidth, lineWidth);
			dualDemandCurve = localPlayerData.dualDemandCurve;

			distance = Vector3.Distance (origin.position, destination.position);

		}

	}

	public void Update () {

		if (dualDemandCurve == true) 
		{
			if (counter < distance) {
				counter += .1f / lineDrawSpeed;

				float x = Mathf.Lerp (0, distance, counter);

				Vector3 pointA = origin.position;
				Vector3 pointB = destination.position;

				Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA;

				lineRendererMain.SetPosition (1, pointAlongLine);
				distance = Vector3.Distance (origin.position, destination.position);


			}
		}


	}

}
