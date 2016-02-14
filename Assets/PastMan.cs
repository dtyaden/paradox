using UnityEngine;
using System.Collections;

public class PastMan : MonoBehaviour {

	public float FoV = 45f;
	public bool playerSeen;
	GameObject Player;
	GameObject End;
	int arrayIndex;

    StateController state;

	void Start() {
		Player = GameObject.Find ("Controller");
		End = GameObject.Find ("End");

        state = GameObject.Find("StateController").GetComponent<StateController>();
	}

	void Update() {
        if (state.paused() || state.state == "End")
            return;

		if (End.GetComponent<Key> ().phase2) {
			transform.position = (Vector3) Player.GetComponent<FirstPerson> ().positions[arrayIndex];
			transform.rotation = (Quaternion) Player.GetComponent<FirstPerson> ().rotations[arrayIndex];
			arrayIndex++;
		}

		Vector3 directionToPlayer = Player.transform.position - transform.position;
		float angleToPlayer = Vector3.Angle (directionToPlayer, transform.forward);

		if (angleToPlayer < FoV) {
			RaycastHit ray;

			if (Physics.Raycast (transform.position, directionToPlayer.normalized, out ray, 5)) {
				if (ray.collider.gameObject == Player) {
					//We got seen
					Debug.Log("Saw Player!!!!!!");
				}
			}
		}
	}
}


