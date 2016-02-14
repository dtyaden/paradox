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
		GameObject toMove = GameObject.Find ("Controller");
		GameObject keyToMove = GameObject.Find ("Key");

		if (Application.loadedLevelName == "Level2") {
			switch ((int)Mathf.Round (Random.Range (.5f, 4.4f))) {
			case 1:
				toMove.transform.position = GameObject.Find ("StandardStart").transform.position;
				break;
			case 2:
				toMove.transform.position = GameObject.Find ("DestStart").transform.position;
				break;
			case 3:
				toMove.transform.position = GameObject.Find ("EmptyStart").transform.position;
				break;
			case 4:
				toMove.transform.position = GameObject.Find ("KeyStart").transform.position;
				break;
			default:
				break;
			}
		} else {
			toMove.transform.position = startPos;
		}
		toMove.transform.rotation = startRot;
		keyToMove.transform.position = keyStartPos;
		if (phase2 == true) {
			//End the Game!
		}
		phase2 = true;
		//Startup the AI as a copy of the player's first run
	}
}