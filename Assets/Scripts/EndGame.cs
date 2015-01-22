using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	private Score scoreScript;

	// Use this for initialization
	void Start () {
		scoreScript = this.GetComponent<Score>();
		Debug.Log (scoreScript.GetScore());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
