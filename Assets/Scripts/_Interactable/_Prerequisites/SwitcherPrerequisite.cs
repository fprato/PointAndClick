using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherPrerequisite : Prerequisite 
{
	public Switcher watchSwitcher;

	public override bool isComplete()
	{
		return watchSwitcher.state;
	}
}
