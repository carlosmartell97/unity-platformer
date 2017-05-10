using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finisher : MonoBehaviour {
	public string newscene;
	private bool finish = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (finish) {
			this.transform.Translate (0.09f, 0, 0);
		}
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.name == "goal") {
			Application.LoadLevel (newscene);
		}
	}

	public void Finish(){
		finish = true;
	}
}
