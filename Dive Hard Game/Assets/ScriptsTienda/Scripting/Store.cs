using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class Store : MonoBehaviour {

	public Item[] storeItems = new Item[11];
	static public int itemIndex;

	//Unity
	public Button btn;
	static public Sprite mSprites;
	public string[] mStrings;
	public Image imagen;
	public Text text;
	public Text pocket;
	public Text price;
    public Text nivel;

	private void Start()
	{

        storeItems[0] = new Item("Altura edificio", 0,          1000,   2000,   3000,   10000 );
        storeItems[1] = new Item("Tranpolin", 1,                500,    1500,   3000,   8000      );
        storeItems[2] = new Item("Multiplicador de sangre", 2,  500,    2000,   8000,   20000      );
        storeItems[4] = new Item("Palomas", 4,                  1000,   3000,   7000,   15000    );
        storeItems[8] = new Item("Aumento swipe", 8,            1000,   2500,   6000,   13000      );
        storeItems[9] = new Item("Misil", 9,                    1500,   5000,   10000,  30000    );



        storeItems[10] = new Item("Ala delta", 10,              500,    900,    1300,   0      );
        storeItems[7] = new Item("Portal", 7,                   1200,   2400,   4800,   0    );
        storeItems[6] = new Item("Meteoros", 6,                 2500,   5000,   7500,   0    );
        storeItems[5] = new Item("Chef", 5,                     300,    800,    1500,   0      );
        storeItems[3] = new Item("Aumento de gravedad", 3,      500,    1000,   1500,   0     );


        for (int i = 0; i < storeItems.Length; i++)
        {
            storeItems[i].nivel = Singleton.storeLevels[i];
        }
		btn = GetComponent<Button>();
	}

	private void Update()
	{
  
		pocket.text = "Blood:   " +  Singleton.blood.ToString();
		price.text = "Price:  " + (storeItems[itemIndex].Price()).ToString();

        if (storeItems[itemIndex].nivel >= storeItems[itemIndex].pricelvl.Length)
        {
            nivel.text = "Level MAX";
        }
        else
            nivel.text = "Level "+ (storeItems[itemIndex].nivel).ToString();

        if (Singleton.blood < storeItems[itemIndex].Price() || storeItems[itemIndex].nivel >= storeItems[itemIndex].pricelvl.Length)
			btn.interactable = false;


	}

	public void Buy()
	{
		Singleton.blood -= storeItems[itemIndex].Price();
			
		storeItems[itemIndex].nivel ++;

        Singleton.storeLevels[itemIndex] = storeItems[itemIndex].nivel;

	}

	public void Change()
	{
		if (mSprites != imagen.sprite)
			imagen.sprite = mSprites;

		if (text.text != mStrings[itemIndex])
			text.text = mStrings[itemIndex];


        if (Singleton.blood < storeItems[itemIndex].Price())
        {
            btn.interactable = false;
        }
        else
        {
            btn.interactable = true;
        }
	}

}
