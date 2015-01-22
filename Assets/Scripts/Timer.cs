using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	//public GameObject timer;
	private Text timerText;
	// Use this for initialization
	void Start () {
		timerText = this.GetComponent<Text>();
		FireTimerCoroutine();
	}

	void FireTimerCoroutine() {
		StartCoroutine(GameTimer ());
	}

	IEnumerator GameTimer() {
		int count = 30;
		while(count != 0) {
			yield return new WaitForSeconds(1.0f);
			count--;
			timerText.text = count.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(timerText.text == "0") {
			Application.LoadLevel (2);
		}
	}
}
