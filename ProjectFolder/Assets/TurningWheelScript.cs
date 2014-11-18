using UnityEngine;
using System.Collections;

public class TurningWheelScript : MonoBehaviour {

public float turnSpeed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	if(Input.GetKey(KeyCode.LeftControl)){
		transform.Rotate(new Vector3(0,0,Input.GetAxis("Horizontal")*turnSpeed*0.5f));
	}
	else if(Input.GetKey(KeyCode.LeftShift)){
		transform.Rotate(new Vector3(0,0,Input.GetAxis("Horizontal")*turnSpeed*2f));
	}
	else{
		transform.Rotate(new Vector3(0,0,Input.GetAxis("Horizontal")*turnSpeed));
	}
	}
}
