using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UberAudio;
using ChartboostSDK;

public class InicioButtons : MonoBehaviour {

	LoadingScene load;
	public GameObject loadScreen;

    private void Start()
	{

        loadScreen.active = false;
		load = loadScreen.GetComponent<LoadingScene>();


    }

	public void Jugar()
    {
        AudioManager.Instance.Play("ButtonPress");
        //SceneManager.LoadScene("Game");
        loadScreen.active = true;
		StartCoroutine(load.WaitToLoad("Game"));
        
    }
    public void JugarInicio()
    {
        AudioManager.Instance.Play("ButtonPress");
        if (Singleton.tutorial==1)
        {
            loadScreen.active = true;
            StartCoroutine(load.WaitToLoad("Game"));
        }
        else
        {
            loadScreen.active = true;
            StartCoroutine(load.WaitToLoad("Comic"));
        }
        //SceneManager.LoadScene("Game");

    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Restart()
    {
        AudioManager.Instance.Play("ButtonPress");
        //SceneManager.LoadScene("Game");


        loadScreen.active = true;
		StartCoroutine(load.WaitToLoad("Game")); 

	}

    public void IrAMenu()
    {
        AudioManager.Instance.Play("ButtonPress");
        //SceneManager.LoadScene("MenuInicio");
        loadScreen.active = true;
		StartCoroutine(load.WaitToLoad("MenuInicio")); 
	}

    public void IrATienda()
    {
        AudioManager.Instance.Play("ButtonPress");
        //SceneManager.LoadScene("Tienda");


        loadScreen.active = true;
		StartCoroutine(load.WaitToLoad("Tienda")); 
	}

    public void ReiniciarSave()
    {
        Singleton.blood = 0;
        Singleton.localHighScores = Vector3.zero;
        Singleton.tutorial = 0;
        for (int i = 0; i < Singleton.storeLevels.Length; i++)
        {
            Singleton.storeLevels[i] = 0;
        }
        IrATienda();
    }

}
