using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class Player : MonoBehaviour
{

    float deltaMoveX, moveX;
    float timer;

    public TextMeshProUGUI bloodText;

    public float bloodInGame = 0;
    [SerializeField]
    float maxVelY, deltaPointsTimesSpeed;
    float venenoTime = 0;
    public float venenoMult = 1;
    Rigidbody2D mRig;
    public int acomulatedPoints;
    float countPoints;
    int maxSpeedBonus;
    [SerializeField]
    private float horizontalSpeed, sensivility;

    [SerializeField]
    ParticleSystem speed1,speed2,speed3;

    [Header("La sangre que da cada uno")]
    public int bloodBag;
    public int licuadora;
    public int meteoros;
    public int paloma;
    public int swipe;

    //Destruir plataformas
    public bool destruir;
    float timerSpeed3;
    float timeToSpeed3 = 5;

    public float TimerSpeed3
    {
        get
        {
            return timerSpeed3;
        }

        set
        {
            timerSpeed3 = value;
        }
    }

    private void Start()
    {
        mRig = GetComponent<Rigidbody2D>();

        acomulatedPoints = 0;

    }

    private void LateUpdate()
    {
        if (Input.touchCount > 0)
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                Swipe.eneableImpulse = false;
            }
        }
        else
        {
            timer = 0;
            Swipe.eneableImpulse = true;
        }
        deltaMoveX = moveX;
    }

    private void Update()
    {
        //if (venenoTime > 0)
        //{
        //    venenoTime -= Time.deltaTime;
        //}
        //else
        //{
        //    venenoMult = 1;
        //}

        bloodText.text = "Blood " + Mathf.Round(bloodInGame);


        speed1.emissionRate = 4 + Mathf.Abs(mRig.velocity.y/3);

        if (mRig.velocity.y != 0)
        {
            if (Singleton.slide==1)
                mRig.velocity = new Vector2(Input.acceleration.x * horizontalSpeed, mRig.velocity.y);
            else
            {

                if (Input.touchCount > 0)
                {
                    moveX = Input.touches[0].position.x;   
                    
                    if(Input.touches[0].phase == TouchPhase.Began)
                        deltaMoveX = moveX;
                }
                mRig.velocity = new Vector2(Mathf.Clamp((moveX - deltaMoveX), -horizontalSpeed, horizontalSpeed)*sensivility, mRig.velocity.y);
            }
        }

        if (!Singleton.subiendo)
        { 


            if (mRig.velocity.y >= 0)
            {
                mRig.velocity = new Vector2(mRig.velocity.x,0);
                speed1.Stop();
            }
            else
            {
                speed1.Play();
            }


            if (-mRig.velocity.y >= maxVelY)
            {
                mRig.velocity = Vector2.MoveTowards(mRig.velocity, new Vector2(mRig.velocity.x, maxVelY * (Mathf.Sign(mRig.velocity.y))), Time.deltaTime * (1 + Mathf.Abs(mRig.velocity.y)));
                maxSpeedBonus = 5;
                speed2.Play();

                TimerSpeed3 += Time.deltaTime;

                if (TimerSpeed3 >= timeToSpeed3)
                {
                    destruir = true;
                    speed3.Play();
                }
                else
                    speed3.Stop();
            }
            else
            {
                speed2.Stop();
                maxSpeedBonus = 1;
                if (transform.position.y <= 0)
                {
                    speed3.Stop();
                    speed2.Stop();
                }
            }
            countPoints += Mathf.Abs(mRig.velocity.y / maxVelY) * Time.deltaTime * deltaPointsTimesSpeed * maxSpeedBonus;
            acomulatedPoints = (int)countPoints;
        }
        else
        {

            if (Mathf.Abs(mRig.velocity.y) >= maxVelY *.8f)
            {

                mRig.velocity = Vector2.MoveTowards(mRig.velocity, new Vector2(mRig.velocity.x, maxVelY * (Mathf.Sign(mRig.velocity.y))), Time.deltaTime * (1 + Mathf.Abs(mRig.velocity.y / 2f)));
            }
        }
    }

    public void Poison(float poisonTime, float poisonMult)
    {
        //venenoTime += poisonTime;
        //if (poisonMult < venenoMult)
        //{
        //    venenoMult = poisonMult;
        //}
    }

}
