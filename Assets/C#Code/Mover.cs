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

    void Start()
    {
        Posicion = transform;
        scoreText = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<GameScore>();
    }

    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
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
        if (AudioExplosion) AudioSource.PlayClipAtPoint(AudioExplosion, Posicion.position, Volumen);
        transform.GetComponent<AudioSource>().PlayOneShot(AudioExplosion);
        GameObject explosion = (GameObject)Instantiate(Explosio);
        explosion.transform.position = transform.position;
    }
}
