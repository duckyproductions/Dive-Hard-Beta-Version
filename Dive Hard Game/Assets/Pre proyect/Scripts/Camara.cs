using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    public Rigidbody2D cuerpo;
    Vector3 posCuerpo;
    [SerializeField]
    Transform limL, limR;
    float cameraSpeed = 100;
    bool incio = true;
    static public float height, widht;
    float movX, movY, dis1, dis2;
    // Use this for initialization
    void Start()
    {
        if (cuerpo == null)
            cuerpo = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        widht = Mathf.Abs(transform.position.z) * (Mathf.Tan(Camera.main.fieldOfView / 2f * Mathf.Deg2Rad)) * 2f;

        height = widht * Screen.height / Screen.width;
        dis1 = Mathf.Abs(limL.position.x - limR.position.x);
        dis2 = Mathf.Abs((limL.position.x + (widht / 2f)) - (limR.position.x - (widht / 2f)));
    }

    // Update is called once per frame
    void Update()
    {
        if (incio)
        {

            movX = cuerpo.transform.position.x;
            movY = cuerpo.transform.position.y;
            if (cuerpo.transform.position.x >= limL.position.x && cuerpo.transform.position.x <= limR.position.x)
            {
                incio = false;
                cameraSpeed = 4;
            }
        }
        else
        {

            movX = limL.position.x + (widht / 2f) + (dis2 * ((Mathf.Abs(limL.position.x - cuerpo.transform.position.x)) * 100 / dis1) / 100);

            if (Singleton.subiendo)
            {
                if (cuerpo.velocity.y >= 0)
                {
                    movY = cuerpo.transform.position.y + (height / 2f) - (height / 3f);
                }
                else
                {
                    movY = transform.position.y;
                    if (cuerpo.transform.position.y <= transform.position.y - (height / 2f))
                    {
                        Singleton.subiendo = false;
                    }
                }
            }
            else
            {
                movY = cuerpo.transform.position.y - (height / 2f) + (height / 4f);
            }
        }
        posCuerpo = new Vector3(movX, Mathf.Clamp(movY, -7 + (height / 2f), cuerpo.transform.position.y + height), transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, posCuerpo, (Mathf.Abs(cuerpo.velocity.y) + Mathf.Abs(cuerpo.velocity.x) + 1) * cameraSpeed * Time.deltaTime);
    }
}
