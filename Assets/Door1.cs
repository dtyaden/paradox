using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Door1 : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		SceneManager.LoadScene ("Level1");
	}
}
