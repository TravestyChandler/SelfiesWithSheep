using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameObject tweetObject;
	public GameObject panel1, panel2, panelOptions;
	private Image tweet;
	private bool doneFading;
	public bool clicked = false;
	public AudioSource audioSrc;
	// Use this for initialization
	void Start () {
		doneFading = false;
		tweet = tweetObject.GetComponent<Image>();
		FireFadeCoroutine(true);
		audioSrc = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			clicked = true;
		}
		if(doneFading) {
			panel1.SetActive (true);
			panel2.SetActive(true);
			if(!audioSrc.isPlaying)
				audioSrc.Play ();
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
			if(clicked){
				break;
			}
			yield return new WaitForSeconds(0.05f);
		}
		float time = 0;
		while(time < 2.5f){
			if(clicked){
				break;
			}
			time += 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
		for(float f=1f; f >=0.0f; f-=0.02f) {
			Color c = tweet.color;
			c.a = f;
			tweet.color = c;
			if(clicked){
				break;
			}
			yield return new WaitForSeconds(0.02f);
		}
		time = 0;
		while(time < 2.5f){
			if(clicked){
				break;
			}
			time += 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
		if(clicked){
			Color c = tweet.color;
			c.a = 0.0f;
			tweet.color = c;
		}
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
