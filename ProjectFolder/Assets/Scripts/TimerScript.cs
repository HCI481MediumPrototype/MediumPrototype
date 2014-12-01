using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

	public float time = 100f;

	public Text label;
	// Use this for initialization
	void Start () {
		label = GetComponent<Text>();
	}

	// Update is called once per frame
	void FixedUpdate () {

	if(Time.timeSinceLevelLoad > time)
		{
			Application.LoadLevel (Application.loadedLevel);
		}
		label.text = ((int)time - (int)Time.timeSinceLevelLoad).ToString();
	}
}
