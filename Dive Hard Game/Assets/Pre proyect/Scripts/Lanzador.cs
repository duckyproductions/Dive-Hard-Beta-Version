using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UberAudio;

public class Lanzador : MonoBehaviour
{

    float fuerza;
    public Rigidbody2D cuerpo;
    Swipe swipe;
    public Text mText;
    public RectTransform contador;
    public float multiplicadorFuerza;
    float t = 8;
    float timer = 0;
    bool running = true;
    bool aim = true;
    bool oneTimeAim = true;
    public bool jumping = true;
    public bool canClic;
    bool click;
    public bool launched = false;

    [SerializeField]
    float velocidad, amplitud, anguloInicio;

    //Secuencia del principio
    PlayableDirector mDirector;
    public SpriteRenderer tapSprite;
    int fastForward;
    public float sizeScale = 1;

    //SwipeSalto
    bool tap, isUp, isDraging = false;
    Vector2 starTouch, swipeDelta;
    Vector3 direccionLanzamiento;

    [SerializeField]
    SpriteRenderer[] trampolines;

    public bool Running
    {
        get
        {
            return running;
        }

        set
        {
            running = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        swipe = cuerpo.gameObject.GetComponent<Swipe>();
        swipe.enabled = false;
        mDirector = GetComponent<PlayableDirector>();

        tapSprite.enabled = true;
        //print(Singleton.storeLevels[1]);
        trampolines[Mathf.Clamp(Singleton.storeLevels[1], 0,trampolines.Length-1) ].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //TimelineFixer
        if (fastForward == 0)
            Time.timeScale = 1;

        if (fastForward == 1)
            Time.timeScale = 2;

        if (fastForward == 2)
            Time.timeScale = 0.3f;

        click = Input.GetButtonDown("Fire1");

        if (click)
        {

            AudioManager.Instance.Play("Footstep");
        }


        if (Running == false)
        {
            fastForward = 1;
            if (t < 0)
            {
                mText.text = "0.00";
            }
            else
            {
                CalculaFuerza();

                mText.text = System.Math.Round(t, 2).ToString();
                t -= Time.deltaTime;
            }
        }
        if (jumping == false)
        {
            if (canClic)
            {
                //if (Swipe())
                //{
                //    Running = true;
                //    aim = false;
                //    tapSprite.enabled = false;
                //    fastForward = 1;
                //}

                if ((true))
                {
                    Running = true;
                    aim = false;
                    tapSprite.enabled = false;
                    fastForward = 1;
                }
            }
            if (aim == false)
                fastForward = 1;
            else
                fastForward = 2;

        }

        if (mDirector.time > 9.90)
        {

            cuerpo.simulated = true;
            Lanzar();
            fastForward = 0;
        }
    }

    void Lanzar()
    {
        AudioManager.Instance.Play("Trampoline");
        //cuerpo.AddForce(direccionLanzamiento * fuerza * multiplicadorFuerza, ForceMode2D.Impulse); 
        cuerpo.AddForce( new Vector2(50,80)  + (Vector2.up * fuerza * multiplicadorFuerza * ((Singleton.storeLevels[1]*0.5f) + 1)), ForceMode2D.Impulse);
        GetComponent<PlayableDirector>().enabled = false;

        GameObject.Find("Tutorial").GetComponent<Totorial>().YoLlamoLaCorrutina();
        GameObject.Find("Plataforma").GetComponent<MueveteAlAIzquierda>().CorretePuto();

        swipe.enabled = true;
        mText.text = 0.ToString();
        Time.timeScale = 1;
        launched = true;
        tapSprite.gameObject.active = false;
        contador.gameObject.active = false;
        Destroy(GetComponent<Lanzador>());
    }

    void Apuntar()
    {
        timer += Time.deltaTime;
        transform.eulerAngles = new Vector3(0, 0, ((Mathf.Sin(timer * velocidad)) * amplitud) + anguloInicio);
    }

    void CalculaFuerza()
    {
        if (click)
        {
            fuerza++;
            contador.gameObject.active = true;
            contador.localScale = new Vector3(1, sizeScale * fuerza / 5,1); 
        }
    }

    public void OnPointChecher()
    {
        tapSprite.enabled = false;

        Running = false;
        mDirector.enabled = true;
    }

    bool Swipe()
    {
        bool canSwipe = false;

        tap = false;

        #region Mouse Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            starTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }

        #endregion

        #region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                if (starTouch == Vector2.zero)
                    starTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
            }
        }

        #endregion

        swipeDelta = Vector2.zero;
        //Calcular Distancia
        if (isDraging)
        {

            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - starTouch;

            if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - starTouch;

        }


        //Pasar la Zona muerta
        if (swipeDelta.magnitude > 200 && ((swipeDelta.x - starTouch.x) > 0) && ((swipeDelta.y - starTouch.y) > 0))
        {
            direccionLanzamiento = new Vector3(swipeDelta.x - starTouch.x, swipeDelta.y - starTouch.y, 0).normalized;
            canSwipe = true;
            Reset();
        }

        return canSwipe;
    }

    private void Reset()
    {
        starTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
