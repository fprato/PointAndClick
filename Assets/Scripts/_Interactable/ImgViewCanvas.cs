using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgViewCanvas : MonoBehaviour 
{
	public Image imageHolder;

	public void Activate(Sprite picture)
	{
		GameManager.instance.currentNode.SetReachableNode(false);
		GameManager.instance.currentNode.coll.enabled = false;
		gameObject.SetActive(true);
		imageHolder.sprite = picture;
	}

	public void Close()
	{
		GameManager.instance.currentNode.SetReachableNode(true);
		GameManager.instance.currentNode.coll.enabled = true;
		gameObject.SetActive(false);
		imageHolder.sprite = null;
	}
}



