using UnityEngine;
using System.Collections;

/**
 * Controls the dashboard functions of the car, like turn signals,
 * displaying mileage, oil, tire pressure etc.
 */ 
public class DashboardController : MonoBehaviour 
{
	private Blinking leftTurnSignal;
	private Blinking rightTurnSignal;

	private bool menuVisible = false;
	private string pauseString = "<b><color=cyan>Controls</color></b>" +
		"\n W: Put pressure on Accelerator" +
		"\n S: Reverse car" +
		"\n A: Turn left" +
		"\n S: Turn right" +
		"\n Q: Toggle left turn signal" +
		"\n E: Toggle right turn signal\n" +
		"\n Space: Hold down to brake" +
		"\n Escape: Toggle controls menu" +
		"\n\n Program coded for Cmpt 481\n\n" +
		" Created by:\n Michael Long \n Kevin Squires \n William Selby \n Yacine Boulfiza";

	void Start () 
	{
		leftTurnSignal = GameObject.Find("Left Turn Signal").GetComponent<Blinking>();
		rightTurnSignal = GameObject.Find("Right Turn Signal").GetComponent<Blinking>();
	}
	

	void Update () 
	{
		if (Input.GetButtonDown("Left Turn Signal"))
		{
			leftTurnSignal.Toggle();
		}
		else if (Input.GetButtonDown("Right Turn Signal"))
		{
			rightTurnSignal.Toggle();
		}
		else if (Input.GetButtonDown("Menu"))
		{
			menuVisible = !menuVisible;
		}
	}


	void OnGUI()
	{
		if(menuVisible)
		{
			GUI.Box(new Rect((Screen.width-400)/2, (Screen.height-300)/2, 400, 300), pauseString);
		}
	}
}
