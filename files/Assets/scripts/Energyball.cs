using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energyball : MonoBehaviour {
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (10, 0, 0,ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
