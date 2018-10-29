using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UberAudio;

public class Paloma : ConTienda
{
	[SerializeField]
	float cantidadAcelerar;
    Animator anim;
   
	protected override void Action() //comportamiento pasivo
    {
      
    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
        anim = GetComponent<Animator>();
        Rigidbody2D rb = _jugador.GetComponent<Rigidbody2D>();

        anim.SetTrigger("Atack");
        _jugador.bloodInGame += (_jugador.paloma * _jugador.venenoMult);




        //Aqui un sonido de paloma muriendo
        AudioManager.Instance.Play("PigeonDeath");

        yield return new WaitForSeconds(0.3f);
            rb.velocity = new Vector2(rb.velocity.x/10, 0);
            rb.AddForce(new Vector2(0,cantidadAcelerar),ForceMode2D.Impulse);

		yield return null;
	}
}
