using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {
	
	public GameObject wall,redCube,blueCube,greenCube;
	public int color;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.name == "endpoint") {
			//Destroy (gameObject);
			Destroy (wall);
		}
		//Debug.Log(this.gameObject.name+": "+c.gameObject.name);
		if(this.gameObject.name=="redF" && c.gameObject.name=="endR"){
			Destroy(redCube);
			if(++mainCharacter.progress==3) Debug.Log("YOU WON!");
		}
		else if(this.gameObject.name=="blueF" && c.gameObject.name=="endB"){
			Destroy(blueCube);
			if(++mainCharacter.progress==3) Debug.Log("YOU WON!");
		}
		else if(this.gameObject.name=="greenF" && c.gameObject.name=="endG"){
			Destroy(greenCube);
			if(++mainCharacter.progress==3) Debug.Log("YOU WON!");
		}
	}
}
