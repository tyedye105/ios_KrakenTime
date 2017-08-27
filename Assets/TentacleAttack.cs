using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleAttack : MonoBehaviour {

public TentacleStack tentacleStack;
public float strength;

	public void Attack()

	{
		if (isActiveAndEnabled)
		{
			Tentacle tentacle = tentacleStack.GetTentacle();

			if (tentacle != null)
			{
				tentacle.gameObject.SetActive(true);
				tentacle.transform.position = transform.position;
				tentacle.transform.localRotation = transform.rotation;
			




			}
		}
	}

}
