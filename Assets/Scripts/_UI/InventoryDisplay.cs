using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour 
{
	Text displayText;

	void Start()
	{
		displayText = GetComponent<Text>();
		UpdateDisplay();
	}

	public void UpdateDisplay()
	{
		string displayName;
		if (GameManager.instance.itemHeld.itemName != "")
			displayName = GameManager.instance.itemHeld.itemName;
		else
			displayName = "none";

		displayText.text = "Item held: " + displayName;
	}
}



