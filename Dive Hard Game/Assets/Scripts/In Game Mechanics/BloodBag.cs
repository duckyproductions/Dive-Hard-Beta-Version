using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UberAudio;

public class BloodBag : ObjectsParents {

   

    protected override void Action() //comportamiento pasivo
    {
       
    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
      
            _jugador.bloodInGame += (_jugador.bloodBag * _jugador.venenoMult);
           
            AudioManager.Instance.Play("Bloodbag");
            BackToPool();
      
        yield return null;
    }
}
