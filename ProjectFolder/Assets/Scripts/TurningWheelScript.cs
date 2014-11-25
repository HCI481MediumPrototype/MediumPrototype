using UnityEngine;
using System.Collections;

public class TurningWheelScript : MonoBehaviour {

public float turnSpeed = 2f;
public float highTurnSpeed = 5f;
public float lowTurnSpeed = 0.5f;
public static float curRotation = 0;
public float maxTurn = 720f;
	
	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void FixedUpdate () 
	{
		if((-maxTurn<curRotation || Input.GetAxis("Horizontal") > 0) &&(curRotation < maxTurn || Input.GetAxis("Horizontal") < 0))
		{
			
			transform.rotation = Quaternion.Euler(transform.parent.eulerAngles.x,transform.parent.eulerAngles.y,Input.GetAxis("Horizontal")*180);
				curRotation = Input.GetAxis("Horizontal")*180;
			
		}
		
		

		if(Input.GetKeyDown(KeyCode.Space))
		{
			transform.Rotate(new Vector3(0,0,-curRotation));
			curRotation = 0;
		}
	}
}
