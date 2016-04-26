using UnityEngine;
using System.Collections;

public class RenderLine : MonoBehaviour {

	private LineRenderer lineRenderer;
	private float counter;
	private float distance;

	// Somewhere in start and update we need to be able to calculate the middle point in the drawn demand curve line to connect
	// average spent per customer and average number of customers per day (demand) to calculate total potential profit

	public Transform origin;
	public Transform destination;
	public float lineDrawSpeed = 6f;
	public Color c1;
	public int LWStart;
	public int LWEnd;


	public void Start () {

		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.SetPosition (0, origin.position);
		lineRenderer.SetColors (c1, c1);
		lineRenderer.SetWidth (LWStart, LWEnd);

		distance = Vector3.Distance (origin.position, destination.position);

	}

	 public void Update () {

	 	if (counter < distance) {
	 		counter += .1f / lineDrawSpeed;
	
			float x = Mathf.Lerp (0, distance, counter);
	
			Vector3 pointA = origin.position;
			Vector3 pointB = destination.position;
	
			Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA;
	
			lineRenderer.SetPosition (1, pointAlongLine);
		}
	 }
}
