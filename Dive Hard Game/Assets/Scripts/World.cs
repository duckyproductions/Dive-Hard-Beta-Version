using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {


    public GameObject estrellas;
    public GameObject estrellas2;

    public Transform player;
     
    [SerializeField]
    float distanceToSpawn;

    [SerializeField]
    float altura;

	// Use this for initialization
	void Start ()
    {
       
    }


    private void Update()
    {
        float distance = player.position.y;

        if (distance>(altura+distanceToSpawn))
        {
            Instantiate(estrellas, new Vector3(transform.position.x,transform.position.y +altura, 40),Quaternion.identity,transform);
            Instantiate(estrellas2, new Vector3(transform.position.x-3, transform.position.y+1.8f  + altura, 80), Quaternion.identity, transform);
            altura = altura+ distanceToSpawn;

        }
    }


}
