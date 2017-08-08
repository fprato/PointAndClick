using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Node : MonoBehaviour {

	public Transform cameraPosition;
	public Transform characterPosition;
	public List<Node> reachableNodes = new List<Node>();

	[HideInInspector]
	public Collider coll;

	// Use this for initialization
	void Awake () 
	{
		coll = GetComponent<Collider>();
		coll.enabled = false;
		Debug.Log("Node:" + gameObject.name);
	}

	void OnMouseDown()
	{
		Arrive();
	}

	public virtual void Arrive()
	{
		// Leave existing current node
		if(GameManager.instance.currentNode != null)
			GameManager.instance.currentNode.Leave();

		// Set current node
		GameManager.instance.currentNode = this;

		// Move camera
		GameManager.instance.cameraRig.AlignTo(cameraPosition);

		// Move character
		if(characterPosition != null)
			GameManager.instance.navCharacter.Move(characterPosition.position);
		   
		// Turn own collider off
		if (coll != null)
		{
			coll.enabled = false;
		}

        SetReachableNode(true);	
	}

	public virtual void Leave()
	{
		SetReachableNode(false);
	}

	public void SetReachableNode(bool value)
	{
		foreach (Node n in reachableNodes)
		{
			if (n.coll != null)
			{
				Prerequisite prereq = n.GetComponent<Prerequisite>();
				if (prereq != null && prereq.nodeAccess)
				{
					if (prereq.isComplete())
						n.coll.enabled = value;
				}
				else
				{
					n.coll.enabled = value;
				}
			}
		}
	}
}
