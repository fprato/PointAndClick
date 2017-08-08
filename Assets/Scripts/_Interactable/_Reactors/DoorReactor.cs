using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReactor : StateReactor
{
	public DoorHandler doorHandler;

	protected override void Awake()
	{
		base.Awake();
		React();
	}

	public override void React()
	{
		if (switcher.state == true)
		{
			doorHandler.Open();
		}
		else
		{
			doorHandler.Close();
		}
	}
}
