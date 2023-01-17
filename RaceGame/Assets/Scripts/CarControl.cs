using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour {

	public GameObject Wheel_FR;
	public GameObject Wheel_FL;
	public GameObject Wheel_BR;
	public GameObject Wheel_BL;

	public WheelCollider W_FL;
	public WheelCollider W_FR;
	public WheelCollider W_BL;
	public WheelCollider W_BR;

	public float Torque = 200f;

	public float loweststeerspeed = 10f;
	public float loweststreerangle = 20f;
	public float higheststeerangle = 10f;

	public bool isbrake = false;
	public float brakeTorque = 500f;

	Rigidbody rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		Vector3 temp = rb.centerOfMass;
		temp.y = -0.15f;
		rb.centerOfMass = temp;
	}

	void FixedUpdate ()
	{
		CarMovement ();
		RotateWheels ();
		steerWheels ();
		HandBrake ();
	}

	void CarMovement () 
	{
		W_BL.motorTorque = Torque * Input.GetAxis ("Vertical");
		W_BR.motorTorque = Torque * Input.GetAxis ("Vertical");


		float speedfactor = this.GetComponent<Rigidbody> ().velocity.magnitude / loweststeerspeed;
		float currentsteerAngle = Mathf.Lerp (loweststreerangle, higheststeerangle, speedfactor);

		currentsteerAngle *= Input.GetAxis ("Horizontal");

		W_FL.steerAngle = currentsteerAngle;
		W_FR.steerAngle = currentsteerAngle;
	}

	void RotateWheels () 
	{
		Wheel_BL.gameObject.transform.Rotate (W_BL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		Wheel_BR.gameObject.transform.Rotate (W_BR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		Wheel_FL.gameObject.transform.Rotate (W_FL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
		Wheel_FR.gameObject.transform.Rotate (W_FR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
	}

	void steerWheels ()
	{
		Vector3 temp;
		temp = Wheel_FL.transform.localEulerAngles;
		temp.y = W_FL.steerAngle;
		Wheel_FL.transform.localEulerAngles = temp;

		temp = Wheel_FR.transform.localEulerAngles;
		temp.y = W_FR.steerAngle;
		Wheel_FR.transform.localEulerAngles = temp;
	}

	void HandBrake ()
	{
		if (Input.GetKey (KeyCode.Space)) 
		{
			isbrake = true;
		} 
		else 
		{
			isbrake = false;
		}
		if (isbrake == true) 
		{
			W_BL.brakeTorque = brakeTorque;
			W_BR.brakeTorque = brakeTorque;
			W_BL.motorTorque = 0;
			W_BR.motorTorque = 0;
		} 
		else 
		{
			W_BL.brakeTorque = 0;
			W_BR.brakeTorque = 0;
		}
	}
}