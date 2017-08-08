using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavCharacter : MonoBehaviour
{
	private NavMeshAgent navMeshAgent;
	private Vector3 destinationPoint;
	private bool moveToNode = false;

	// Use this for initialization
	void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (moveToNode)
				MoveToNode();
			else
			{
				MoveToMousePosition();
			}

			moveToNode = false;
		}
	}

	void MoveToNode()
	{ 
		navMeshAgent.SetDestination(destinationPoint);
	}

	void MoveToMousePosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            navMeshAgent.SetDestination(hit.point);
        }
	}

	public void Move(Vector3 destination)
	{
		destinationPoint = destination;
		moveToNode = true;
	}

}