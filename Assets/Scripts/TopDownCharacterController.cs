using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TopDownCharacterController : MonoBehaviour {

	//Movement variables
	public float moveSpeed = 5f;
	public float moveDragMultiplier, stillDragMultiplier;
	public bool moving = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);//new Vector3(Input.mousePosition.x, Input.mousePosition.y);
		this.transform.rotation = Utility.LookAt2D(this.gameObject.transform, mouseTarget);
		//Controls
		//Base Control Scheme
		// W,A,S,D movement
		if(Input.GetKey(KeyCode.W)){
			rigidbody2D.AddForce(Vector2.up * moveSpeed);
			rigidbody2D.drag = moveSpeed * moveDragMultiplier;
			moving = true;
		}
		if(Input.GetKey(KeyCode.S)){
			rigidbody2D.AddForce(-Vector2.up * moveSpeed);
			rigidbody2D.drag = moveSpeed * moveDragMultiplier;
			moving = true;
		}
		if(Input.GetKey(KeyCode.D)){
			rigidbody2D.AddForce(Vector2.right * moveSpeed);
			rigidbody2D.drag = moveSpeed * moveDragMultiplier;
			moving = true;
		}
		if(Input.GetKey(KeyCode.A)){
			rigidbody2D.AddForce(-Vector2.right * moveSpeed);
			rigidbody2D.drag = moveSpeed * moveDragMultiplier;
			moving = true;
		}
		if(!moving){
			rigidbody2D.drag = moveSpeed * stillDragMultiplier;
		}
		moving = false;
	}
}
