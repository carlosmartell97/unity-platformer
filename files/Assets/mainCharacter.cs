using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacter : MonoBehaviour {

	public int xVelocity, yJump;
	Rigidbody r;
	bool jump,grab, grabavb;
	GameObject item;
	public GameObject laserShot;
	int side;

	int fps=0;
	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis ("Horizontal");
		transform.Translate (horizontal * xVelocity * Time.deltaTime, 0, 0,Space.World);

		if (horizontal > 0) {
			side = 1;
		}else if (horizontal < 0) {
			side = -1;
		}

		if(Input.GetKeyDown(KeyCode.W)){
			if (jump) {
				r.AddRelativeForce (0, yJump, 0, ForceMode.Impulse);
				jump = false;
			}
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			Debug.Log ("e");
			if (grabavb) {
				grab = true;
				Debug.Log (grab);
			}
		}

		if (grab) {
			item.transform.position = new Vector3(transform.position.x+(2*side),transform.position.y+1,transform.position.z);
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

	void OnCollisionEnter(Collision c){
		if (c.gameObject.name [0] == 'F') {
			jump = true;
		}
			
		if (c.gameObject.name == "Box") {
			grabavb = true;
			item = c.gameObject;
			jump = true;
		}

		if (c.gameObject.name == "Flag") {
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
