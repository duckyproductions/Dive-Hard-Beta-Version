using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AltimeterSlider : MonoBehaviour {

    Transform playerTransform;
    Slider altimeter;
    TextMeshProUGUI altimeterText;

    float maxAltitude = 1000;
    float currentAltitude;
    

	// Use this for initialization
	void Start () {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        altimeterText = GameObject.Find("AltitudeText").GetComponent<TextMeshProUGUI>();
        altimeter = GetComponent<Slider>();
        altimeter.maxValue = maxAltitude;
        altimeter.value = playerTransform.position.y;
    }
	
	// Update is called once per frame
	void Update () {

        if (playerTransform.position.y >= maxAltitude)
        {
            maxAltitude = playerTransform.position.y;

        }

        altimeter.value = playerTransform.position.y;
        currentAltitude = Mathf.Round(playerTransform.position.y);
        altimeterText.text = string.Format("{0}m ----", currentAltitude.ToString());	
	}
}
