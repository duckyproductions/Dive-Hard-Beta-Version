using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Pause : MonoBehaviour {

    static bool onPause;
    public GameObject menuPause;
    public GameObject director;

    public void PauseButton()
    {
        if (onPause == false)
        {
            onPause = true;
            director.GetComponent<PlayableDirector>().Pause();
        }
        else
        {
            onPause = false;
            director.GetComponent<PlayableDirector>().Resume();
        }

        menuPause.active = onPause;


        if (onPause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1; 
    }

    public void PauseTuto()
    {
        if (onPause == false)
        {
            onPause = true;
            director.GetComponent<PlayableDirector>().Pause();
        }
        else
        {
            onPause = false;
            director.GetComponent<PlayableDirector>().Resume();
        }


        if (onPause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

}
