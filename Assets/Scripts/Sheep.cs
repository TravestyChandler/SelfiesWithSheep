using UnityEngine;
using System.Collections;

public class Sheep : MonoBehaviour {
	private SpriteRenderer spriteRenderer;
	public GameObject player;
	public Sprite[] sheepSprites;
	public float moveSpeed = 5f;
	public float moveDragMultiplier, stillDragMultiplier;
	private string feeling;
	private string personality;
	private int move = 1;
	private bool moving, waiting;

	// Use this for initialization
	void Awake () {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		int r = (int)Random.Range (0.00f, 2.99f);
		spriteRenderer.sprite = sheepSprites[r];
		int r2 = (int)Random.Range (0f, 1.999999f);
		if(r2 == 0) {
			feeling = "excited";
		} else if (r2 == 1) {
			feeling = "apathetic";
		}
		moving = false;
		waiting = false;
	}
	
	// Update is called once per frame
	void Update () {
		/*if(move > 0) {
			StartCoroutine(WaitToMove(feeling, "shy"));
		}*/
		if(!moving && !waiting) {
			StartCoroutine (WaitBabyWait ());
		}
	}

	IEnumerator WaitBabyWait() {
		waiting = true;
		// get random wait time
		yield return new WaitForSeconds(1.5f);
		Move();
		waiting = false;
		moving = false;
	}

	void Move() {
		moving = true;
		Vector2 direction = new Vector2(Random.Range (-Screen.width,Screen.width), Random.Range (-Screen.height,Screen.height));
		direction.Normalize();
		this.rigidbody2D.AddForce (direction*moveSpeed);
		this.rigidbody2D.drag = moveSpeed * moveDragMultiplier;
	}

	IEnumerator WaitToMove(string f, string p) {
		move = 0;
		float t = 0;;
		float distance = Vector2.Distance(this.transform.position, player.transform.position);
		if(distance > 3) {
			Vector2 direction = new Vector2 (0f,0f);
			if(f == "excited")
				t = Random.Range (0f, 2f);
			else if (p == "apathetic") {
				t = Random.Range (1f, 3f);
			}
			if(p == "shy") {
				direction = transform.position - player.transform.position;
				direction.Normalize();
			} else if (p == "apathetic") {

			} else if (p == "friendly") {

			}
			yield return new WaitForSeconds(t);
			// move
			this.rigidbody2D.AddForce (direction*moveSpeed);
			this.rigidbody2D.drag = moveSpeed * moveDragMultiplier;
		}
		yield return new WaitForSeconds(t);
		move = 1;
	}
}
