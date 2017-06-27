using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {


	public GameObject GameController;

	private Rigidbody2D spaceShipRigidBody;
	[SerializeField]
	private float movementSpeed;
	[SerializeField]
	private Boundary boundary;

	public Text LivesUIText;

	const int MaxLives = 5;
	int lives;
    bool disparoDerecha = true;

	public GameObject Laser;
	public Transform LaserSpawn1;
	public Transform LaserSpawn2;
	public GameObject Explosio;

	[SerializeField]
	private float fireRate;
	private float nextFire;

	public AudioClip AudioDisparo;
    public AudioClip AudioExplosion = null;
    public float Volumen = 1.0f;
    protected Transform Posicion = null;

    public void Init()
	{
		lives = MaxLives;

		LivesUIText.text = lives.ToString ();

		gameObject.SetActive (true);
	}

	void Start ()
    {
        Posicion = transform;
        spaceShipRigidBody = GetComponent<Rigidbody2D>();
	}

	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire && disparoDerecha) {
			transform.GetComponent<AudioSource> ().PlayOneShot (AudioDisparo);
            nextFire = Time.time + fireRate;
            GameObject bullet02 = (GameObject)Instantiate(Laser);
            bullet02.transform.position = LaserSpawn2.transform.position;
            disparoDerecha=false;
        }
        if (Input.GetButton("Fire1") && Time.time > nextFire && !disparoDerecha)
        {
            transform.GetComponent<AudioSource>().PlayOneShot(AudioDisparo);
            nextFire = Time.time + fireRate;
            GameObject bullet01 = (GameObject)Instantiate(Laser);
            bullet01.transform.position = LaserSpawn1.transform.position;
            disparoDerecha = true;
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

	void OnTriggerEnter2D(Collider2D collider)
	{
		if((collider.tag == "Asteroid"))
		{

			lives--;
			LivesUIText.text = lives.ToString ();
			if (lives == 0)
			{
				PlayerExplosion ();
                GameController.GetComponent<GameController> ().GameOver();
				gameObject.SetActive (false);
				transform.position = new Vector2 (0.08f, -4.46f);
			}		
		}
	}

	void PlayerExplosion()
	{
        if (AudioExplosion) AudioSource.PlayClipAtPoint(AudioExplosion, Posicion.position, Volumen);
        GameObject explosion = (GameObject)Instantiate (Explosio);
		explosion.transform.position = transform.position;
	}
}