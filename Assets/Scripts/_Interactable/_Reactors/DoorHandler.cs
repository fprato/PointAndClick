using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour {

	public Transform pivot;
	public float turnSpeed = 50f;

	private bool isOpening = false;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isOpening && isOpen() == false)
		{
			transform.RotateAround(pivot.transform.position, Vector3.up, -turnSpeed* Time.deltaTime);
		}
	}

	bool isOpen()
	{
		return (transform.rotation.y <= 0);
	}

	public void Open()
	{
		isOpening = true;

	}

	public void Close()
	{
		isOpening = false;
	}
}
