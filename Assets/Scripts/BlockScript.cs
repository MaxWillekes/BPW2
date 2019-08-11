using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public int HP;
    int hit = 0;

    public GameObject ParticleObject;

    AudioSource audiosource;

    Vector3 particleSize;

    public Material debrisTree;
    public Material debrisTower;

    void Start () {
        audiosource = GetComponent<AudioSource>();
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Ball")
        {
            hit++;

            if (hit >= HP)
            {
                if (LevelManager.instance.levelNumber != 3)
                {
                    switch (gameObject.name)
                    {
                        case "Block Small Variant":
                            LevelManager.instance.ScoreUp(0);
                            particleSize = new Vector3(0.5f, 0.5f, 0.5f);
                            break;
                        case "Block Medium Variant":
                            LevelManager.instance.ScoreUp(1);
                            particleSize = new Vector3(0.75f, 0.75f, 0.75f);
                            break;
                        case "Block Big Variant":
                            LevelManager.instance.ScoreUp(2);
                            particleSize = new Vector3(1f, 1f, 1f);
                            break;
                    }
                }
                else
                {
                    switch (gameObject.name)
                    {
                        case "Block Small Variant":
                            LevelManager.instance.ScoreUp(0);
                            particleSize = new Vector3(0.2f, 0.2f, 0.2f);
                            break;
                        case "Block Medium Variant":
                            LevelManager.instance.ScoreUp(1);
                            particleSize = new Vector3(0.2f, 0.2f, 0.2f);
                            break;
                        case "Block Big Variant":
                            LevelManager.instance.ScoreUp(2);
                            particleSize = new Vector3(0.5f, 0.5f, 0.5f);
                            break;
                    }
                }

                TypeByLevelCheck();

                Destroy(gameObject);
            }
        }
        else if(collision.transform.name == "Player")
        {
            TypeByLevelCheck();

            if (LevelManager.instance.levelNumber != 3)
            {
                switch (gameObject.name)
                {
                    case "Block Small Variant":
                        particleSize = new Vector3(0.5f, 0.5f, 0.5f);
                        break;
                    case "Block Medium Variant":
                        particleSize = new Vector3(0.75f, 0.75f, 0.75f);
                        break;
                    case "Block Big Variant":
                        particleSize = new Vector3(1f, 1f, 1f);
                        break;
                }
            }
            else
            {
                switch (gameObject.name)
                {
                    case "Block Small Variant":
                        particleSize = new Vector3(0.2f, 0.2f, 0.2f);
                        break;
                    case "Block Medium Variant":
                        particleSize = new Vector3(0.2f, 0.2f, 0.2f);
                        break;
                    case "Block Big Variant":
                        particleSize = new Vector3(0.5f, 0.5f, 0.5f);
                        break;
                }
            }

            TypeByLevelCheck();
        }
    }

    void TypeByLevelCheck()
    {
        ParticleObject = Instantiate(ParticleObject, new Vector2(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;

        if (LevelManager.instance.levelNumber == 3)
        {
            switch (gameObject.name)
            {
                case "Block Small Variant":
                    ParticleObject.GetComponent<ParticleSystemRenderer>().material = debrisTree;
                    break;
                case "Block Medium Variant":
                    ParticleObject.GetComponent<ParticleSystemRenderer>().material = debrisTree;
                    break;
                case "Block Big Variant":
                    ParticleObject.GetComponent<ParticleSystemRenderer>().material = debrisTower;
                    break;
            }
        }

        ParticleObject.transform.localScale = (particleSize);
        ParticleObject.transform.parent = GameObject.FindGameObjectWithTag("Level").transform;

        Destroy(gameObject);
    }
}