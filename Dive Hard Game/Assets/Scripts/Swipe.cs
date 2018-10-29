using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UberAudio;

public class Swipe : PassiveMechanics
{

    //Cosas para el counter del swipe
    [SerializeField]
    GameObject swipeCounter, swipeHolder, swipeFull;
    Image[][] counterSprites;
    Vector3 counterPos = new Vector3(270, 550, 0);
    Color baseColor;

    bool isUp = false;
    int counter;
    float timer;
    float multiplicador = 1;

    [SerializeField]
    float coldDown, magnitud;
    [SerializeField]
    int maxCounter;
    Image[] tempCounterSprites = new Image[3];
    Rigidbody2D mRB;

    [SerializeField]
    GameObject BloodParticles;

    public static bool eneableImpulse;

    protected override void Execution()
    {
        swipeCounter = Resources.Load<GameObject>("Prefabs/SwipeCounter");
        mRB = GetComponent<Rigidbody2D>();
        counter = maxCounter;
        counterSprites = new Image[counter][];

        for (int i = 0; i < maxCounter; i++)
        {
            GameObject g = Instantiate(swipeCounter, GameObject.Find("Canvas").GetComponent<RectTransform>().position + counterPos - new Vector3(0, counterPos.y / 1.8f, 0) * i, Quaternion.EulerAngles(swipeCounter.transform.rotation.eulerAngles));
            g.transform.SetParent(GameObject.Find("cuchillos").transform);
            GameObject w = Instantiate(swipeHolder, GameObject.Find("Canvas").GetComponent<RectTransform>().position + counterPos - new Vector3(0, counterPos.y / 1.8f, 0) * i, Quaternion.EulerAngles(swipeCounter.transform.rotation.eulerAngles));
            w.transform.SetParent(GameObject.Find("cuchillos").transform);
            GameObject k = Instantiate(swipeFull, GameObject.Find("Canvas").GetComponent<RectTransform>().position + counterPos - new Vector3(0, counterPos.y / 1.8f, 0) * i, Quaternion.EulerAngles(swipeCounter.transform.rotation.eulerAngles));
            k.transform.SetParent(GameObject.Find("cuchillos").transform);
            tempCounterSprites[0] = g.GetComponent<Image>();
            tempCounterSprites[1] = w.GetComponent<Image>();
            tempCounterSprites[2] = k.GetComponent<Image>();
            counterSprites[i] = (tempCounterSprites);
        }
        baseColor = counterSprites[0][0].color;
    }

    void Update()
    {
        if(Singleton.subiendo == false && tempCounterSprites[0].enabled != false)
        {
            for (int i = 0; i < tempCounterSprites.Length; i++)
            {
                tempCounterSprites[i].enabled = false;
            }
        }
     

            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (counter > 0 && ((Input.touches[i].phase == TouchPhase.Canceled || Input.touches[i].phase == TouchPhase.Ended)))
                    {
                        if (eneableImpulse)
                        {
                            Lanzar();
                        }
                        else if (Input.touchCount>1)
                        {
                            Lanzar();
                        }

                    }
                }
            }



        //CooldDown
        if (counter < maxCounter)
        {

            if (!isUp)
            {
                timer += Time.deltaTime;
                counterSprites[counter][0].color = new Color(baseColor.r, baseColor.g, baseColor.b, timer / (coldDown - 0.5f*ActualLevel) );
                if (timer >= (coldDown - 0.5f * ActualLevel) )
                    isUp = true;
            }
            else
            {
                timer = 0;
                isUp = false;
                counterSprites[counter][0].color = new Color(baseColor.r, baseColor.g, baseColor.b, 1);
                counterSprites[counter][2].color = new Color(baseColor.r, baseColor.g, baseColor.b, 1);
                counter++;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Sigue PJ")
            this.enabled = false;

    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Sigue PJ")
            this.enabled = false;
    }

    protected void BloodSplash(float spawTime, float fuerzaDeLanzamiento, int cantidadDeParticulas, Transform player)
    {
        GameObject blood = Instantiate(BloodParticles, player.position, Quaternion.identity);
        ParticleSystem particle = blood.GetComponent<ParticleSystem>();

        particle.startSpeed = fuerzaDeLanzamiento;
        particle.emission.SetBurst(0, new ParticleSystem.Burst(0, (short)cantidadDeParticulas, (short)cantidadDeParticulas, 1, 0.010f));

        if (!particle.isPlaying)
            particle.Play();

        Destroy(blood, spawTime);
    }

    void Lanzar()
    {
        GetComponent<Player>().bloodInGame += (GetComponent<Player>().swipe * GetComponent<Player>().venenoMult); //suma sangre 
        //if(Singleton.subiendo)
        //     mRB.velocity = Vector2.zero;
        if (Singleton.subiendo)
        {
            mRB.AddForce(multiplicador * (Vector2.up) * magnitud * ((ActualLevel*0.5f) + 1), ForceMode2D.Impulse);
            BloodSplash(10, 30, 250, transform);
        }
        else
        {
           // mRB.AddForce(multiplicador * (Vector2.down) * 3 * magnitud * (ActualLevel + 1), ForceMode2D.Impulse);
        }
        counter--;

        AudioManager.Instance.Play("Swipe");

        for (int i = counter; i < maxCounter; i++)
        {
            counterSprites[i][0].color = new Color(baseColor.r, baseColor.g, baseColor.b, 0);
            counterSprites[i][2].color = new Color(baseColor.r, baseColor.g, baseColor.b, 0);
        }
    }
}
