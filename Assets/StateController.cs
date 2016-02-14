using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StateController : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject endMenu;

    public string state = "Active";

	// Use this for initialization
	void Start () {
	    pauseMenu = GameObject.Find("pauseMenu");
        endMenu = GameObject.Find("endMenu");

        endMenu.SetActive(false);
        pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Pause"))
        {
            pause();
        }

	}

    public void end(int success)
    {
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
        
        if (!paused())
        {
            state = "Paused";
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
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

}
