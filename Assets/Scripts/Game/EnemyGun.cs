using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public Controlador controlador;
    public GameObject EnemyBullet;
    public float cooldown;
    float lastshot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.time - lastshot < cooldown)
        {
                return;
        }
        lastshot = Time.time;
        FireBullet();
    }
    public void FireBullet()
    {
        GameObject player = GameObject.Find("Player");
        if(player != null)
        {
            GameObject bullet = Instantiate(EnemyBullet);
            bullet.transform.position = transform.position;
            Vector2 direction = player.transform.position - bullet.transform.position;
            BulletEnemy bulletenemy = bullet.GetComponent<BulletEnemy>();
            bulletenemy.SetDirection(direction);
        }
    }
}
