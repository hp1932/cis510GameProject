using UnityEngine;
using System.Collections;

/***************************************************
 * Purpose: Control customer movement and behavior
 * TO DO: CHange class name to be more apt?
 * *************************************************/

public class CustomerMover : MonoBehaviour {

	public float moveSpeed; //move speed
	public string order;
	private Vector3 target; //the customer's target
	private Transform offscreenDestinationTransform; //the customer's target
	private RestaurantController restaurant;

	private bool reachedTarget;
	private bool moving;
	private Vector3 driveUpLocation;
	private GameObject customerController;

	public float orderTime;

	void Start()
	{
		restaurant = GameObject.FindWithTag ("Restaurant").GetComponent<RestaurantController>();
		customerController = GameObject.FindWithTag ("CustomerController");
		driveUpLocation = GameObject.FindWithTag ("DriveUpWindow").transform.position;
		offscreenDestinationTransform = GameObject.FindWithTag("OffscreenTarget").transform;
		reachedTarget = false;
		moving = true;
		order = "Ham Sandwich";
	}

	/***************************************
	 * Purpose: Set location to which customer is moving
	 * *************************************/
	public void SetTarget(Vector3 t)
	{
		target = t;
		reachedTarget = false;
	}

	/***************************************
	 * Purpose: Get move target
	 * *************************************/
	public Vector3 GetTarget()
	{
		return target;
	}

	/***************************************
	 * Purpose: Move toward target.
	 * 			If at window, order and wait.
	 * *************************************/
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
					restaurant.Order (order);
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