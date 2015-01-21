using UnityEngine;
using System.Collections;

public class Sheep : MonoBehaviour {
	private SpriteRenderer spriteRenderer;
	public GameObject player;
	public Sprite[] sheepSprites;
	public float moveSpeed = 5f;
	public float moveDragMultiplier;
	public string feeling;
	public string personality;
	private bool moving, waiting;

	// Use this for initialization
	// Set personality traits and color of sheep
	void Awake () {
		DetermineTexture();
		DetermineFeeling ();
		DeterminePersonality ();
		SetMovement(feeling);
		moving = false;
		waiting = false;
	}

	// Randomizes sheep texture
	void DetermineTexture() {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		int r = (int)Random.Range (0.00f, 2.99f);
		spriteRenderer.sprite = sheepSprites[r];
	}

	// Randomizes "feeling" of sheep
	void DetermineFeeling() {
		int r = (int)Random.Range (0f, 1.999999f);
		if(r == 0) {
			feeling = "excited";
		} else if (r == 1) {
			feeling = "apathetic";
		}
	}

	// Randomizes "personality" of sheep
	void DeterminePersonality() {
		int r = (int)Random.Range (0f, 2.999999f);
		if(r == 0) {
			personality = "shy";
		} else if (r == 1) {
			personality = "apathetic";
		} else if (r == 2) {
			personality = "friendly";
		}
	}

	// Sets movement drag and speed based on feeling
	void SetMovement(string feels) {
		if(feels == "excited") {
			moveSpeed = 150;
			moveDragMultiplier = 0.02f;
		} else {
			moveSpeed = 100;
			moveDragMultiplier = 0.02f;
		}
	}

	// Update is called once per frame
	void Update () {
		if(!moving && !waiting) {
			StartCoroutine (WaitBabyWait (feeling));
		}
	}

	// Different movement frequency for different feelings
	IEnumerator WaitBabyWait(string feels) {
		waiting = true;
		float r;
		// get random wait time
		if(feels == "excited") 
			r = Random.Range (0f, 1.5f);
		else 
			r = Random.Range (1.0f, 3.0f);
		yield return new WaitForSeconds(r);
		Move(personality);
		waiting = false;
		moving = false;
	}

	// Different move characteristics for different personalities
	void Move(string feels) {
		moving = true;
		Vector2 direction = new Vector2(0f,0f);
		float distance = 0f;
		// get random direction
		if(feels == "shy") {
			direction = player.transform.position - this.transform.position;
			distance = direction.magnitude;
			//Debug.Log (distance);
			if(distance < 3f)
				direction = -direction;
			else
				direction = new Vector2(Random.Range (-Screen.width,Screen.width), Random.Range (-Screen.height,Screen.height));
		} else if(feels == "apathetic") {
			direction = new Vector2(Random.Range (-Screen.width,Screen.width), Random.Range (-Screen.height,Screen.height));
		} else {
			direction = player.transform.position - this.transform.position;
			distance = direction.magnitude;
			if(distance > 4f)
				direction = new Vector2(Random.Range (-Screen.width,Screen.width), Random.Range (-Screen.height,Screen.height));
			else if(distance < 1.5f)
				direction = new Vector2(0f,0f);
		}
		//Vector2 direction = new Vector2(Random.Range (-Screen.width,Screen.width), Random.Range (-Screen.height,Screen.height));
		direction.Normalize();
		// Rotate Sheep and move
		//this.transform.rotation = Utility.LookAt2D(this.gameObject.transform, direction);
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		angle -= 90;
		this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		this.rigidbody2D.AddForce (direction*moveSpeed);
		this.rigidbody2D.drag = moveSpeed * moveDragMultiplier;
	}	
}
