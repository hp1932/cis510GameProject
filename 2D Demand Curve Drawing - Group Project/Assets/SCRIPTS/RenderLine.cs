using UnityEngine;
using System.Collections;

public class RenderLine : MonoBehaviour {

	private LineRenderer lineRendererMain;
	private float counter;



	// for later - public int lengthOfLineRenderer = 20; (seems to be able to determine length of line)

	// Somewhere in start and update we need to be able to calculate the middle point in the drawn demand curve line to connect
	// average spent per customer and average number of customers per day (demand) to calculate total potential profit


	public Transform origin;
	public Transform destination;
	public float lineDrawSpeed = 6f;
	public float lineWidth;
	public Color c1;
	public float distance;



	public void Start () {

		// Main Origin to Destination Line
		lineRendererMain = GetComponent<LineRenderer> ();
		lineRendererMain.SetPosition (0, origin.position);
		lineRendererMain.SetColors (c1, c1);
		lineRendererMain.SetWidth(lineWidth, lineWidth);

		distance = Vector3.Distance (origin.position, destination.position);

	}

	 public void Update () {

	 	if (counter < distance) {
	 		counter += .1f / lineDrawSpeed;
	
			float x = Mathf.Lerp (0, distance, counter);
	
			Vector3 pointA = origin.position;
			Vector3 pointB = destination.position;
	
			Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA;
	
			lineRendererMain.SetPosition (1, pointAlongLine);
		}
	 }
}
