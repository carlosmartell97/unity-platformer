using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

	public GameObject character;
	private Vector3 offset;
	private bool alt;

	// Use this for initialization
	void Start () {
		offset = transform.position-character.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!alt) {
			transform.position = character.transform.position + offset;
		} else {
			transform.position = new Vector3 (260f,41.48f,-40f);
		}
	}

	public void Change(){
		alt = true;
	}
}
