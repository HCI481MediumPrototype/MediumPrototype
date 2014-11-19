using UnityEngine;
using System.Collections;

public class DriveScript : MonoBehaviour {

	public float acceleration = 0.01f;
	public float brakeSpeed = 0.5f;
	private float curSpeed = 0f;
	public float turnDamper = 0.02f;
	public float maxSpeed = 1f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if((Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow)) && curSpeed>0f)
		{
		curSpeed= curSpeed + (brakeSpeed * Input.GetAxis("Vertical"));
		if(curSpeed<0)
		{
		curSpeed = 0;
		}
		}
		else if(curSpeed<maxSpeed && (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)))
		{
		curSpeed+=(acceleration * Input.GetAxis("Vertical"));
		}
		
		transform.Translate(new Vector3(0,0,curSpeed));
		transform.Rotate(new Vector3(0,-TurningWheelScript.curRotation*turnDamper * curSpeed,0));
	}
	
	public float Velocity()
	{
	return curSpeed;
	}
}
