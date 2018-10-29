using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bordes : MonoBehaviour
{
    [SerializeField]
    Transform limL, colliderL, limR, colliderR, target;
    private void Start()
    {
        colliderL.position = new Vector3(limL.position.x, transform.position.y, 0);
        colliderR.position = new Vector3(limR.position.x, transform.position.y, 0);
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,target.position.y,0);
    }


}
