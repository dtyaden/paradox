using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {

	GameObject grabbedObject;

	GameObject GetCenterHover(float range) {
		Vector3 ObjectPosition = gameObject.transform.position;
		RaycastHit raycasthit;
		Vector3 target = ObjectPosition + Camera.main.transform.forward * range;
		if (Physics.Linecast (ObjectPosition, target, out raycasthit))
			return raycasthit.collider.gameObject;
		return null;
	}

	void tryGrab(GameObject toGrab) {
		if (toGrab == null || toGrab.GetComponent<Rigidbody>() == null)
			return;
		grabbedObject = toGrab;
	}

	public void drop() {
		grabbedObject = null;
	}

	void Update() {
		if (Input.GetKeyDown ("e")) {
			if (grabbedObject == null) {
				tryGrab (GetCenterHover (5));
			} else {
				drop ();
			}
		}

		if (grabbedObject != null) {
			Vector3 HoverPos = gameObject.transform.position + Camera.main.transform.forward;
			grabbedObject.transform.position = HoverPos;
		}
	}
}
