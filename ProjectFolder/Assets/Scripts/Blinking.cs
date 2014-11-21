using UnityEngine;
using System.Collections;

/**
 * Attached to guitextures to have them blink and turn them off and on
 */ 
public class Blinking : MonoBehaviour 
{
	private float onTime = 1f;		// How many seconds it stays on for
	private float offTime = 0.5f;	// How many seconds it stays off for
	public bool active = true;

	private bool visible;
	private float counter = 0;
	private GUITexture texture;

	
	// Use this for initialization
	void Start () {
		visible = active;
		texture = this.GetComponent<GUITexture>();
	}
	

	void Update () {
		if (active)
		{
			counter += Time.deltaTime;
			Debug.Log(counter + " : " + onTime);
			if(visible)
			{
				// Count up till we hit the time we hsould turn it off
				if(counter > onTime)
				{
					visible = false;
					counter = 0;
					texture.enabled = false;
				}
			}
			else
			{
				// Count up till it's time to turn it on
				if(counter > offTime)
				{
					visible = true;
					counter = 0;
					texture.enabled = true;
				}
			}
		}
	}
}
