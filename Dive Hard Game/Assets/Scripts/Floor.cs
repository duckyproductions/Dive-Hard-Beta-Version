using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UberAudio;
using UnityEngine.UI;
using ChartboostSDK;

public class Floor : MonoBehaviour {

    //[SerializeField]
    //Edificio alturaDeEdificio;
    float floorHeigth = 0;
    Player player;
    Rigidbody2D playerRig;
    int finalScore;
    [SerializeField]
    GameObject restartMenu;
    [SerializeField]
    TextMeshProUGUI textoPuntaje, textoPuntajeMaximo;
	public GameObject BloodParticles;

    int variableControl;
    float count;

    bool counting;
	private void Start()
    {
        Chartboost.cacheInterstitial(CBLocation.Default);

        variableControl = 0;

        player = GameObject.Find("Player").GetComponent<Player>() ;
        playerRig = player.GetComponent<Rigidbody2D>();
        //floorHeigth = Mathf.Abs(player.position.y - alturaDeEdificio.transform.position.y);
        restartMenu.SetActive(false);
    }
    // Update is called once per frame
    void FixedUpdate () {
        transform.position = new Vector3(player.transform.position.x, floorHeigth, transform.position.z);
        if (player.transform.position.y <= floorHeigth)
        {
           
            //playerRig.velocity = new Vector2((playerRig.velocity.x / 5f), Mathf.Abs(playerRig.velocity.y / 5f));
            if (!counting)
            {
                finalScore = (int)((player.bloodInGame + player.acomulatedPoints) * ((Singleton.storeLevels[2] * 0.5) + 1)); // sujeto a cambios (cambiado por Olarte)v 2.0
                BloodSplash(11f , playerRig.velocity.y / 2f, (finalScore)<=500 ? (finalScore) : 500 , player.transform); 
                playerRig.velocity = Vector2.zero;
                playerRig.gravityScale = 0;
                StartCoroutine(RestartProtocole());
                counting = true;

                if (finalScore > Singleton.localHighScores.x)
                {
                    Singleton.localHighScores.x = finalScore;
                }
                textoPuntajeMaximo.text = (Singleton.localHighScores.x).ToString();
            }
                             


        }
        if (counting )
        {

            count = Mathf.MoveTowards(count,finalScore,Time.deltaTime * ((finalScore - count)+1));
            textoPuntaje.text = ((int)count).ToString();
             
        }
	}
    //this coud be change
    IEnumerator RestartProtocole()
    {
        AudioManager.Instance.Play("FallSplat");
        yield return new WaitForSeconds(2f);
        restartMenu.SetActive(true);
        textoPuntaje.text = "0";
        counting = true;
        

        if (variableControl == 0)
        {
            Singleton.blood += finalScore;
            variableControl++;
        }

        yield return null;
    }

    public void DoblePuntos()
    {
            
        if (Chartboost.hasInterstitial(CBLocation.Default))
        {
            Chartboost.showInterstitial(CBLocation.Default);

            Singleton.blood += finalScore;
            finalScore+=finalScore;
            GameObject.Find("Duplicar").GetComponent<Button>().interactable = false;
        }
        else
            Chartboost.cacheInterstitial(CBLocation.Default);
    }


	protected void BloodSplash(float spawTime, float fuerzaDeLanzamiento, int cantidadDeParticulas, Transform player)
	{
		GameObject blood = Instantiate(BloodParticles, player.position, Quaternion.identity);
		ParticleSystem particle = blood.GetComponent<ParticleSystem>();

        player.GetComponent<SpriteDinamico>().EndGame = true;
        player.localScale = new Vector3(0.2f, 0.2f, 0.2f); // change
		particle.startSpeed = fuerzaDeLanzamiento;
		particle.emission.SetBurst(0, new ParticleSystem.Burst(0, (short)cantidadDeParticulas, (short)cantidadDeParticulas, 1, 0.010f));

		if (!particle.isPlaying)
			particle.Play();

		Destroy(blood, spawTime);
	}


}
