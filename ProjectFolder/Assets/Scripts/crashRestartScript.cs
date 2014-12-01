using UnityEngine;
using System.Collections;

public class crashRestartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
