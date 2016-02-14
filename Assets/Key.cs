using UnityEngine;
using System.Collections;



public class Key : MonoBehaviour {
	//reset game for round 2

	Vector3 startPos;
	Vector3 keyStartPos;
	Quaternion startRot;
	public bool phase2 = false;

	void Start () {
		GameObject control = GameObject.Find ("Controller");
		startPos = control.transform.position;
		startRot = control.transform.rotation;
		keyStartPos = GameObject.Find ("Key").transform.position;
	}
		
	void OnTriggerEnter (Collider other) {
		Debug.Log (other.name);
		GameObject toMove = GameObject.Find ("Controller");
		GameObject keyToMove = GameObject.Find ("Key");
		toMove.transform.position = startPos;
		toMove.transform.rotation = startRot;
		keyToMove.transform.position = keyStartPos;
		if (phase2 == true) {
			//End the Game!
		}
		phase2 = true;
		//Startup the AI as a copy of the player's first run
	}
}