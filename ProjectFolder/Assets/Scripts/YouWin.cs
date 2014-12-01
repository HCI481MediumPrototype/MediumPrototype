using UnityEngine;
using System.Collections;

public class YouWin : MonoBehaviour {

	bool finished = false;	 // Turn to true to display message


	void OnTriggerEnter(Collider otherCollider)
	{
		if (otherCollider.gameObject.tag == "MainCamera") 
		{
			finished = true;
		}
	}

	void OnGUI()
	{
		if(finished)
		{
			GUI.Box(new Rect((Screen.width-400)/2, (Screen.height-300)/2, 400, 300), "You Win!");
		}
	}
}
