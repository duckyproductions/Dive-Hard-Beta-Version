using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UberAudio;

public class Serpiente : ObjectsParents
{
    [SerializeField]
    float poisonTime = 10;
    [SerializeField]
    float poisonMult = 0.5f;

   

    protected override void Action() //comportamiento pasivo
    {
       
    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
       
            _jugador.Poison(poisonTime, poisonMult);
        //Aqui un sonido de envenenamiento
        AudioManager.Instance.Play("SnakeBite");
        AudioManager.Instance.Play("PoisonBlob");
            //animación del choque con serpiente
         
        yield return null;
    }
}
