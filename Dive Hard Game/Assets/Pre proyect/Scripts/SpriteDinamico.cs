using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDinamico : MonoBehaviour {

	public Sprite[] sprites;
	Rigidbody2D rig;
	//PolygonCollider2D collider;
	SpriteRenderer sprRenderer;
    bool endGame;

    public bool EndGame
    {
        get
        {
            return endGame;
        }

        set
        {
            endGame = value;
        }
    }

    // Use this for initialization
    void Start () {
		rig = GetComponent<Rigidbody2D>();
		sprRenderer = GetComponent<SpriteRenderer>();
        //collider = GetComponent<PolygonCollider2D>();
        EndGame = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!EndGame)
        {
            if (rig.velocity.y < 0)
            {
                sprRenderer.sprite = sprites[1];

            }
            else
                sprRenderer.sprite = sprites[0];
        }
        else
            sprRenderer.sprite = sprites[2];
    }
}
