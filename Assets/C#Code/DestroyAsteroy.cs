using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroy : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y <=-8.0f) 
		{
			Destroy(gameObject);
		}
	}
}
