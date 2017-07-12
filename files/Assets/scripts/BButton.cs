using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BButton : MonoBehaviour {
	public GameObject bossfight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider c){
		if(c.gameObject.name=="Box"){
			bossfight.GetComponent<BossFight> ().Stage ();
			this.enabled = false;
		}
	}
}
