using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UberAudio;

public class Misil : ConTienda
{
    Animator anim;
    [SerializeField]
    float intencidad, iteraciones,duracion;

    protected override void Action() //comportamiento pasivo
    {

    }

    protected override IEnumerator Activation(Player _jugador) //comportamiento activo
    {
        anim = GetComponent<Animator>();
        Rigidbody2D rb = _jugador.GetComponent<Rigidbody2D>();

        anim.SetBool("Subir", true);

        transform.parent = _jugador.transform;
        transform.localPosition = new Vector3(3.9f, -8.6f, 0);
        GetComponent<Rigidbody2D>().simulated = false;
        //Puede atravezar plataformas
        _jugador.GetComponent<Player>().destruir = true;

        for (int i = 0; i < iteraciones + (ActualLevel * 10); i++)
        {
            rb.AddForce(new Vector2(0, 1) * intencidad / iteraciones * 10 * Mathf.Pow(1.2f, (float)ActualLevel + 1), ForceMode2D.Impulse);
            yield return new WaitForSeconds(duracion / iteraciones);
        }
        transform.parent = null;

        //Aqui un sonido de misil
        //AudioManager.Instance.Play("PigeonDeath");

        GetComponent<Rigidbody2D>().simulated = true;
        //Ya no puede atravezar plataformas
        _jugador.GetComponent<Player>().destruir = false;

        yield return null;
    }
    protected override void BackToPool()
    {
        base.BackToPool();
        anim = GetComponent<Animator>();
        anim.SetBool("Subir", false);
    }
}
