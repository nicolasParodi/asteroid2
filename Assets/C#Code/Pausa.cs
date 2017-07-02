using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour {

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
        if (canvas.enabled==false && Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
	}

    public void Pause()
    {
        canvas.enabled = !canvas.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Cursor.visible = !Cursor.visible;
    }
}
