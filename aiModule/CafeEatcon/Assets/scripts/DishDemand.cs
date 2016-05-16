using UnityEngine;
using System.Collections;
using System;
//https://unity3d.com/learn/tutorials/modules/intermediate/scripting/lists-and-dictionaries

//****************************************************************
public class DishDemand : IComparable<DishDemand>
{
	public string name;
	public float probability;

	public DishDemand(string n, float p)
	{
		name = n;
		probability = p;
	}

	//This method is required by the IComparable
	//interface. 
	public int CompareTo(DishDemand other)
	{
		if(other == null)
		{
			return 1;
		}

		//Return the difference in probability.
		return (int)(probability - other.probability);
	}
}