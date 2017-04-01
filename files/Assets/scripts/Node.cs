using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public List<Node> neighbors;
	public List<Node> history;
	public float g, h;

	public float F{
		get{ return g+h; }
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		for(int i=0; i<neighbors.Count; i++){
			Gizmos.DrawLine(this.transform.position,neighbors[i].transform.position);
		}
		Gizmos.DrawSphere(this.transform.position,1f);
	}
}
