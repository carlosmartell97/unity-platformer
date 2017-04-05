using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Flag : MonoBehaviour {
	public string newscene;

	private float timer,timerMax;
	
	public GameObject winT,wall,redCube,blueCube,greenCube;
	public int color;
	// Use this for initialization
	void Start () {
		winT = GameObject.Find("winT");
		winT.GetComponent<Text> ().enabled = false;
		timerMax = 3;
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
			Destroy (gameObject);
			Destroy(redCube);
			if (++mainCharacter.progress == 3) {
				winT.GetComponent<Text> ().enabled = true;
				while (timer < timerMax) {
					timer += Time.deltaTime;
				
				}
				Application.LoadLevel (newscene);
			}
		}
		else if(this.gameObject.name=="blueF" && c.gameObject.name=="endB"){
			Destroy (gameObject);
			Destroy(blueCube);
			if (++mainCharacter.progress == 3) {
				
				winT.GetComponent<Text> ().enabled = true;
				while (timer < timerMax) {
					timer += Time.deltaTime;
				
				}
				Application.LoadLevel (newscene);
			}
		}
		else if(this.gameObject.name=="greenF" && c.gameObject.name=="endG"){
			Destroy (gameObject);
			Destroy(greenCube);
			if (++mainCharacter.progress == 3) {
				winT.GetComponent<Text> ().enabled = true;
				while (timer < timerMax) {
					timer += Time.deltaTime;
				}
				Application.LoadLevel (newscene);
			}
		}
			
	}
		
}
