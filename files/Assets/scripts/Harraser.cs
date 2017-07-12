using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Harraser : MonoBehaviour {

	public GameObject standByNode;
	public float treshold;
	private float pos, cpos, npos, speed, distance;

	public Symbol playerentered, playerleft, safespot;
	public State current;
	Node mostRecentNode;

	public GameObject character;

	// Use this for initialization
	void Start () {

		playerentered = new Symbol("playerentered");
		playerleft = new Symbol("playerleft");
		safespot = new Symbol("safespot");

		State standBy = new State("standBy");
		State harrasing = new State("harrasing");
		State returning = new State("returning");

		standBy.AddNeighbor(playerentered,harrasing);
		standBy.AddNeighbor(playerleft,standBy);
		standBy.AddNeighbor(safespot,standBy);

		harrasing.AddNeighbor(playerentered,harrasing);
		harrasing.AddNeighbor(playerleft,returning);
		harrasing.AddNeighbor(safespot,harrasing);

		returning.AddNeighbor(playerentered,harrasing);
		returning.AddNeighbor(playerleft,returning);
		returning.AddNeighbor(safespot,standBy);

		current = standBy;
	}

	// Update is called once per frame
	void Update () {
		pos = this.transform.position.x;
		if(current.Name=="standBy"){
			
		} else if(current.Name=="harrasing"){
			speed=10;
			cpos = character.transform.position.x;
			distance = pos-cpos;
			if (Mathf.Abs (distance) < treshold) {

			} else if (distance > 0) {
				LookLeft ();
				transform.Translate (0, 0, speed * Time.deltaTime);
			} else if (distance < 0) {
				LookRight ();
				transform.Translate (0, 0, speed * Time.deltaTime);
			}
		} else if(current.Name=="returning"){
			speed=15;
			npos = standByNode.transform.position.x;
			distance = pos-npos;
			if (Mathf.Abs (distance) < treshold) {

			} else if (distance > 0) {
				LookLeft ();
				transform.Translate (0, 0, speed * Time.deltaTime);
			} else if (distance < 0) {
				LookRight ();
				transform.Translate (0, 0, speed * Time.deltaTime);
			}
		}

	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.name=="standByNode"){
			current = current.ApplySymbol (safespot);
		}
	}

	public void PlayerEntered(){
		current = current.ApplySymbol (playerentered);
	}

	public void PlayerLeft(){
		current = current.ApplySymbol (playerleft);
	}

	void LookRight(){
		Quaternion rot = transform.localRotation;
		rot.eulerAngles = new Vector3 (0.0f, 90, 0.0f);
		transform.localRotation = rot;
	}
	void LookLeft(){
		Quaternion rot = transform.localRotation;
		rot.eulerAngles = new Vector3 (0.0f, -90, 0.0f);
		transform.localRotation = rot;
	}
}
