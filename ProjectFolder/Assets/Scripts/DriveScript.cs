using UnityEngine;
using System.Collections;

public class DriveScript : MonoBehaviour {

	public float acceleration = 0.0000001f; 	// 0.005f
	public float brakeSpeed = 0.1f;
	public float turnDamper = 0.02f;
	public float maxGasPedalSpeed = 1f;

	public float enginePower = 0.0000001f;			// carSpeed += EnginePower * curGasPedalSpeed
	private float curGasPedalSpeed = 0f;	// How far 'down' the gas pedal is being pushed
											// It's the acceleration added onto carSpeed on each tick
	private float carSpeed = 0;		// Forward moving speed

	private Rigidbody carBody;
	private BoxCollider carCollider;
	private bool braking = false;


	// Use this for initialization
	void Start () {
		carBody = this.GetComponent<Rigidbody>();
		carCollider = this.GetComponent<BoxCollider>();
	}


	/**
	 * Switches the material of the car to a physics material with a high amount of friction, 
	 * rapidly slowing down the car.
	 */ 
	void startBraking ()
	{
		// Reset the rigidbody
		carBody.isKinematic = true;
		carBody.Sleep();

		// Swap the material
		carCollider.material = new PhysicMaterial("CarBraking");

		// Wake up the rigidbody
		carBody.isKinematic = false;
		carBody.WakeUp();

		braking = true;

		curGasPedalSpeed = 0;
	}
	void stopBraking ()
	{
		// Reset the rigidbody
		carBody.isKinematic = true;
		carBody.Sleep();
		
		// Swap the material
		carCollider.material = new PhysicMaterial("Car");
		
		// Wake up the rigidbody
		carBody.isKinematic = false;
		carBody.WakeUp();
		
		braking = false;
	}


	void Update ()
	{
		// Break if the brake
		if (Input.GetButton("Brake"))
		{
			// IF not breaking before, change our physics material to start breaking
			if(!braking)
			{
				startBraking();
			}
		}
		else if (braking)
		{
			stopBraking();
		}
	}


	// Handles physics to the car. Car cannot move sideways. No drifting.
	// We won't be using realistic friction either.
	// Approximating nature is fine and easier to control
	void FixedUpdate () {
		// Every tick curGasPedalSpeed is added onto the car's forward speed.
		if((Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow)) && curGasPedalSpeed > 0f)
		{
			curGasPedalSpeed= curGasPedalSpeed + (brakeSpeed * Input.GetAxis("Vertical"));
			if(curGasPedalSpeed<0)
			{
				curGasPedalSpeed = 0;
			}
		}
		else if(curGasPedalSpeed < maxGasPedalSpeed && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
		{
			curGasPedalSpeed += (acceleration * Input.GetAxis("Vertical")) / 10000;
		}

		// Car speed is our movement speed
		carSpeed += curGasPedalSpeed * enginePower;

		if(braking)
		{
			// If breaking rapidly decrease our speed
			carSpeed = carSpeed / 2;
		}
		else if (curGasPedalSpeed == 0)
		{
			// No pressure on the gas pedal. Simulate friction slowing down the car
			carSpeed = carSpeed / 5;//carSpeed -= 0.1f;
			carSpeed = Mathf.Max(0, carSpeed);
		}
	
		// The car has a max speed
		carSpeed = Mathf.Min(0.4f, carSpeed);
		
		//transform.Translate(new Vector3(0, 0, carSpeed));
		//transform.Rotate(new Vector3(0,-TurningWheelScript.curRotation* turnDamper * carSpeed, 0));

		//rigidbody.AddRelativeForce(0, 0, curGasPedalSpeed * enginePower);
		//transform.Rotate(new Vector3(0, -TurningWheelScript.curRotation*turnDamper * carBody.velocity.z / 2, 0));

		//carBody.velocity = new Vector3(0, 0, Mathf.Max(0, carBody.velocity.z));
	}


	void OnGUI()
	{
		GUI.Label(new Rect(330, Screen.height -50, 100, 30), (curGasPedalSpeed).ToString());
		GUI.Label(new Rect(300, Screen.height - 70, 100, 30), (carSpeed).ToString());
		GUI.Label(new Rect(300, Screen.height - 100, 100, 30), (braking).ToString());
	}
	
}
