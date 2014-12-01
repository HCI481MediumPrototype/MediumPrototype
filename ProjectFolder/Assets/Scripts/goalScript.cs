using UnityEngine;
using System.Collections;

public class goalScript : MonoBehaviour {

	public static int objectivesCompleted = 0;
	public int objectivesNum = 0;
	public bool primary = true;

	// Use this for initialization
	void Start () {
		objectivesCompleted = 0;
	}

	void OnTriggerEnter(Collider otherCollider)
	{
		if (otherCollider.gameObject.tag == "MainCamera") 
		{
			objectivesCompleted += 1;
		}
	}

	void OnTriggerExit(Collider otherCollider)
	{
		if (otherCollider.gameObject.tag == "MainCamera") 
		{
			objectivesCompleted -= 1;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	GameObject car = GameObject.FindGameObjectWithTag ("MainCamera");

	if(objectivesCompleted >= objectivesNum && car.rigidbody.velocity.magnitude < 1 && primary)
		{
			Application.LoadLevel(Application.loadedLevel + 1);
			Debug.Log ("hey");
		}
	}
}
