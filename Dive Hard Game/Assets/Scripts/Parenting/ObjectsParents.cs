using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectsParents : MonoBehaviour {
    public bool active;
    [SerializeField]
    int probability;

 
    public int Probability { get { return probability; } set { probability = Mathf.Clamp(value, 0, 100); } }
    public Vector2 pobRange;
    bool counting = false;
    float maxPoolingDistance;
    Transform player;
    public Rigidbody2D selfR;

    bool activeDelta;
    int lim;

    
    public virtual void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        selfR = GetComponent<Rigidbody2D>();
        if (!active)
        {
            selfR.simulated = false;
        }
      
    }
    protected virtual void FixedUpdate()
    {

        if (active)
            if (Time.timeScale != 0)
                Action();

        if (active)
            DistancePooling();

        if (activeDelta != active)
        {
            lim = 0;
        }
        activeDelta = active;
    }
    protected abstract void Action();
    protected virtual IEnumerator Activation(Player _jugador)
    {
        yield return null;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
            if (collision.GetComponent<Player>() != null)
            {
                if (lim == 0)
                { StartCoroutine(Activation(collision.GetComponent<Player>())); lim++; }
            }
    }
    protected virtual void BackToPool()
    {
        active = false;
        counting = false;
        transform.position = new Vector3(-500, -500, 0);
        selfR.velocity = Vector2.zero;
        selfR.simulated = false;
    }
    protected virtual void DistancePooling()
    {
       
        if (!counting)
        {
            maxPoolingDistance =  (Camera.main.transform.position.z / -2f) + Vector3.Distance(transform.position, player.position);
        }
        counting = true;
        if (Vector3.Distance(transform.position, player.position) > maxPoolingDistance)
        {
            BackToPool();
        }
        if (!Singleton.subiendo && GetComponent<ConTienda>() != null)
        {
            BackToPool();
        }
    }
}
