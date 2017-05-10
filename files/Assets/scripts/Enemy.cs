using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public List<Node> path;
	public int currentNode;
	public Node standByNode;
	public float treshold, speed;

	public Symbol cubeCarried, cubeReached, cubeInPosition;
	public State current;
	Node mostRecentNode;

	public GameObject target;

	public Image enemyWarning;
	public bool showEnemyWarning;

	// Use this for initialization
	void Start () {

		cubeCarried = new Symbol("cubeCarried");
		cubeReached = new Symbol("cubeReached");
		cubeInPosition = new Symbol("cubeInPosition");

		State standBy = new State("standBy");
		State chasingCube = new State("chasingCube");
		State retrievingCube = new State("retrievingCube");

		standBy.AddNeighbor(cubeCarried,chasingCube);
		standBy.AddNeighbor(cubeInPosition,standBy);
		standBy.AddNeighbor(cubeReached,standBy);

		chasingCube.AddNeighbor(cubeReached,retrievingCube);
		chasingCube.AddNeighbor(cubeCarried,chasingCube);
		chasingCube.AddNeighbor(cubeInPosition,chasingCube);

		retrievingCube.AddNeighbor(cubeInPosition,standBy);
		retrievingCube.AddNeighbor(cubeReached,retrievingCube);
		retrievingCube.AddNeighbor(cubeCarried,retrievingCube);

		current = standBy;
		mostRecentNode = standByNode;
		path.Add(standByNode);

		enemyWarning.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		var v3 = Camera.main.WorldToScreenPoint (this.transform.position);
		if (showEnemyWarning && (v3.x > Screen.width || v3.x < 0 || v3.y > Screen.height || v3.y < 0)) {
			enemyWarning.enabled = true;
		} else {
			enemyWarning.enabled = false;
		}
		if(enemyWarning.enabled){
			if (v3.x > Screen.width) {
				v3.x = Screen.width-110;
				enemyWarning.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
			} else if(v3.x<0){
				v3.x = 	90;
				enemyWarning.transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));
			}
			if (v3.y > Screen.height) {
				v3.y = Screen.height-90;
				enemyWarning.transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
			} else if(v3.y<0){
				v3.y = 90;
				enemyWarning.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
			}
			enemyWarning.transform.position = v3;
		}

		if(current.Name=="standBy"){
			currentNode = 0;
			mostRecentNode = standByNode;
			//this.transform.position = standByNode.transform.position;
		}

		else if(current.Name=="chasingCube"){
			speed=0.12f;
			Node characterOnNode = GameObject.Find ("Character").GetComponent<mainCharacter> ().characterOnNode;
			if (mostRecentNode == characterOnNode) {
				this.transform.LookAt (target.transform.position);
				this.transform.Translate (transform.forward * speed, Space.World);
			} else {
				//Debug.Log (mostRecentNode.name);
				//Debug.Log (characterOnNode.name);

				path = Pathfinding.aStar(mostRecentNode,characterOnNode);
				//Debug.Log("PATH:");
				for(int i=0; i<path.Count; i++){
					//Debug.Log("->"+path[i].name+" ");
				}
				this.transform.LookAt (path [currentNode].transform.position);
				this.transform.Translate(transform.forward*speed,Space.World);
				float distance = Vector3.Distance(this.transform.position,path[currentNode].transform.position);
				//Debug.Log("d:"+distance);
				if(distance<treshold){
					if(currentNode!=path.Count-1){
						currentNode++;
					}
				}
			}

		}
		else if(current.Name=="retrievingCube"){
			//Debug.Log("p:"+path.Count+" cur:"+currentNode);
			speed=0.23f;
			target.transform.position = new Vector3(transform.position.x+(2*2),transform.position.y+2,transform.position.z);
			path = Pathfinding.aStar(mostRecentNode,standByNode);
			for(int i=0; i<path.Count; i++){
				//Debug.Log("->"+path[i]+" ");
			}
			this.transform.LookAt (path [currentNode].transform.position);
			this.transform.Translate(transform.forward*speed,Space.World);
			float distance = Vector3.Distance(this.transform.position,path[currentNode].transform.position);
			if(distance<treshold){
				if(currentNode!=path.Count-1){
					currentNode++;
				}
			}
		}
	}

	void OnCollisionEnter(Collision c){

		if(target!=null && c.gameObject.name==target.gameObject.name){
			//Debug.Log("enemy with "+c.gameObject.name);

			// mainCharacter.grab = false
			GameObject.Find("Character").GetComponent<mainCharacter>().grab = false;
			// mainCharacter.item = null
			GameObject.Find("Character").GetComponent<mainCharacter>().item = null;
			current = current.ApplySymbol(cubeReached);
			showEnemyWarning = false;
			currentNode = 0;
		}
	}

	void OnTriggerEnter(Collider c){
		//Debug.Log (c.gameObject.layer);
		if(current.Name=="retrievingCube" && c.gameObject.layer==8){
			//Debug.Log("c:"+c.gameObject.name+" sb:"+standByNode.gameObject.name);
			if(c.gameObject.name==standByNode.name){
				current = current.ApplySymbol(cubeInPosition);
				path = new List<Node>();
				path.Add(standByNode);
			}
		}
		else if(current.Name=="chasingCube" && c.gameObject.layer==8){
			
			mostRecentNode = c.gameObject.GetComponent(typeof(Node))as Node;
			//currentNode = 0;
		}
	}
}
