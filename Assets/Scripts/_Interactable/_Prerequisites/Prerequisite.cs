using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Prerequisite : MonoBehaviour 
{
	// if prerequisite not complete, don't allow access to the node
	public bool nodeAccess;

	// check if prerequisite is met
	public abstract bool isComplete();
}
