using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionEnemigo : MonoBehaviour
{
    public Transform objetivo;
    public float angulosRadianes;
    public float anguloGrados;
    public float speed;
    
    void Update()
    {

        
        if(GameObject.Find("Player") != null)
        {
            objetivo.transform.position = GameObject.Find("Player").transform.position;
            angulosRadianes = Mathf.Atan2(objetivo.position.y - transform.position.y, objetivo.position.x - transform.position.x);
            anguloGrados = (180 / Mathf.PI) * angulosRadianes - 90;
            transform.rotation = Quaternion.Euler(0, 0, anguloGrados);
        }
        
    }
}
