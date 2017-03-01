using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacter : MonoBehaviour {

	Rigidbody r;
	bool jump,grab, grabavb;
	GameObject item;
	public GameObject laserShot;
	CharacterController controller;
	int side;
	float vertVel=7;
	public float speed = 6.0F;
	public float jumpSpeed = 20.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	int fps=0;
	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody> ();
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") > 0) {
			side = 1;
		}else if(Input.GetAxis ("Horizontal") < 0){
			side = -1;
		}

		moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, 0);
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= speed;

		if (controller.isGrounded) {
			if (Input.GetButton ("Jump"))
				vertVel = jumpSpeed;
		}
		vertVel -= gravity * Time.deltaTime;
		moveDirection.y = vertVel;
		controller.Move(moveDirection * Time.deltaTime);
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);

		if (Input.GetKeyDown (KeyCode.E)) {
			if (grabavb) {
				Debug.Log ("e");
				grab = true;
			}
		}

		if (grab) {
			item.transform.position = new Vector3(transform.position.x+(2*side),transform.position.y+2,transform.position.z);
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			grab = false;
		}
	}

	void FixedUpdate(){
		fps++;
		if(fps%45==0){
			Debug.Log("RUN "+fps);
			if (fps % 90 == 0) {
				laserShot.active = true;
			} else {
				laserShot.active = false;
			}
		}
	}

	void OnControllerColliderHit(ControllerColliderHit c){
		Debug.Log (c.gameObject.name);
		if (c.gameObject.name == "Box") {
			grabavb = true;
			item = c.gameObject;
		}

		if (c.gameObject.name == "Flag" || c.gameObject.name == "redF" || c.gameObject.name == "blueF" || c.gameObject.name == "greenF") {
			grabavb = true;
			item = c.gameObject;
		}

		if(c.gameObject.name=="laserShot"){
			die();
		}
	}

	void OnCollisionExit(Collision c){
		if (c.gameObject.name == "Box") {
			grabavb = false;
		}
		if (c.gameObject.name == "Flag") {
			grabavb = false;
		}
	}

	void die(){
		this.transform.position = new Vector3 (-37,2,0);
	}
}
