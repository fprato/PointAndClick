using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : Interactable
{
	public bool state;

	// Event setup
	public delegate void onStateChange();
	public event onStateChange Change;

	public override void Interact()
	{
		state = !state;

		if (Change != null)
			Change();
	}
}
