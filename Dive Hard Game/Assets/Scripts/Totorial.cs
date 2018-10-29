using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Totorial : MonoBehaviour {

    [SerializeField]
    GameObject[] tutos;
    bool tuto2 = true;
    bool tuto3 = true;
    // Use this for initialization
    void Start () {
        if (Singleton.tutorial==0)
        {
            tutos[0].SetActive(true);
            Time.timeScale = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Singleton.tutorial==0)
        {

            if (Singleton.subiendo==false && tuto3)
            {
                tutos[2].SetActive(true);
                Time.timeScale = 0;
                tuto3 = false;
                Singleton.tutorial = 1;
            }

        }
	}

    public IEnumerator Tutorial2()
    {
        yield return new WaitForSeconds(0.5f);
        if (tuto2 && Singleton.tutorial==0)
        {
            tutos[1].SetActive(true);
            Time.timeScale = 0;
            tuto2 = false;
        }
            
    }

    public void YoLlamoLaCorrutina()
    {
        StartCoroutine(Tutorial2());
    }

    public void Next()
    {
        Time.timeScale = 1;
        for (int i = 0; i < tutos.Length; i++)
        {
            tutos[i].SetActive(false);
        }
    }

    public void Continue()
    {
        for (int i = 0; i < tutos.Length; i++)
        {
            tutos[i].SetActive(false);
        }
        tutos[3].SetActive(true);
    }
    public void Continue2()
    {
        for (int i = 0; i < tutos.Length; i++)
        {
            tutos[i].SetActive(false);
        }
        tutos[4].SetActive(true);
    }
}
