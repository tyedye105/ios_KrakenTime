using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipPathing : MonoBehaviour {

public Transform path;

public float moveSpeed = 0.5f;
public float turnSpeed = 1.0f;
public bool flatOcean = true;
public bool isLooping = false;
public UnityEvent OnStarted;
public UnityEvent OnFinished;

private int pathNodeIndex = -1;
private Transform pathNode;


void Awake()
{
	StartPath(path);
}

void Update()
{
	if (pathNode != null)
		{
			Turn();
			Move();
		}
}

public void RestartPath()
{
	StartPath(path);
}

public void StartPath(Transform path)
{
	this.path = path;

	if (path != null)
	{
		pathNodeIndex = -1;
		SetNextPathNode();

		if (pathNode != null)
		{
				transform.position = pathNode.position;
		transform.rotation = pathNode.rotation;
				SetNextPathNode();
		OnStarted.Invoke()	;
		   
		}
	}
}

private void SetNextPathNode()
{
	pathNodeIndex += 1;
	pathNode = null;

	if (path.childCount > 0)
	{
		if (pathNodeIndex < path.childCount)
		{
			pathNode = path.GetChild(pathNodeIndex);
		}
		else if (isLooping) 
		{
			pathNodeIndex = 0;
			pathNode = path.GetChild(pathNodeIndex);
		}
		else
		{
		OnFinished.Invoke();
		}
	}
}

private void Turn()
{
if (turnSpeed > 0.0f)
	{
		float turnStep = turnSpeed * Time.deltaTime;
		Vector3 direction = pathNode.position - transform.position;
	
		Quaternion targetRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, turnStep);
	}
}
private void Move()
{
if (moveSpeed > 0.0f)
{
	Vector3 transformPosition = transform.position;
	Vector3 pathNodePosition =pathNode.position;

	if (flatOcean)
	{
		transformPosition.y = 0;
		pathNodePosition.y = 0;
	}

	float travel = moveSpeed * Time.deltaTime;
	Vector3 position = Vector3.MoveTowards(transformPosition, pathNodePosition, travel);


	transform.position = position;

	float distance = Vector3.Distance(transformPosition, pathNodePosition);
	if (distance <= travel)
	{
		SetNextPathNode();
	}
}
}

public void SetMoveSpeed(float speed)
{
	moveSpeed = speed;

}

public void SetTurnSpeed(float speed)
{
	turnSpeed = speed;
}


}
