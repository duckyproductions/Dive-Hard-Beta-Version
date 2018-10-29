using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Slider>().value = Singleton.slide;
	}

    public void SwithcSlide()
    {
        Singleton.slide= (int)GetComponent<Slider>().value;

    }

}
