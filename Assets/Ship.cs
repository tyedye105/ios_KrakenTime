using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	public int health;



	void OnCollisionEnter(Collision col)
	{ if( col.gameObject)

		health -=1;
		Debug.Log("hit");
		Sink();
	}

	public void Sink()
	{	if(health<=0) 
		{
			this.gameObject.GetComponent<Rigidbody>().useGravity = true;
			 
		}

	}

	// Update is called once per frame
	void Update () {
	}
}
