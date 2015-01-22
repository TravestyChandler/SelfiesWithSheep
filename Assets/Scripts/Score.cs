using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int score;

	public void SetScore(int s) {
		score = s;
		Debug.Log (score);
	}

	public int GetScore() {
		return score;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
