using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour {

    bool active;
    Canvas canvas;

	// Use this for initialization
	void Start ()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            active = true;
            canvas.enabled = active;
            Time.timeScale = (active) ? 0 : 1f;
        }
	}

    public void ResumeGame()
    {
        active = false;
        canvas.enabled = active;
        Time.timeScale = (active) ? 0 : 1f;
    }
}
