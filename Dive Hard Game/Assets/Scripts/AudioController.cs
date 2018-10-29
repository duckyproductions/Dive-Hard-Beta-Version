using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UberAudio;

public class AudioController : MonoBehaviour {
    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "MenuInicio")
        {
            //AudioManager.Instance.Play("BGMusic");
        }
    }
    // Use this for initialization
    void Start () {

        
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
