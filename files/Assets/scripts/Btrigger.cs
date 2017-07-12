using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OntriggerEnter(Collider c){
		Debug.Log (c.gameObject.name);
	}

	void OnControllerColliderHit(ControllerColliderHit c){
		Debug.Log (c.gameObject.name);
	}
}
