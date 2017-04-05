using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1mov : MonoBehaviour {
	public GameObject laserShot,platformUp,platformFront;
	int fps=0;
	int platformUpPosition=-5; int platformUpwardsDirection=1;
	int platformFrontPosition=-4; int platformFrontDirection=-1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		fps++;
		if (fps % 5 == 0) {
			if (platformUpPosition > 21) {
				platformUpwardsDirection *= -1;
			} else if (platformUpPosition < -5) {
				platformUpwardsDirection *= -1;
			}
			platformUpPosition += platformUpwardsDirection;
		}
		Vector3 upwards = new Vector3 (232, platformUpPosition, 0);
		platformUp.transform.position = upwards;
		if (fps % 6 == 0) {	
			if (platformFrontPosition > 0) {
				platformFrontDirection *= -1;
			} else if (platformFrontPosition < -3) {
				platformFrontDirection *= -1;
			}
			platformFrontPosition += platformFrontDirection;
		}
		Vector3 frontBack = new Vector3 (245, 2, platformFrontPosition);
		platformFront.transform.position = frontBack;

		if (fps % 45 == 0) {
			//Debug.Log("RUN "+fps);
			if (fps % 90 == 0) {
				laserShot.active = true;
			} else {
				laserShot.active = false;
			}
		}
	}
}
