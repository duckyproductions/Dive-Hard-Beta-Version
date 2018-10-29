using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{

   
    public ObjectsParents[] pool;
    public int maxProb, halfWay;
    public bool done;
    [SerializeField]
    Warning alert;
    [SerializeField]
    private int poolSize;

    // Use this for initialization
    public void Awake()
    {
  
        int tempI = 0, tempS = 0 , selector = 0, mitad = 0;

        ObjectsParents[] tempPool = Resources.LoadAll<ObjectsParents>("Prefabs");

        pool = new ObjectsParents[tempPool.Length * poolSize];

       
        for (int k = 0; k < 2; k++)
        {
            tempS = tempPool.Length;
            for (int i = mitad; i < ((pool.Length/tempPool.Length)*tempS)+mitad; i += tempS)//<--- here
            {
              
                selector = 0;
                for (int j = 0; j < tempPool.Length; j++)
                {
                    if (k == 0 && (tempPool[j].transform.GetComponent<ConTienda>() != null))
                    {
     
                       
                        pool[i + selector] = Instantiate(tempPool[j], new Vector3(-500, -500, 0), Quaternion.identity);
       
                        pool[i + selector].Start();
               
                        pool[i + selector].pobRange = new Vector2(maxProb, maxProb + pool[i + selector].Probability - 1);
                        maxProb += pool[i + selector].Probability;
                        
                  
                        selector++;

                    }
                    if (k == 1 && (tempPool[j].transform.GetComponent<ConTienda>() == null))
                    {
              
                        pool[i + selector] = Instantiate(tempPool[j], new Vector3(-500, -500, 0), Quaternion.identity);
                        if (pool[i+selector].GetType() != typeof(BloodBag))
                        {
                            Warning asing = Instantiate(alert, new Vector3(-500, -500, 0), Quaternion.identity);
                            asing.target = pool[i + selector];
                        }                       
                        pool[i + selector].Start();
                        pool[i + selector].pobRange = new Vector2(maxProb, maxProb + pool[i + selector].Probability - 1);
                        maxProb += pool[i + selector].Probability;

                        selector++;

                    }
                    tempS = selector;
                }
              
                tempI = i + tempS;
                
            }
            mitad = tempI;
            if (k == 0)
            {
                halfWay = maxProb;
            }

        }

    }
}
