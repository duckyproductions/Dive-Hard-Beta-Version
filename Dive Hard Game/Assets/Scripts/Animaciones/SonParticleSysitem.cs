using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonParticleSysitem : MonoBehaviour {


	SpriteRenderer parentSprite;
	ParticleSystem particle;

	// Use this for initialization
	void Start () {
		parentSprite = GetComponentInParent<SpriteRenderer>();
		particle = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		particle.enableEmission = parentSprite.enabled;
	}
}
