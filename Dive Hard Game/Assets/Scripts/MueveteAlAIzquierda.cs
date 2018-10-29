using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MueveteAlAIzquierda : MonoBehaviour {

    [SerializeField]
    float cantidadCorrer;
    [SerializeField]
    float tiempoParaCorrer;

    public void CorretePuto()
    {
        StartCoroutine(CorretePuej());
    }
    IEnumerator CorretePuej()
    {
        yield return new WaitForSeconds(tiempoParaCorrer);
        transform.position = new Vector3(transform.position.x + cantidadCorrer, transform.position.y, transform.position.z);
    }
}
