using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

	private Rigidbody2D spaceShipRigidBody;
	[SerializeField]
	private float movementSpeed;
	[SerializeField]
	private Boundary boundary;

	public Transform shotSpawn1;
	public Transform shotSpawn2;

	[SerializeField]
	private float fireRate;
	private float nextFire;

	void Start () {
		spaceShipRigidBody = GetComponent<Rigidbody2D>();
	}

	void Update () {
		ObjectPool activate = GameObject.Find("Player").GetComponent<ObjectPool>();
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			activate.ActivateObjects (shotSpawn1.position, shotSpawn1.rotation);
			activate.ActivateObjects (shotSpawn2.position, shotSpawn2.rotation);
		}
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movementH = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movementV = new Vector3 (0.0f, moveVertical, 0.0f);
		spaceShipRigidBody.velocity = (movementH + movementV) * movementSpeed;
		spaceShipRigidBody.position = new Vector3 (Mathf.Clamp (spaceShipRigidBody.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp (spaceShipRigidBody.position.y, boundary.yMin, boundary.yMax), 0.0f);
	}
}