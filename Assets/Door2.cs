using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Door2 : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		SceneManager.LoadScene ("Assets/Level2");
	}
}