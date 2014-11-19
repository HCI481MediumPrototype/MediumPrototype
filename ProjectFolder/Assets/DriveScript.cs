using UnityEngine;
using System.Collections;

public class DriveScript : MonoBehaviour {

	public float speed = 0.5f;
	private float curSpeed = 0f;
	public float turnDamper = 0.01f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(new Vector3(0,0,Input.GetAxis("Vertical")) * speed);
		transform.Rotate(new Vector3(0,-TurningWheelScript.curRotation*turnDamper * Input.GetAxis("Vertical"),0));
	}
	
	public float Velocity()
	{
	return curSpeed;
	}
}
