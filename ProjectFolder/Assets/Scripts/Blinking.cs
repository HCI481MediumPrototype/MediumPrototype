using UnityEngine;
using System.Collections;

/**
 * Attached to guitextures to have them blink and turn them off and on
 */ 
public class Blinking : MonoBehaviour 
{
	private float onTime = 1f;		// How many seconds it stays on for
	private float offTime = 0.5f;	// How many seconds it stays off for

	private bool activated = false;
	private bool visible = false;
	private float counter = 0;
	private GUITexture texture;

	
	// Use this for initialization
	void Start () {
		visible = activated;
		texture = this.GetComponent<GUITexture>();
	}


	/**
	 * Toggles on/off this blinking texture
	 */ 
	public void Toggle()
	{
		activated = !activated;
		counter = 0;

		if(activated)
			TurnOn();
		else
			TurnOff();
	}


	public void TurnOn()
	{
		visible = true;
		texture.enabled = true;
	}
	public void TurnOff()
	{
		visible = false;
		texture.enabled = false;
	}



	public bool isActive()
	{
		return activated;
	}


	void Update () {
		if (activated)
		{
			counter += Time.deltaTime;
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
