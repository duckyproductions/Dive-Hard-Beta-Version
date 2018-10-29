using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UberAudio;

public class Options : MonoBehaviour {

    public GameObject pestañaCerrar;
    public GameObject pestañaAbir;
    [SerializeField]
    Sprite[] spritesVolumen;
    [SerializeField]
    Slider slider;
    [SerializeField]
    Image handle;


	public void Cambiar ()
    {
        AudioManager.Instance.Play("ButtonPress");
        pestañaCerrar.SetActive(false);
        pestañaAbir.SetActive(true);
    }

    public void CambiarVolumen()
    {
        if(slider.value < 0.25f)
        {
            handle.sprite = spritesVolumen[0];
        }
        else if(slider.value >= 0.25f &&  slider.value < 0.5f)
        {
            handle.sprite = spritesVolumen[1];
        }
        else if (slider.value >= 0.5f && slider.value < 0.75f)
        {
            handle.sprite = spritesVolumen[2];
        }
        else
        {
            handle.sprite = spritesVolumen[3];
        }
    }

    public void MostrarTutorial()
    {
        AudioManager.Instance.Play("ButtonPress");
        Singleton.tutorial = 1;
        GetComponent<InicioButtons>().Jugar();
    }

    public void MostrarCredtitos()
    {
        AudioManager.Instance.Play("ButtonPress");
    }
}
