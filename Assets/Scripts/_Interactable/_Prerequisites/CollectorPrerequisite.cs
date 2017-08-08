using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorPrerequisite : Prerequisite 
{
	public Collector checkCollector;	

	public override bool isComplete()
	{
		return (GameManager.instance.itemHeld.itemName == checkCollector.myItem.itemName);
	}
}
