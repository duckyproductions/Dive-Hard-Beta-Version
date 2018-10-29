using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpeedCounter : MonoBehaviour {

	public Rigidbody2D mRig;
	public TextMeshProUGUI mText;

	
	// Update is called once per frame
	void Update () {
		mText.text ="Speed " +(Mathf.Abs((int)mRig.velocity.y * -1)).ToString();

	}
    //Just To Push
}
