using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacter : MonoBehaviour {

	public int xVelocity, yJump;
	public Rigidbody r;

	// Use this for initialization
	void Start () {
		//r = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		float jump = Input.GetAxis ("Jump");
		transform.Translate (horizontal * xVelocity * Time.deltaTime, 0, 0,Space.World);

		if(Input.GetKeyDown(KeyCode.UpArrow)){
			r.AddRelativeForce(0, yJump, 0, ForceMode.Impulse);
		}
	}

	void OnCollisionEnter(Collision c){
		Debug.Log("with "+c.gameObject.name);
	}
}
