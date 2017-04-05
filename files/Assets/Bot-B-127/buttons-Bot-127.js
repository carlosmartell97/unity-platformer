#pragma strict

var myCharacter: GameObject;
var myGround: GameObject;
var myParticles: GameObject;


	function Awake (){
	myParticles.GetComponent.<Renderer>().enabled = false;
	}


	
	function OnGUI() {
	
		GUILayout.BeginHorizontal ("box");
		
		if (GUILayout.Button("Idle")){
		myCharacter.GetComponent.<Animation>().CrossFade("Idle");
		myGround.GetComponent.<Renderer>().enabled = true;
		myParticles.GetComponent.<Renderer>().enabled = false;	
		
		}
		
		if (GUILayout.Button("Walk")){
		myCharacter.GetComponent.<Animation>().CrossFade("Walk");
		myGround.GetComponent.<Renderer>().enabled = true;
		myParticles.GetComponent.<Renderer>().enabled = false;
		
		}
		
		if (GUILayout.Button("Fly")){
		myCharacter.GetComponent.<Animation>().CrossFade("Fly");
		myGround.GetComponent.<Renderer>().enabled = false;
		myParticles.GetComponent.<Renderer>().enabled = true;
		
		}
		
		
		
	
		GUILayout.EndHorizontal ();
	}