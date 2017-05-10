using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFight : MonoBehaviour {
	public GameObject c,c1,c2,c3,c4,winT,b1,b2,p1,p2;
	private int stage=0;
	bool front,first,second;
	int side=1;
	int c1side,cside,c2side,c3side,c4side,p1side,p2side;
	float c1rand,crand,c2rand,c3rand,c4rand;

	// Use this for initialization
	void Start () {
		c1side = 1;
		cside =  1;
		c2side = 1;
		c3side = 1;
		c4side = 1;
		p1side = 1;
		p2side = -1;

		crand = Random.value;
		c1rand = Random.value;
		c2rand = Random.value;
		c3rand = Random.value;
		c4rand = Random.value;

		winT.GetComponent<Text> ().enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (stage == 1) {
			if (transform.position.x<200) {
				side = 1;
			} else if (transform.position.x>250) {
				side = -1;
			}
			transform.Translate (0, -1*side*0.1f, 0);


		} else if (stage == 2) {
			if (!first) {
				p1.transform.position = new Vector3 (223.3f, 40.2f, 0.6f);
				p2.transform.position = new Vector3 (228.8f, 38, 0.6f);
				this.transform.position = new Vector3 (209, 32.2f, 0.6f);
				first = true;
			}

			if (c.transform.position.y<40) {
				cside = -1;
			} else if (c.transform.position.y>120+(20*crand)) {
				cside = 1;
			}
			c.transform.Translate (0, -1*cside*0.8f, 0);


			if (c1.transform.position.y<40) {
				c1side = -1;
			} else if (c1.transform.position.y>120+(20*c1rand)) {
				c1side = 1;
			}
			c1.transform.Translate (0, -1*c1side*0.8f, 0);


			if (c2.transform.position.y<40) {
				c2side = -1;
			} else if (c2.transform.position.y>120+(20*c2rand)) {
				c2side = 1;
			}
			c2.transform.Translate (0, -1*c2side*0.8f, 0);


			if (c3.transform.position.y<40) {
				c3side = -1;
			} else if (c3.transform.position.y>100+(20*c3rand)) {
				c3side = 1;
			}
			c3.transform.Translate (0, -1*c3side*0.8f, 0);


			if (c4.transform.position.y<40) {
				c4side = -1;
			} else if (c4.transform.position.y>100+(20*c4rand)) {
				c4side = 1;
			}
			c4.transform.Translate (0, -1*c4side*0.8f, 0);


			if (first) {
				
				if (p1.transform.position.y < 23) {
					p1side = -1;
				} else if (p1.transform.position.y > 39 ) {
					p1side = 1;
				}
				p1.transform.Translate (0, -1*p1side*0.1f, 0);

				if (p2.transform.position.y < 38) {
					p2side = -1;
				} else if (p2.transform.position.y > 55) {
					p2side = 1;
				}
				p2.transform.Translate (0,-1*p2side*0.1f, 0);

			}

		} else if (stage == 3) {
			if (!second) {
				p1.transform.position = new Vector3 (223.3f, 40.2f, 6);
				p2.transform.position = new Vector3 (228.8f, 38, 6);
				c.transform.position = new Vector3 (233.76f, 91.85f, 0.6f);
				c1.transform.position = new Vector3 (263.76f, 91.85f, 0.6f);
				c2.transform.position = new Vector3 (243.28f, 91.85f, 0.6f);
				c3.transform.position = new Vector3 (253f, 91.85f, 0.6f);
				c4.transform.position = new Vector3 (271.92f, 91.85f, 0.6f);
				second = true;
				//StartCoroutine
			}


		} else if (stage == 4) {
			//StopCoroutine
			Destroy (b1);
			Destroy (b2);
			winT.GetComponent<Text> ().enabled = true;
		}
	}

	public void Stage(){
		stage++;
	}

	public void Reset(){
		p1.transform.position = new Vector3 (223.3f, 40.2f, 6);
		p2.transform.position = new Vector3 (228.8f, 38, 6);
		c.transform.position = new Vector3 (233.76f, 91.85f, 0.6f);
		c1.transform.position = new Vector3 (263.76f, 91.85f, 0.6f);
		c2.transform.position = new Vector3 (243.28f, 91.85f, 0.6f);
		c3.transform.position = new Vector3 (253f, 91.85f, 0.6f);
		c4.transform.position = new Vector3 (271.92f, 91.85f, 0.6f);
		this.transform.position = new Vector3 (209, 32.2f, 0.6f);
		stage = 0;
	}
		
}
