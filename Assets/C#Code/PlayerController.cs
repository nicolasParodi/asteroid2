using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

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
	public Transform laserSpawn1;
	public Transform laserSpawn2;
	public GameObject Explosio;

	[SerializeField]
	private float fireRate;
	private float nextFire;

	public AudioClip AudioDisparo;
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
        lives = MaxLives;
        LivesUIText.text = lives.ToString();
    }

	void Update () {
        ObjectPool activate = GameObject.Find("Player").GetComponent<ObjectPool>();
        if (Input.GetButton("Fire1") && Time.time > nextFire && disparoDerecha && Time.timeScale !=0)
        {
            nextFire = Time.time + fireRate;
            activate.ActivateObjects(laserSpawn2.position, laserSpawn2.rotation);
            disparoDerecha = false;
            AudioManager.instance.PlaySound2D("Player Shoot");
        }
        if (Input.GetButton("Fire1") && Time.time > nextFire && !disparoDerecha && Time.timeScale != 0)
        {
            nextFire = Time.time + fireRate;
            activate.ActivateObjects(laserSpawn1.position, laserSpawn1.rotation);
            disparoDerecha = true;
            AudioManager.instance.PlaySound2D("Player Shoot");
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
				transform.position = new Vector2 (0.08f, -4.46f);
			}		
		}
	}

	void PlayerExplosion()
	{
        AudioManager.instance.PlaySound2D("Player Death");
        GameObject explosion = (GameObject)Instantiate (Explosio);
		explosion.transform.position = transform.position;
        gameObject.SetActive(false);
    }
}