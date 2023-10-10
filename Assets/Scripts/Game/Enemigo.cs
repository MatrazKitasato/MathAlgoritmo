using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float life;
    public bool isDeadEnemy = false;
    public void TakeDamage(float damage)
    {
        life -= damage;//1
        if(life <= 0)//1+MAX(1)
        {
            Destroy(gameObject);//1
        }
        //Tiempo asintotico = 3    O(1)
    }
}
