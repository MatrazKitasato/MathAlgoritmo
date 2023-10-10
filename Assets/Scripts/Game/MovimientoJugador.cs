using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

    public float life = 100;
    public float Speed;
    public Vector2 direction;
    private Animator animator;

    public Transform pivot;
    public GameObject bullet;
    public bool isDead;
    public float cooldown;
    float lastshot;

    public AudioSource _shoot;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float movimiento = Mathf.Abs(x) + Mathf.Abs(y);
        animator.SetFloat("Caminar", movimiento);
        Vector2 direction = new Vector2(x, y).normalized;
        Move(direction);
        if(Time.timeScale != 0f)
        {
            
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("Shoot");
                Disparar();
            }
        }
        
    }
    private void Move(Vector2 direction)
    {
        
        //Esto lo uso para hallar los limites de la pantalla para el movimiento del jugador
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//esquina inferior izquierda
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//esquina superior derecha
        
        max.x = max.x - 2f;
        min.x = min.x + 1.5f;

        max.y = max.y - 4.5f;
        min.y = min.y + 2f;

        Vector2 position = transform.position;
        position = position + direction * Speed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, min.x, max.x);
        position.y = Mathf.Clamp(position.y, min.y, max.y);
        transform.position = position;
    }
    void Disparar()
    {
        if (Time.time - lastshot < cooldown)
        {
            return;
        }
        lastshot = Time.time;
        Instantiate(bullet, pivot.position, pivot.rotation);
        _shoot.Play();
    }
    
}
