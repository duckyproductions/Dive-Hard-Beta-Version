using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edificio : PassiveMechanics
{
    private float altura;
    public float Altura { get { return altura; } set { altura = value * Mathf.Pow( 1.9f ,ActualLevel) ;} }

    protected override void Execution()//start
    {
        Altura = 100;
        transform.position = new Vector3(transform.position.x , altura , transform.position.z);
    }
}
