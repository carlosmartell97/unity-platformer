using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacter : MonoBehaviour {

	public bool grab,movable,enemyA;
	bool jump, grabavb;
	public GameObject item=null;
	public GameObject particle,spawn,spawn2,camera,BossFight;

	CharacterController controller;
	int side;
	float vertVel=7;
	public float speed = 6.0F;
	public float jumpSpeed = 20.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	private Transform cam;

	public static int progress=0;
	public GameObject enemy;
	public int enemyDistanceTreshold;
	public Node characterOnNode;
	private float distance = 13.5f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		particle.GetComponent<Renderer>().enabled = false;

	}

	// Update is called once per frame
	void Update () {

		if (!controller.isGrounded){
			Jetpack ();
		} else if (Input.GetAxis ("Horizontal") != 0 && controller.isGrounded) {
			Walk ();
		} else if (Input.GetAxis ("Horizontal")== 0 && controller.isGrounded)  {
			Idle ();
		}
		if (Input.GetAxis ("Horizontal") > 0 ) {
			LookRight ();
		}else if(Input.GetAxis ("Horizontal") < 0){
			LookLeft ();
		}


		moveDirection = new Vector3 (Input.GetAxis ("Horizontal")*side*-1, 0, 0);
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
			item.transform.position = new Vector3(transform.position.x+(2.8f*side),transform.position.y+2,transform.position.z);
			if(item!=null && item.name=="Flag" && enemyA){
				// current = current.ApplaySymbol(cubecarried)
				GameObject.Find ("Enemy").GetComponent<Enemy> ().current =
					GameObject.Find ("Enemy").GetComponent<Enemy> ().current.ApplySymbol (
						GameObject.Find ("Enemy").GetComponent<Enemy> ().cubeCarried
					);
				// showEnemyWarning = true
				GameObject.Find("Enemy").GetComponent<Enemy>().showEnemyWarning = true;
			}
		}

		if (Input.GetMouseButtonUp (0)) {
		   if(item!=null && grab){
		    //Debug.Log ("yey");
				Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);    
				Vector3 point = ray.origin + (ray.direction * distance);    
				grab = false;
			    if (point.x >= item.transform.position.x) {
					item.GetComponent<Rigidbody> ().velocity = new Vector3 (15, 10, 0);

				} else if(point.x < item.transform.position.x)  {
					item.GetComponent<Rigidbody> ().velocity = new Vector3 (-15, 10, 0);
			    }
			    item = null;
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
			if (enemyA) {
				GameObject.Find ("Enemy").GetComponent<Enemy> ().target = c.gameObject;
			}
		}

		if(c.gameObject.name=="laserShot"){
			die();
		}

		if (c.gameObject.name == "Floor (74)") {
			Destroy (c.gameObject);
		}
	}

	void OnCollisionExit(Collision c){
		if (c.gameObject.name == "Box" || c.gameObject.name == "Flag") {
			grabavb = false;
		}
	}

	void die(){
		this.transform.position = spawn.transform.position;
	}

	void OnTriggerEnter( Collider c){
		//Debug.Log(c.gameObject.name);
		if(c.gameObject.layer==8){
			characterOnNode = GameObject.Find (c.gameObject.name).GetComponent<Node> ();
		}
		if (c.gameObject.name == "deathZone") {
			die();
		}
		if (c.gameObject.name == "Btrigger") {
			camera.GetComponent<camera> ().Change ();
			spawn = spawn2;
		}
		/*if (c.gameObject.name == "fwall") {
			float x = transform.position.x;
			while (transform.position.x > x - 10) {
				controller.Move (new Vector3 (-1, 0, 0));
			}
		}*/

	}

	void Jetpack(){
		this.GetComponent<Animation>().CrossFade("Fly");
		particle.GetComponent<Renderer>().enabled = true;
	}
	void Walk (){
		this.GetComponent<Animation>().CrossFade("Walk");
		particle.GetComponent<Renderer>().enabled = false;
	}
	void Idle(){
		this.GetComponent<Animation>().CrossFade("Idle");
		particle.GetComponent<Renderer>().enabled = false;
	}

	void LookRight(){
		side = 1;
		Quaternion rot = transform.localRotation;
		rot.eulerAngles = new Vector3 (0.0f, 180, 0.0f);
		transform.localRotation = rot;
	}

	void LookLeft(){
		side = -1;
		Quaternion rot = transform.localRotation;
		rot.eulerAngles = new Vector3 (0.0f, 0, 0.0f);
		transform.localRotation = rot;
	}

	public void Movable(){
		movable = true;
	}
}
