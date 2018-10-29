using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreVertical : MonoBehaviour
{

    [SerializeField]
    Transform limL, limR, target;

    [SerializeField]
    TextMeshPro texto;
    private void Start()
    {
        transform.position = new Vector3((limL.position.x + limR.position.x) / 2f, Singleton.localHighScores.y, 0);
        texto.text = ((int)Singleton.localHighScores.y).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (target.position.y > Singleton.localHighScores.y)
        {
            Singleton.localHighScores.y = target.position.y;
            transform.position = new Vector3(transform.position.x, Singleton.localHighScores.y + 5, 0);
            texto.text = ((int)Singleton.localHighScores.y).ToString();
        }
       
    }
}
