using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public Node startingNode;
	public ImgViewCanvas imgViewCanvas;
	public ObsCamera obsCamera;
	public InventoryDisplay inventoryDisplay;
	public NavCharacter navCharacter;
	public CameraRig cameraRig;

	[HideInInspector]
 	public Node currentNode;
	public Item itemHeld = null;

	void Awake()
	{
		instance = this; // TODO: Write a better singleton!	
		if(imgViewCanvas != null)
			imgViewCanvas.gameObject.SetActive(false);
		if(obsCamera != null)
			obsCamera.gameObject.SetActive(false);
	}

	void Start()
	{
		startingNode.Arrive();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(1) && currentNode != null && currentNode.GetComponent<Prop>() != null)
		{
			if (imgViewCanvas != null && imgViewCanvas.gameObject.activeInHierarchy)
			{
				imgViewCanvas.Close();
				return;
			}
			if (obsCamera != null && obsCamera.gameObject.activeInHierarchy)
			{
				obsCamera.Close();
				return;
			}
			currentNode.GetComponent<Prop>().location.Arrive();
		}
	}
}
