 using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Item {

    public int index;
    public string name;
    public int nivel=0;
    public int[] pricelvl = new int[4];


    public Item(string Name, int Index, int Price1, int Price2, int Price3, int Price4)
    {
        name = Name;
        index = Index;
        pricelvl[0] = Price1;
        pricelvl[1] = Price2;
        pricelvl[2] = Price3;
        pricelvl[3] = Price4;
    }


    public int Price()
    {
        int price;
        if (nivel< pricelvl.Length)
            price = pricelvl[nivel];
        else
            price = pricelvl[nivel-1];
        return price;
    }


}
