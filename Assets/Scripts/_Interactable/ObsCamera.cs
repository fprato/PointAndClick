﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsCamera : MonoBehaviour 
{
	[HideInInspector]
	public Transform model;

	public Transform rig;

	public float sensitivity = 3f;

	private Quaternion modelRotation;
	private Quaternion rigRotation;

	void Update()
	{
		if (Input.GetMouseButton(0) && (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0))
		{
			if (model == null)
				return;

			modelRotation = model.rotation;
			rigRotation = rig.rotation;

			RotateObject();
		}
	}

	public void RotateObject()
	{
		float yRot = Input.GetAxis("Mouse X") * sensitivity;
		float xRot = Input.GetAxis("Mouse Y") * sensitivity;

		modelRotation *= Quaternion.Euler(0f, -yRot, 0f);
		rigRotation *= Quaternion.Euler(xRot, 0f, 0f);

		rigRotation = ClampRotationAroundXAxis(rigRotation);

		model.rotation = modelRotation;
		rig.rotation = rigRotation;
	}

	Quaternion ClampRotationAroundXAxis(Quaternion q)
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1.0f;

		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

		angleX = Mathf.Clamp(angleX, -80f, 80f);

		q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

		return q;
	}

	public void Close()
	{
		Destroy(model.gameObject);
		rig.rotation = Quaternion.identity;
		gameObject.SetActive(false);
	}
}
