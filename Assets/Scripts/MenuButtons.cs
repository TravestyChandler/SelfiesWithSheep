using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCickStart() {
		Application.LoadLevel (1);
	}

	public void OnClickExit() {
		Application.Quit ();
	}
}
