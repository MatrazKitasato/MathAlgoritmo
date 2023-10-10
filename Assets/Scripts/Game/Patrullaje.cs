using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    public float speed;
    public Transform[] points;
    public float distance;
    private int nextStep = 0;
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[nextStep].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, points[nextStep].position) < distance)
        {
            nextStep++;
            if (nextStep >= points.Length)
            {
                nextStep = 0;
            }
        }
    }
}
