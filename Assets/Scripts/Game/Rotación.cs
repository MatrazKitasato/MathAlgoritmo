using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotación : MonoBehaviour
{
    public Vector3 objetivos;
    public new Camera camera;
    public float angulosRadianes;
    public float anguloGrados;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objetivos = camera.ScreenToWorldPoint(Input.mousePosition);
        angulosRadianes = Mathf.Atan2(objetivos.y - transform.position.y, objetivos.x - transform.position.x);
        anguloGrados = (180 / Mathf.PI) * angulosRadianes - 90;
        transform.rotation = Quaternion.Euler(0, 0, anguloGrados);
    }
}
