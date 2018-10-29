using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comic : MonoBehaviour
{

    Transform[] puntos;
    int index = 0;
    // Use this for initialization
    void Start()
    {
        puntos = GameObject.Find("puntos").GetComponentsInChildren<Transform>();
        transform.position = puntos[0].position;
    }

    // Update is called once per frame
    void Update()
    {
     

        if (Input.GetMouseButtonDown(0))
        {
            if (index < (puntos.Length - 1))
            {
                index++;
            }
            else
            {
                GetComponent<InicioButtons>().Jugar();
            }
        }
        transform.position = Vector3.MoveTowards(transform.position,puntos[index].position,Time.deltaTime*2);


    }
}
