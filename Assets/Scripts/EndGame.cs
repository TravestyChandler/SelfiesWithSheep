using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	private Score scoreScript;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		scoreScript = this.GetComponent<Score>();
		//Debug.Log (scoreScript.GetScore());

		scoreText.text = "You selfied with " + scoreScript.GetScore () + " sheepses!";
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnPlayAgainClick() {
		scoreScript.SetScore (0);
		Application.LoadLevel (1);
	}
}
