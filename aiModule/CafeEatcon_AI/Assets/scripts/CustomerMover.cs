using UnityEngine;
using System.Collections;

public class CustomerMover : MonoBehaviour {

	public float moveSpeed; //move speed
	public string order;
	private Vector3 target; //the customer's target
	private Transform offscreenDestinationTransform; //the customer's target

	private bool reachedTarget;
	private bool moving;
	private Vector3 driveUpLocation;
	private GameObject customerController;

	public float orderTime;

	void Start()
	{
		customerController = GameObject.FindWithTag ("CustomerController");
		driveUpLocation = GameObject.FindWithTag ("DriveUpWindow").transform.position;
		offscreenDestinationTransform = GameObject.FindWithTag("OffscreenTarget").transform;
		reachedTarget = false;
		moving = true;
	}

	public void SetTarget(Vector3 t)
	{
		target = t;
		reachedTarget = false;
	}

	public Vector3 GetTarget()
	{
		return target;
	}

	void Update()
	{
		if (moving) {
			if (!reachedTarget) 
			{
				transform.position = Vector3.MoveTowards (transform.position, target, moveSpeed * Time.deltaTime);
				if (transform.position == driveUpLocation) 
				{
					reachedTarget = true;
					PauseForFood (orderTime);
				}
				if (transform.position == offscreenDestinationTransform.position) 
				{
					Destroy (gameObject);
				}
			} 
		}
	}

	/*************************************************
	 * PURPOSE: stop the customer movement
	 * 			Call "LeaveScreen" after pauseTime seconds
	 * 
	 * ***********************************************/
	void PauseForFood(float pauseTime)
	{
		moving = false;
		Invoke ("LeaveScreen", pauseTime);
	}

	/*******************************************************
	 * PURPOSE: Assign target to point offscreen
	 * 			Restart customer movement. 
	 * 			Tell the customer controller to move the line ahead
	 * *****************************************************/
	void LeaveScreen()
	{
		moving = true;
		target = offscreenDestinationTransform.position;
		reachedTarget = false;

		//Tell the customer controller to pop stack of customers
		customerController.GetComponent<CustomerController>().MoveLineForward();
	}
}