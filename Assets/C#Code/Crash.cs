using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		TextManager.LoseLife (1);
		Destroy (gameObject);
	}
}
