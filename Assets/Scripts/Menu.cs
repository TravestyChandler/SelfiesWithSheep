using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameObject tweetObject;
	public GameObject panel1, panel2, panelOptions;
	private Image tweet;
	private bool doneFading;

	// Use this for initialization
	void Start () {
		doneFading = false;
		tweet = tweetObject.GetComponent<Image>();
		FireFadeCoroutine(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(doneFading) {
			panel1.SetActive (true);
			panel2.SetActive(true);
		}
	}	

	void FireFadeCoroutine(bool d) {
		StartCoroutine(FadeTweet (d));
	}

	IEnumerator FadeTweet(bool d) {
		for(float f=0f; f <=1.0f; f+=0.02f) {
			Color c = tweet.color;
			c.a = f;
			tweet.color = c;
			yield return new WaitForSeconds(0.05f);
		}
		yield return new WaitForSeconds(1.5f);
		for(float f=1f; f >=0.0f; f-=0.02f) {
			Color c = tweet.color;
			c.a = f;
			tweet.color = c;
			yield return new WaitForSeconds(0.02f);
		}
		yield return new WaitForSeconds(1.5f);
		doneFading = true;
	}

	public void OnCickStart() {
		Application.LoadLevel (1);
	}
	
	public void OnClickOptions() {
		panel1.SetActive (false);
		panelOptions.SetActive(true);
	}
	
	public void OnClickBack() {
		panelOptions.SetActive(false);
		panel1.SetActive (true);
	}
}
