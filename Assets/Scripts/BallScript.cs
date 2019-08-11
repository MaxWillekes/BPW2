using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    public enum BallStates { Normal, Unstable }
    public BallStates state;

    PlayerController player;

    bool started = false;

    Vector2 speedVector;
    Vector2 StartVector;
    public float speedFloat;

    AudioSource audiosource;

    public Vector2 AbovePlayer;
    public float PullBeamRemaining;
    public Image BarFill;

    public bool unstable;
    public float timer;

    void Start()
    {
        PullBeamRemaining = 100;
        player = GameObject.FindObjectOfType<PlayerController>();
        audiosource = GetComponent<AudioSource>();
        state = BallStates.Normal;
        timer = Random.Range(3, 5);
    }

    void Update()
    {
        StartVector = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        AbovePlayer = new Vector2(player.transform.position.x, gameObject.transform.position.y);

        if (!started)
        {
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 3f);
        }

        if (Input.GetMouseButtonDown(0) && started == false)
        {
            started = true;
            speedVector = new Vector2(7f, transform.position.y);
            GetComponent<Rigidbody2D>().velocity = speedVector;
        }
        else if (Input.GetMouseButton(0) && PullBeamRemaining >= 0 && player.GetComponent<PlayerController>().playerInputEnabled == true)
        {
            transform.position = Vector2.Lerp(StartVector, AbovePlayer, 0.1f);
            GameObject.FindGameObjectWithTag("PullBar").GetComponent<Image>().fillAmount = PullBeamRemaining/100;
            PullBeamRemaining -= 0.5f;
            if (!gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }

        if (unstable)
        {
            ExecuteState();
        }

        if(gameObject.transform.position.y <= -4.5f)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0.001f));
        }

        if(gameObject.transform.position.x <= -9.2f || gameObject.transform.position.x >= 9.2f || gameObject.transform.position.y <= -5.3f || gameObject.transform.position.y >= 5.3f)
        {
            GetComponent<Rigidbody2D>().velocity = speedVector;
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 3f);
        }
    }

    private void ExecuteState()
    {
        switch (state)
        {
            case BallStates.Normal:
                NormalState();
                break;
            case BallStates.Unstable:
                UnstableState();
                break;
        }
    }

    private void NormalState()
    {
        speedFloat = 0.9999f;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = Random.Range(3, 5);
            SwitchState(BallStates.Unstable);
        }
    }

    private void UnstableState()
    {
        speedFloat = Random.Range(-5f, 5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = Random.Range(3, 5);
            SwitchState(BallStates.Normal);
        }
    }

    public void SwitchState(BallStates newState)
    {
        state = newState;
    }
}