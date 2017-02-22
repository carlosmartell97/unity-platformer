using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacter : MonoBehaviour {

	public int xVelocity, yJump;
	public Rigidbody r;
	bool jump;

	// Use this for initialization
	void Start () {
		//r = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		transform.Translate (horizontal * xVelocity * Time.deltaTime, 0, 0,Space.World);

		if(Input.GetKeyDown(KeyCode.UpArrow)){
			if (jump) {
				r.AddRelativeForce (0, yJump, 0, ForceMode.Impulse);
				jump = false;
			}
		}
	}

	void OnCollisionEnter(Collision c){
		Debug.Log("with "+c.gameObject.name);

		if (c.gameObject.name [0] == 'F') {
			jump = true;
		}
	}
}
