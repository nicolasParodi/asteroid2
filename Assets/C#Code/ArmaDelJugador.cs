using UnityEngine;
using System.Collections;

public class ArmaDelJugador : MonoBehaviour
{
	public float speed;

	void Start()
	{
	
	}
	void Update ()
	{
		Vector2 position = transform.position;
		position = new Vector2 (position.x, position.y + speed * Time.deltaTime);
		transform.position = position;
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		if (transform.position.y > max.y) {
            gameObject.SetActive(false);
        }
	
	}

    public void DesactivarLasers()
    {
        gameObject.SetActive(false);
    }

	void OnTriggerEnter2D(Collider2D collider)
	{
		if((collider.tag == "Asteroid"))
		{
            gameObject.SetActive(false);
		}
	}
}

