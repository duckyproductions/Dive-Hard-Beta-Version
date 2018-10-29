using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boton : MonoBehaviour {

	[SerializeField]
	public AudioClip click;

	public int index;


	public void Select()
	{
		Store.itemIndex = index;

		Store.mSprites = GetComponent<Image>().sprite;
		GameObject.Find("Comprar").GetComponent<Store>().Change();
		GetComponent<AudioSource>().PlayOneShot(click);
	}

}
