using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleStack : MonoBehaviour {

	public Tentacle tentaclePrefab;
	public int instanceCount = 8;

	private Tentacle[] tentacles;

	private void Awake()
	{
		tentacles = new Tentacle[instanceCount];

		for (int i = 0; i < instanceCount; i++)
		{
			Tentacle tentacle = Instantiate(tentaclePrefab) as Tentacle;
			tentacle.transform.parent = transform;
			tentacle.gameObject.SetActive(false);
			tentacles[i] = tentacle;
		}

	}

	public Tentacle GetTentacle()
	{
		Tentacle foundTentacle = null;
		foreach(Tentacle tentacle in tentacles)
		{
			if (tentacle.isActiveAndEnabled == false)
			{
				foundTentacle = tentacle ;
				break;
			}
		}
		return foundTentacle;
	}

}
