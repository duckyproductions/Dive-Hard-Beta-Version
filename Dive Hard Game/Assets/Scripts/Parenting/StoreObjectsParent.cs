using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StoreObjectsParent : ObjectsParents
{
    [SerializeField]
    int storeIndex;
    private int StoreIndex { get { return storeIndex; } set { storeIndex = Mathf.Clamp(value, 0, Singleton.storeLevels.Length - 1); } }

    int actualLevel;
    protected int ActualLevel { get { return actualLevel; } private set { actualLevel = value; } }

    private void Awake()
    {
        ActualLevel = Singleton.storeLevels[StoreIndex];
    }
}
