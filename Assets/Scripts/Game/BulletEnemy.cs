using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public Controlador _score;
    private MovimientoJugador jugador;
    public float speed;
    Vector2 _direction;
    bool isReady = false;
    public GameObject _panel;

    void Awake()
    {
        _score = GameObject.FindObjectOfType<Controlador>();
        jugador = GameObject.FindObjectOfType<MovimientoJugador>();
    }
    void Start()
    {
        
    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }
    void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;
            //Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            //Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            /*max.x = max.x - 2f;
            min.x = min.x + 1.5f;

            max.y = max.y - 4f;
            min.y = min.y + 1.5f;*/
            if ((transform.position.x < -20.55f) || (transform.position.x > 20f) ||
                (transform.position.y < -11.54f) || (transform.position.y > 8f))
            {
                Destroy(gameObject);
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
            jugador.life -= 10;
            if(jugador.life <= 0)
            {
                
                jugador.isDead = true;
                GameManager.instance.score.InsertNodeAtStart(_score.timeSeconds);
                _score.Vida();
                Destroy(other.gameObject);
            }
            Destroy(this.gameObject);
        }
        if (other.tag == "Box")
        {
            Destroy(this.gameObject);
        }
    }
}
