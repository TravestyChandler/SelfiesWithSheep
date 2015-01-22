using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Selfie : MonoBehaviour {

	//private EdgeCollider2D col;
	public GameObject player;
	public SpriteRenderer spriteRenderer;
	public List<Collider2D> colliderList;
	public int lastCount, highCount;
	public GameObject score;
	private AudioSource audioSrc;
	private Text scoreText;
	private Score staticScore;
	private Animator playerAnim;
	public SpriteRenderer spr;
	// Use this for initialization
	void Start () {
		colliderList = new List<Collider2D>();
		lastCount = 0;
		spriteRenderer.renderer.enabled = false;
		staticScore = score.GetComponent<Score>();
		scoreText = score.GetComponent<Text>();
		scoreText.text = "0\nSHEEPSES";

		playerAnim = player.GetComponent<Animator>();
		audioSrc = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (colliderList.Count);
		// Show selfie area while space is held
		// Take selfie when space is released
		if(Input.GetKeyDown ("space")) {
			playerAnim.SetBool ("Selfieing", true);
			spriteRenderer.renderer.enabled = true;
		}
		if(Input.GetKeyUp ("space")) {
			SelfieShot ();
			playerAnim.SetBool ("Selfieing", false);
			spriteRenderer.renderer.enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag != "Bounds") 
			colliderList.Add(col);
		//Debug.Log (count);
	}

	void OnTriggerExit2D(Collider2D col) {
		if(col.gameObject.tag != "Bounds") 
			colliderList.Remove(col);

	}

	// Take the selfie! Update the last and high counts!
	void SelfieShot() {
		audioSrc.Play ();
		lastCount = colliderList.Count;
		StartCoroutine(Flash());
		if(lastCount > highCount) {
			highCount = lastCount;
			staticScore.SetScore (highCount);
			scoreText.text = highCount.ToString () + "\nSHEEPSES";
		}
	}

	IEnumerator Flash(){
		float time = 0.0f;
		while(time < 0.01f){
			time += 0.005f;
			Color col = spr.color;
			col.a = time/0.01f;
			spr.color = col;
			yield return new WaitForSeconds(0.005f);
		}
		time = 0.1f;
		while(time > 0f){
			time -= 0.01f;
			Color col = spr.color;
			col.a = time/0.1f;
			spr.color = col;
			yield return new WaitForSeconds(0.01f);
		}
	}
}
