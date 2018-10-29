using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UberAudio;

//[RequireComponent(typeof(AudioSource))]

public class Slime : ObjectsParents {

	[SerializeField]
	float cantidadFreno = 2;
    Animator anim;
   

    protected override void Action() //comportamiento pasivo
    {
      
    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
        anim = GetComponent<Animator>();
        anim.SetBool("muere", true);

		Rigidbody2D rb = _jugador.GetComponent<Rigidbody2D>();
        Player player = _jugador.GetComponent<Player>();

        if (player.destruir == false)
        {
            rb.velocity = new Vector2(rb.velocity.x / cantidadFreno, rb.velocity.y / cantidadFreno);
        }
        else
        {
            player.TimerSpeed3 = 0;
            player.destruir = false;
        }
        AudioManager.Instance.Play("Slime");
        yield return null;
    }

    protected override void BackToPool()
    {
        base.BackToPool();
        anim = GetComponent<Animator>();
        anim.SetBool("muere", false);
    }
}
