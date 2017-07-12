using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {
	public GameObject harasser;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.name=="Character"){
			
			harasser.GetComponent<Harraser> ().PlayerEntered ();
		}
	}

	void OnTriggerExit(Collider c){
		if (c.gameObject.name=="Character"){
			
			harasser.GetComponent<Harraser> ().PlayerLeft ();
		}
	}
}
