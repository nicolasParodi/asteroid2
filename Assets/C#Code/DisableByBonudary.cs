using UnityEngine;
using System.Collections;

public class DisableByBonudary : MonoBehaviour {
	
	void OnTriggerExit2D (Collider2D other){
		other.gameObject.SetActive (false);
		other.gameObject.transform.position = Vector3.zero;
	}
}
