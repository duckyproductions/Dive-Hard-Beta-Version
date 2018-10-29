using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{

    public ObjectsParents target;
    SpriteRenderer mRend;
    float deltaAlfa;
    private void Start()
    {
        mRend = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (target.transform.position.y > 0)
        {

            if (Singleton.subiendo)
            {
                if (target.transform.position.y > (Camera.main.transform.position.y + (Camara.height / 2f)))
                {
                    transform.position = new Vector3(target.transform.position.x, Camera.main.transform.position.y + Camara.height / 2.2f, 0);
                    deltaAlfa = (-(Camera.main.transform.position.y + (Camara.height / 1.2f)) + target.transform.position.y) / 5f;
                    mRend.color = new Color(1, 1, 1, 1 / (2 + (deltaAlfa > 0 ? deltaAlfa : -1)));
                    mRend.enabled = target.active;
                }
                else
                    mRend.enabled = false;
            }
            else
            {
                if (target.transform.position.y < (Camera.main.transform.position.y - (Camara.height / 2f)))
                {
                    transform.position = new Vector3(target.transform.position.x, Camera.main.transform.position.y - Camara.height / 2.2f, 0);
                    deltaAlfa = ((Camera.main.transform.position.y - (Camara.height / 1.2f)) - target.transform.position.y) / 5f;
                    mRend.color = new Color(1, 1, 1, 1 / (2 + (deltaAlfa > 0 ? deltaAlfa : -1)));
                    mRend.enabled = target.active;
                }
                else
                    mRend.enabled = false;
            }
        }
        else
        {
            mRend.enabled = false;
        }

    }
}
