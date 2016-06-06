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

	void Start () { // removed PUBLIC not sure its purpose

		localPlayerData = GlobalControl.Instance.savedPlayerData;

		// GameObject Middle = GameObject.Find ("Middle");
		// dualDemandCurve = Middle.GetComponent<MoveWith> ().dualDemandCurve;
		dualDemandCurve = localPlayerData.dualDemandCurve;

		if (dualDemandCurve == true) {


			localPlayerData = GlobalControl.Instance.savedPlayerData;
			// GameObject Middle = GameObject.Find ("Middle");
			// dualDemandCurve = Middle.GetComponent<MoveWith> ().dualDemandCurve;
			// dualDemandCurve = true; // testing only!
			// Main Origin to Destination Line
			lineRendererMain = GetComponent<LineRenderer> ();
			lineRendererMain.SetPosition (0, origin.position);
			lineRendererMain.SetColors (c1, c1);
			lineRendererMain.SetWidth (lineWidth, lineWidth);

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
