using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	public GameObject dissapear,appear,loc;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnTriggerEnter(Collider c){
		if (c.gameObject.name == "Box") {
			if (dissapear != null) {
				Destroy (dissapear);
			}
			if (appear != null) {
				appear.transform.position = loc.transform.position;
			}
		}
	}
}
