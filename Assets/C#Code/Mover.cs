using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	GameObject scoreText;
	public float speed;
	public GameObject Explosio;
    public AudioClip AudioExplosion = null;
    public float Volumen = 1.0f;
    protected Transform Posicion = null;

    void Start ()
	{
        Posicion = transform;
		scoreText = GameObject.FindGameObjectWithTag ("ScoreTextTag");
	}

	void Update ()
	{
		Vector2 position = transform.position;
		position = new Vector2 (position.x, position.y - speed * Time.deltaTime);
		transform.position = position;
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));

		if (transform.position.y < min.y)
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if((collider.tag == "Laser"))
		{
			AsteroidExplosion ();
			scoreText = GameObject.FindGameObjectWithTag ("ScoreTextTag");
			scoreText.GetComponent<GameScore>().Score += 20;
			Destroy(gameObject);
		}
		if ((collider.tag == "Player"))
		{
			AsteroidExplosion ();
			scoreText = GameObject.FindGameObjectWithTag ("ScoreTextTag");
            if (scoreText.GetComponent<GameScore>().Score >= 10) scoreText.GetComponent<GameScore>().Score -= 10;
			Destroy(gameObject);
		}
	}
	void AsteroidExplosion()
	{
        if (AudioExplosion) AudioSource.PlayClipAtPoint(AudioExplosion, Posicion.position, Volumen);
        transform.GetComponent<AudioSource>().PlayOneShot(AudioExplosion);
		GameObject explosion = (GameObject)Instantiate (Explosio);
		explosion.transform.position = transform.position;
	}
}
