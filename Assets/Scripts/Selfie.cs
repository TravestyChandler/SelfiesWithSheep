﻿using UnityEngine;
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
	private Text scoreText;

	// Use this for initialization
	void Start () {
		colliderList = new List<Collider2D>();
		lastCount = 0;
		spriteRenderer.renderer.enabled = false;
		scoreText = score.GetComponent<Text>();
		scoreText.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (colliderList.Count);
		// Show selfie area while space is held
		// Take selfie when space is released
		if(Input.GetKey ("space")) {
			spriteRenderer.renderer.enabled = true;
		}
		if(Input.GetKeyUp ("space")) {
			SelfieShot ();
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
		lastCount = colliderList.Count;
		if(lastCount > highCount) {
			highCount = lastCount;
			scoreText.text = highCount.ToString ();
		}
	}
}