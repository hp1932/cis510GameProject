using UnityEngine;
using System.Collections;

public class HorLineRender : MonoBehaviour {

	private LineRenderer HorizontalLR;

	public Transform LRplacement;
	public float lineWidth;

	// Use this for initialization
	void Start () {

		HorizontalLR = GetComponent<LineRenderer> ();
		HorizontalLR.enabled = true;
		HorizontalLR.useWorldSpace = true;
		HorizontalLR.SetWidth(lineWidth, lineWidth);

	
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.right * -1);
		// Debug.DrawLine (transform.position, hit.point, Color.red);
		LRplacement.position = hit.point;
		HorizontalLR.SetPosition (0, transform.position);
		HorizontalLR.SetPosition (1, LRplacement.position);
	
	}
}
