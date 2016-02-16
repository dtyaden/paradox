using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour {
	Button button;
	StateController state;
	// Use this for initialization
	void Start () {
		Debug.Log("starting resume button");

		state = GameObject.Find("StateController").GetComponent<StateController>();

		button = transform.GetComponent<Button>();
		button.onClick.AddListener(() => { state.pause();});

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
