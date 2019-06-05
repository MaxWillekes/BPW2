using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    static int brickCount;
    public int HP;
    int hit = 0;
    LevelManager levelmanager;
    //public GameObject rookPref;
    AudioSource audiosource;

    public Sprite[] brickSprites;

    void Start () {
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        audiosource = GetComponent<AudioSource>();
	}
	
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.name == "Ball"){
            hit++;
            //GetComponent<SpriteRenderer>().sprite = brickSprites[hit];

            if (hit >= HP)
            {
                //GameObject rook = Instantiate(rookPref, new Vector2(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
                //rook.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
                //audiosource.Play();
                Destroy(gameObject);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().blocksRemaining--;
            }
        }
        /*
        if (brickCount == 0)
        {
            levelmanager.LaadVolgendLevel();
        }*/
    }
}