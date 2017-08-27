using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tentacle : MonoBehaviour {

	private new Rigidbody rigidbody;
	private new Renderer renderer;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		renderer = GetComponent<Renderer>();
	}

	private void onEnable()
	{
		Show();
	}

	private void Show()
	{
	rigidbody.isKinematic = false;
	renderer.enabled = true;
	}

	private void Hide()
	{
	rigidbody.isKinematic = true;
	renderer.enabled = false;
	}

	private void Disable()
	{
	gameObject.SetActive(false);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "disabler"){
		Disable();
		}
	}
}
