using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour {

	public float topspeed = 100f;

	private float currentSpeed = 0;
	private float pitch = 0;

	void Update () 
	{
		currentSpeed = transform.GetComponent<Rigidbody> ().velocity.magnitude * 3.6f;
		pitch = currentSpeed / topspeed;

		GetComponent<AudioSource> ().pitch = pitch;
	}
}