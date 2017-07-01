using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour {

    bool active;
    public GameObject panelPause;

	// Use this for initialization
	void Start ()
    {
        panelPause.SetActive(false);

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            active = true;
            panelPause.SetActive(active);
            Time.timeScale = (active) ? 0 : 1f;
            Cursor.visible = active;
        }
	}

    public void ResumeGame()
    {
        active = false;
        panelPause.SetActive(active);
        Time.timeScale = (active) ? 0 : 1f;
        Cursor.visible = active;
    }
}
