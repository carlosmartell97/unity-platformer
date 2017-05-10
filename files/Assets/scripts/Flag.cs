using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Flag : MonoBehaviour {
	
	public GameObject winT,wall,Cube,finisher;
	public int color;
	// Use this for initialization
	void Start () {
		winT.GetComponent<Text> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.name == "endpoint") {
			Destroy (gameObject);
			Destroy (wall);
			Destroy (GameObject.Find ("Enemy"));
		}
		//Debug.Log(this.gameObject.name+": "+c.gameObject.name);
		if(this.gameObject.name=="redF" && c.gameObject.name=="endR"){
			Destroy (gameObject);
			Destroy(Cube);
			if (++mainCharacter.progress == 3) {
				winT.GetComponent<Text> ().enabled = true;
				finisher.GetComponent<finisher> ().Finish();

			}
		}
		else if(this.gameObject.name=="blueF" && c.gameObject.name=="endB"){
			Destroy (gameObject);
			Destroy(Cube);
			if (++mainCharacter.progress == 3) {
				winT.GetComponent<Text> ().enabled = true;
				finisher.GetComponent<finisher> ().Finish();

			}
		}
		else if(this.gameObject.name=="greenF" && c.gameObject.name=="endG"){
			Destroy (gameObject);
			Destroy(Cube);
			if (++mainCharacter.progress == 3) {
				winT.GetComponent<Text> ().enabled = true;
				finisher.GetComponent<finisher> ().Finish();
			}
		}
			
	}
		
}
