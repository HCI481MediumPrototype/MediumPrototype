﻿using UnityEngine;
using System.Collections;


/**
 * Controls the car by changing the torque, direcion and braking of the four wheels of the vehicle.
 * This is a front wheel drive car, with steering and power applied to the front wheels.
 */ 
public class CarController : MonoBehaviour {
		
	public float enginePower = 150.0f;
	public float power = 0.0f;
	public float brake = 0.0f;
	public float steer = 0.0f;
	
	float maxSteer = 25.0f;

	public WheelCollider frontLeftWheel;
	public WheelCollider frontRightWheel;
	public WheelCollider rearLeftWheel;
	public WheelCollider rearRightWheel;

	private GUIText Speedometer;
	
	void Start()
	{
		// Make center of mass lower and more forward to prevent tipping
		rigidbody.centerOfMass = new Vector3(0, -0.5f ,0.3f);

		Speedometer = GameObject.Find("Speedometer").GetComponent<GUIText>();
	}


	void Update () 
	{
		power = Input.GetAxis("Vertical") * enginePower * Time.deltaTime * 250.0f;
		steer = Input.GetAxis("Horizontal") * maxSteer;
		brake = Input.GetKey("space") ? rigidbody.mass * 0.1f: 0;

		// Set angle of our wheel colliders
		frontLeftWheel.steerAngle = -steer;
		frontRightWheel.steerAngle = -steer;

		// Braking, apply brakes to wheels
		if(brake > 0.0)
		{
			frontLeftWheel.brakeTorque = brake;
			frontRightWheel.brakeTorque = brake;
			rearLeftWheel.brakeTorque = brake;
			rearRightWheel.brakeTorque = brake;
			frontLeftWheel.motorTorque = 0;
			frontRightWheel.motorTorque = 0;
		} 
		// Not braking, apply power to front wheels
		else 
		{
			frontLeftWheel.brakeTorque = 0;
			frontRightWheel.brakeTorque = 0;
			rearLeftWheel.brakeTorque = 0;
			rearRightWheel.brakeTorque = 0;
			frontLeftWheel.motorTorque = power;
			frontRightWheel.motorTorque = power;
		}

		int currentSpeed = (int) rigidbody.velocity.magnitude;

		// Update GUI values based on the state of the car
		Speedometer.text = currentSpeed + " Km/H";
	}
}