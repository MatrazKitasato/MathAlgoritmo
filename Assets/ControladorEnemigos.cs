using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControladorEnemigos : MonoBehaviour
{
    public float minX, minY, maxX, maxY;
    public Transform[] points;
    public GameObject[] enemigos;
    public float tiempoEnemigos;
    private float tiempoSiguienteEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        maxX = points.Max(points => points.position.x);
        maxY = points.Max(points => points.position.y);
        minX = points.Min(points => points.position.x);
        minY = points.Min(points => points.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoSiguienteEnemigo += Time.deltaTime;
        if(tiempoSiguienteEnemigo >= tiempoEnemigos)
        {
            tiempoSiguienteEnemigo = 0;
            CrearEnemigo();
        }
    }
    public void CrearEnemigo()
    {
        GameObject jugador = GameObject.Find("Player");
        if(jugador != null)
        {
            int numeroEnemigo = Random.Range(0, enemigos.Length);
            Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            GameObject enemigo = Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);
            //enemigo.transform.position = transform.position;
            Vector2 direction = jugador.transform.position - enemigo.transform.position;
            MovimientoEnemigo movimientoEnemigo = enemigo.GetComponent<MovimientoEnemigo>();
            movimientoEnemigo.SetDirection(direction);
        }
        
    }
}
