using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public Controlador _score;
    private MovimientoJugador jugador;
    public float speed;
    Vector2 _direction;
    bool isReady = true;
    private void Awake()
    {
        jugador = GameObject.FindObjectOfType<MovimientoJugador>();
        _score = GameObject.FindObjectOfType<Controlador>();
    }
    void Start()
    {
        
    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;// 1
        isReady = true;//1
        //Tiempo Asintotico = 2  O(1)
    }


    
    void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;
            if ((transform.position.x < -20.55f) || (transform.position.x > 20f) ||
                (transform.position.y < -11.54f) || (transform.position.y > 8f))
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            jugador.life -= 20;
            if(jugador.life <= 0)
            {
                jugador.isDead = true;
                GameManager.instance.score.InsertNodeAtStart(_score.timeSeconds);
                _score.Vida();
                Destroy(other.gameObject);
                
            }
        }
    }
}
