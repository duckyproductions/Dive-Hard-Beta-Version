using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadFinal : MonoBehaviour {
    public float velFin;
    public Rigidbody2D playerBody;

    bool activado = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !activado)
        {
            velFin = Mathf.Abs(playerBody.velocity.y * 1000);
            activado = true;
        }
    }
}
