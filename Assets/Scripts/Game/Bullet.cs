using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed;
    public float daño;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        max.x = max.x - 2f;
        min.x = min.x + 1.5f;

        max.y = max.y - 4f;
        min.y = min.y + 1.5f;
        if ((transform.position.x < -20.55f) || (transform.position.x > 20f) ||
            (transform.position.y < -11.54f) || (transform.position.y > 8f))
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemigo>().TakeDamage(daño);
            Destroy(gameObject);
        }
    }
}
