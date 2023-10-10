using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posición : MonoBehaviour
{
    
    void Start()
    {
        this.transform.localPosition = GameObject.Find("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
