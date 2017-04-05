using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacter : MonoBehaviour {

	public bool grab,movable,enemyA;
	bool jump, grabavb;
	public GameObject item=null;
	public GameObject particle;

	CharacterController controller;
	int side;
	float vertVel=7;
	public float speed = 6.0F;
	public float jumpSpeed = 20.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

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
			this.GetComponent<Animation>().CrossFade("Fly");
			particle.GetComponent<Renderer>().enabled = true;
		} else if (Input.GetAxis ("Horizontal") != 0 && controller.isGrounded) {
			this.GetComponent<Animation>().CrossFade("Walk");
			particle.GetComponent<Renderer>().enabled = false;
		} else if (Input.GetAxis ("Horizontal")== 0 && controller.isGrounded)  {
			this.GetComponent<Animation>().CrossFade("Idle");
			particle.GetComponent<Renderer>().enabled = false;
		}
		if (Input.GetAxis ("Horizontal") > 0 ) {
			side = 1;
			Quaternion rot = transform.localRotation;
 			rot.eulerAngles = new Vector3 (0.0f, 180, 0.0f);
 			transform.localRotation = rot;
		}else if(Input.GetAxis ("Horizontal") < 0){
			side = -1;
			Quaternion rot = transform.localRotation;
			rot.eulerAngles = new Vector3 (0.0f, 0, 0.0f);
			transform.localRotation = rot;
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
			item.transform.position = new Vector3(transform.position.x+(2*side),transform.position.y+3,transform.position.z);
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
			    	item.GetComponent<Rigidbody> ().AddForce (15, 20, 0, ForceMode.Impulse);


				} else if(point.x < item.transform.position.x)  {
			    	item.GetComponent<Rigidbody> ().AddForce (-15, 20, 0, ForceMode.Impulse);

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


	public void Movable(){
		movable = true;
	}
}
