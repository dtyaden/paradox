﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class StateController : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject endMenu;
	public GameObject damageScreen;


    public string state = "Active";

	// Use this for initialization
	void Start () {

		pauseMenu = Instantiate(pauseMenu) as GameObject;
	   // pauseMenu = GameObject.Find("pauseMenu");
		endMenu = Instantiate(endMenu) as GameObject;
		damageScreen = Instantiate(damageScreen) as GameObject;

		pauseMenu.SetActive(false);
        endMenu.SetActive(false);

		showCursor(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Pause"))
        {
            pause();
        }

		debugUI();

	}

	void tempend() {
		SceneManager.LoadScene ("StartZone");
	}

    public void end(int success)
    {
		tempend ();
		return;
        endMenu.SetActive(true);
        Text t = endMenu.transform.Find("Text").GetComponent<Text>();
        if (success == 1)
        {
            t.text = "Goooooooooooooooooooooood job.";
        }
        else
        {
            t.text = "You have died.";
        }

        Time.timeScale = 0;

    }

    public void pause()
    {
		Debug.Log("pause");
		Debug.Log(state);
        if (!paused())
        {
            state = "Paused";
            pauseMenu.SetActive(true);
			showCursor(true);
            Time.timeScale = 0;
        }
        else
        {
			showCursor(false);
            state = "Active";
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public bool paused()
    {
        if (state == "Paused")
            return true;
        return false;
    }

	public void showCursor(bool state){
		Cursor.visible = state;

		if(state)
			Cursor.lockState = CursorLockMode.Confined;
		else Cursor.lockState = CursorLockMode.Locked;
	}

	private void debugUI(){
		
	}

}
