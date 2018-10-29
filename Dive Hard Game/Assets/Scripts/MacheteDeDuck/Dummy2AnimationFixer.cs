using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Dummy2AnimationFixer : MonoBehaviour {

    public bool estorbo;
    Animator a;

	// Use this for initialization
	void Start () {
        a = GetComponent<Animator>();
            }
	
	// Update is called once per frame
	void Update () {
        a.SetBool("Estorbo", estorbo);
	}
}
