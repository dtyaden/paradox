using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour {

	public GameObject player;
	public FirstPerson playerScript;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Controller");

		playerScript = player.GetComponent<FirstPerson>();

		setAlpha(0);
	}
	
	// Update is called once per frame
	void Update () {

		float alpha = (playerScript.maxHealth - playerScript.health)/playerScript.maxHealth;

		setAlpha(alpha);

		Debug.Log("alpha "+ alpha);
	}

	public void setAlpha(float alpha){
		Color c = transform.GetComponentInChildren<Image>().color;
		c.a = alpha;
		transform.GetComponentInChildren<Image>().color = c;
	}
}
