using UnityEngine;
using System.Collections;

public class CustomerMover : MonoBehaviour {

	public float moveSpeed; //move speed
	private Transform driveUpWindowTransform; //the customer's target
	private Transform offscreenDestinationTransform; //the customer's target

	private bool moveForward;
	private bool reachedDriveUp;
	private bool moving;

	public float orderTime;

	void Start()
	{
		driveUpWindowTransform = GameObject.FindWithTag("DriveUpWindow").transform; //target the restaurant window
		offscreenDestinationTransform = GameObject.FindWithTag("OffscreenTarget").transform;
		moveForward = true;
		reachedDriveUp = false;
		moving = true;
	}

	void Update()
	{
		if (moving) {
			if (!reachedDriveUp) {
				transform.position = Vector3.MoveTowards (transform.position, driveUpWindowTransform.position, moveSpeed * Time.deltaTime);
				if (transform.position == driveUpWindowTransform.position) {
					reachedDriveUp = true;
					moving = false;
					Invoke ("RestartMovement", orderTime);
				}
			} else {
				transform.position = Vector3.MoveTowards (transform.position, offscreenDestinationTransform.position, moveSpeed * Time.deltaTime);
				if (transform.position == offscreenDestinationTransform.position) {
					Destroy (gameObject);
				}
			}
		}
	}

	void RestartMovement()
	{
		moving = true;
	}
			

}