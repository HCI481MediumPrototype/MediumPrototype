using UnityEngine;
using System.Collections;

public class TurningWheelScript : MonoBehaviour {

public float turnSpeed = 2f;
public float highTurnSpeed = 5f;
public float lowTurnSpeed = 0.5f;
private float curRotation = 0;
public float maxTurn = 720f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	if((-maxTurn<curRotation || Input.GetAxis("Horizontal") > 0) &&(curRotation < maxTurn || Input.GetAxis("Horizontal") < 0))
	{
	if(Input.GetKey(KeyCode.LeftControl)){
		transform.Rotate(new Vector3(0,0,Input.GetAxis("Horizontal")*lowTurnSpeed));
		curRotation += Input.GetAxis("Horizontal")*lowTurnSpeed;
	}
	else if(Input.GetKey(KeyCode.LeftShift)){
		transform.Rotate(new Vector3(0,0,Input.GetAxis("Horizontal")*highTurnSpeed));
		curRotation += Input.GetAxis("Horizontal")*highTurnSpeed;
	}
	else{
		transform.Rotate(new Vector3(0,0,Input.GetAxis("Horizontal")*turnSpeed));
		curRotation += Input.GetAxis("Horizontal")*turnSpeed;
	}
	}
	}
}
