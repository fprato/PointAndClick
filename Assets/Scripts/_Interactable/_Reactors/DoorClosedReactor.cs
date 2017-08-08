using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClosedReactor : StateReactor 
{
	protected override void Awake()
	{
		base.Awake();
		React();
	}

	public override void React()
	{
		Debug.Log("I don't need to go to the kitchen right now");
	}
}
