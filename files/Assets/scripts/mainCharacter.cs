using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacter : MonoBehaviour {

	Rigidbody r;
	public bool grab;
	bool jump, grabavb;
	public GameObject item=null;
	public GameObject laserShot,platformUp,platformFront;
	CharacterController controller;
	int side;
	float vertVel=7;
	public float speed = 6.0F;
	public float jumpSpeed = 20.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	int fps=0;
	int platformUpPosition=-5; int platformUpwardsDirection=1;
	int platformFrontPosition=-4; int platformFrontDirection=-1;
	public static int progress=0;
	public GameObject enemy;
	public int enemyDistanceTreshold;
	public Node characterOnNode;

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
				//Debug.Log ("e");
				grab = true;
			}
		}

		if(item!=null){
			float distanceToItem = Vector3.Distance(this.transform.position,item.transform.position);
			if (Input.GetKeyDown (KeyCode.R) || distanceToItem>5) {
				grab = false;
				item = null;
			}
		}

		if (grab && item!=null) {
			item.transform.position = new Vector3(transform.position.x+(2*side),transform.position.y+2,transform.position.z);
			if(item!=null && item.name=="Flag"){
				// current = current.ApplaySymbol(cubecarried)
				GameObject.Find ("Enemy").GetComponent<Enemy> ().current = 
					GameObject.Find ("Enemy").GetComponent<Enemy> ().current.ApplySymbol (
						GameObject.Find ("Enemy").GetComponent<Enemy> ().cubeCarried
					);
			}
		}

		float distance = Vector3.Distance(this.transform.position,enemy.transform.position);
		if (distance < enemyDistanceTreshold) {
			// current = current.ApplySymbol(cerca)
			/*enemy.GetComponent<Enemy>().current = 
				enemy.GetComponent<Enemy>().current.ApplySymbol(
					enemy.GetComponent<Enemy>().cerca
				);*/
		} else {
			// current = current.ApplySymbol(lejos)
			/*enemy.GetComponent<Enemy>().current = 
				enemy.GetComponent<Enemy>().current.ApplySymbol(
					enemy.GetComponent<Enemy>().lejos
				);*/
		}
	}

	void FixedUpdate(){
		fps++;
		if (fps % 5 == 0) {
			if (platformUpPosition > 21) {
				platformUpwardsDirection *= -1;
			} else if (platformUpPosition< -5) {
				platformUpwardsDirection *= -1;
			}
			platformUpPosition+= platformUpwardsDirection;
		}
		Vector3 upwards = new Vector3 (232,platformUpPosition,0);
		platformUp.transform.position = upwards;
		if(fps%6==0){	
			if (platformFrontPosition > 0) {
				platformFrontDirection *= -1;
			} else if (platformFrontPosition < -3) {
				platformFrontDirection *= -1;
			}
			platformFrontPosition+=platformFrontDirection;
		}
		Vector3 frontBack= new Vector3(245,2,platformFrontPosition);
		platformFront.transform.position = frontBack;

		if(fps%45==0){
			//Debug.Log("RUN "+fps);
			if (fps % 90 == 0) {
				laserShot.active = true;
			} else {
				laserShot.active = false;
			}
		}
	}

	void OnControllerColliderHit(ControllerColliderHit c){
		//Debug.Log (c.gameObject.name);
		if (item==null && c.gameObject.name == "Box") {
			grabavb = true;
			item = c.gameObject;
		}

		if (item==null && (c.gameObject.name == "Flag" || c.gameObject.name == "redF" || c.gameObject.name == "blueF" || c.gameObject.name == "greenF")) {
			grabavb = true;
			item = c.gameObject;
			GameObject.Find ("Enemy").GetComponent<Enemy> ().target = c.gameObject;
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

	void OnTriggerEnter( Collider c){
		//Debug.Log(c.gameObject.name);
		if(c.gameObject.layer==8){
			characterOnNode = GameObject.Find (c.gameObject.name).GetComponent<Node> ();
		}
		if (c.gameObject.name == "deathZone") {
			die();
		}
	}
}
