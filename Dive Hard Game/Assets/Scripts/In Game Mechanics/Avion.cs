using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UberAudio;

public class Avion : ObjectsParents
{
    [SerializeField]
    float cantidadFrenar = 2;

   

    protected override void Action() //comportamiento pasivo
    {
        //Aqui sonido del engine del Avion???
        //AudioManager.Instance.Play("PlaneSound");

    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
        
        Rigidbody2D rb = _jugador.GetComponent<Rigidbody2D>();
        Player player = _jugador.GetComponent<Player>();
        if (player.destruir)
        {

            player.TimerSpeed3 = 0;
            player.destruir = false;
        }
        else
        {
            rb.velocity = new Vector2((rb.velocity.x / cantidadFrenar), 0);
            AudioManager.Instance.Play("MetalHit");
        }
        //Aqui un sonido de choque con avion
        
            //animación del choque con avion
        
        yield return null;
    }
}
