using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region variables
    Pooling mPools;
    bool boolCoroutine = true;
    
    [SerializeField]
    Rigidbody2D target;
    Vector3 V;
    [SerializeField]
    float t = 5f, maxRadious;
    ObjectsParents selected;
    [SerializeField]
    Transform limL, limR;

    [Header ("Difficulty Controller")]
    [SerializeField]
    int capDifficulty;

    float difficulty;

    [SerializeField]
    private float deltaDifficultyInHeight;

    public float Difficulty{get{return difficulty;}set{difficulty = Mathf.Clamp(value, 0, capDifficulty);}}

    float initialTargetY;

    #endregion

    void Start()
    {
        mPools = GetComponent<Pooling>();
        if (deltaDifficultyInHeight<=0)
        {
            deltaDifficultyInHeight = 1;
        }
        initialTargetY = target.transform.position.y;
    }
    
    void FixedUpdate()
    {

        Difficulty = (target.transform.position.y - initialTargetY)/deltaDifficultyInHeight;
        if (Mathf.Abs(target.velocity.y) > 0.1f)
        {
            if (boolCoroutine)
            {
                StartCoroutine(Spw());
            }
        }

    }

    #region Spawner
    int SelectorB(int r)
    {

        for (int i = 0; i < mPools.pool.Length; i++)
        {
            if ((mPools.pool[i].pobRange.y - mPools.pool[i].pobRange.x >= 0))
            {
                if (r >= mPools.pool[i].pobRange.x && r <= mPools.pool[i].pobRange.y)
                {
                    return i;
                }
            }
        }
        return -1;
    }
    IEnumerator Spw()
    {
        int k, s;
        boolCoroutine = false;
        Vector2 acI = target.velocity;
        yield return new WaitForSeconds(0.1f);
        Vector2 acF = target.velocity;
        V = new Vector3(Random.Range((int)limL.position.x + 3, (int)limR.position.x - 3), target.position.y + ((acF.y * t) + ((acF.y - acI.y) * ((t) * (t))) / 2), 0);

        selected = null;

        if (Singleton.subiendo)
        {
            k = Random.Range(0, mPools.halfWay + ((int)((mPools.maxProb - mPools.halfWay)*Difficulty)));
            if (k >= mPools.halfWay)
            { 
                k = Random.Range(mPools.halfWay, mPools.maxProb);
            }
        }
        else
        {
            k = Random.Range(mPools.halfWay, mPools.maxProb);
        }

        //print(k);
        s = SelectorB(k);

        if (s < 0) { boolCoroutine = true; yield break; }
        selected = mPools.pool[s];
 
        if (selected == null || selected.active)
        {
            boolCoroutine = true;
            yield break;
        }

        //yield return new WaitForSeconds(t / 200f);
        if (V.y <= 20 || Vector3.Distance(target.transform.position, V) < (Camara.height/2) + 5 || Physics2D.OverlapCircle(V, maxRadious) != null) { boolCoroutine = true; yield break; }

        selected.transform.position = V;
        selected.selfR.simulated = true;
        selected.active = true;
        boolCoroutine = true;
        yield return null;
    }
    #endregion
}
