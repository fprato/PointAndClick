using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraRig))]
public class MousePOV : MonoBehaviour 
{
	public float XSensitivity = 2f;
	public float YSensitivity = 2f;
	public bool clampVerticalRotation = true;
	public float MinimumX = -90F;
	public float MaximumX = 90F;
	public bool smooth;
	public float smoothTime = 5f;

	private Quaternion yAxis;
	private Quaternion xAxis;
	private CameraRig cameraRig;

	void Start()
	{
		cameraRig = GetComponent<CameraRig>();
	}

	void Update()
	{
		if (Input.GetMouseButton(0) && (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0))
		{
			if (GameManager.instance.imgViewCanvas.gameObject.activeInHierarchy || 
			    GameManager.instance.obsCamera.gameObject.activeInHierarchy)
				return;
			
			yAxis = cameraRig.y_axis.localRotation;
			xAxis = cameraRig.x_axis.localRotation;

			LookRotation();
		}
	}

	public void LookRotation()
	{
		float yRot = Input.GetAxis("Mouse X") * XSensitivity;
		float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

		yAxis *= Quaternion.Euler(0f, yRot, 0f);
		xAxis *= Quaternion.Euler(-xRot, 0f, 0f);

		if (clampVerticalRotation)
			xAxis = ClampRotationAroundXAxis(xAxis);

		if (smooth)
		{
			cameraRig.y_axis.localRotation = Quaternion.Slerp(cameraRig.y_axis.localRotation, yAxis,
				smoothTime * Time.deltaTime);
			cameraRig.x_axis.localRotation = Quaternion.Slerp(cameraRig.x_axis.localRotation, xAxis,
				smoothTime * Time.deltaTime);
		}
		else
		{
			cameraRig.y_axis.localRotation = yAxis;
			cameraRig.x_axis.localRotation = xAxis;
		}
	}

	Quaternion ClampRotationAroundXAxis(Quaternion q)
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1.0f;

		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

		angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

		q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

		return q;
	}
}
