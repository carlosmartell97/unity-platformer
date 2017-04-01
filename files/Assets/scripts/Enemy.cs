using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public List<Transform> path;
	public int currentNode;
	public float treshold, speed;

	public Symbol cerca, lejos;
	public State current;

	// Use this for initialization
	void Start () {
		cerca = new Symbol("cerca");
		lejos = new Symbol("lejos");

		State standBy = new State("standby");
		State attack = new State("attack");

		attack.AddNeighbor(cerca,attack);
		attack.AddNeighbor(lejos,standBy);

		standBy.AddNeighbor(lejos,standBy);
		standBy.AddNeighbor(cerca,attack);

		current = standBy;
	}
	
	// Update is called once per frame
	void Update () {
		if(current.Name=="attack"){
			this.transform.LookAt(path[currentNode].transform.position);
			this.transform.Translate(transform.forward*speed,Space.World);
		}
		else if(current.Name=="standBy"){

		}
	}
}
