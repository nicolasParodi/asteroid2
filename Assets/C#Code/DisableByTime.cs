using UnityEngine;
using System.Collections;

public class DisableByTime : MonoBehaviour {

	[SerializeField]
	private float lifeTime;
	private float timer;

	void Update () {
		if (Time.time > timer + lifeTime) {
			timer = Time.time;
			gameObject.SetActive (false);
			transform.position = Vector3.zero;
		}
	}
}
