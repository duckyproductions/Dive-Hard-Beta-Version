using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComicTextController : MonoBehaviour {
    [SerializeField]
    string[] textos;
    TextMeshProUGUI self;
    int index;

    public int Index
    {
        get
        {
            return index;
        }

        set
        {
            index = Mathf.Clamp(value,0,textos.Length);
        }
    }

    private void Start()
    {
        self = GetComponent<TextMeshProUGUI>();
        self.text = textos[index];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Index++;
            self.text = textos[index];
        }

    }
   

}
