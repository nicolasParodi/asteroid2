using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;
    public GameObject Explosio;
    public AudioClip AudioExplosion = null;
    public float Volumen = 1.0f;
    protected Transform Posicion = null;
    GameScore scoreText;
    Collider2D collider;

    void Start()
    {
        Posicion = transform;
        scoreText = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<GameScore>();
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;
        if(transform.position.y> 4.63f)
        {
            collider.enabled = false;
        }
        else
        {
            collider.enabled = true;
        }

        if (transform.position.y <= -6.76f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.tag == "Laser"))
        {
            AsteroidExplosion();
            GameData.score += 20;
            Destroy(gameObject);
        }
        if ((collider.tag == "Player"))
        {
            AsteroidExplosion();
            if (GameData.score >= 10) GameData.score -= 10;
            Destroy(gameObject);
        }
        scoreText.UpdateScoreTextUI();
    }
    void AsteroidExplosion()
    {
        AudioManager.instance.PlaySound2D("Enemy Destroy");
        transform.GetComponent<AudioSource>().PlayOneShot(AudioExplosion);
        GameObject explosion = (GameObject)Instantiate(Explosio);
        explosion.transform.position = transform.position;
    }
}
