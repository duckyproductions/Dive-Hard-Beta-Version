using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UberAudio;

public class Licuadora : ConTienda {

   

    protected override void Action() //comportamiento pasivo
    {
        //AudioManager.Instance.Play("Blender");
    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
        
            _jugador.bloodInGame += (_jugador.licuadora*_jugador.venenoMult);

        
       
        yield return null;
    }
}
