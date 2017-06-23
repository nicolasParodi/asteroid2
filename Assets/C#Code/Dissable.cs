using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissable : MonoBehaviour 
{
	

	// Use this for initialization


	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y >=8.0f) 
		{
			gameObject.SetActive(false);
		}
	}
}
