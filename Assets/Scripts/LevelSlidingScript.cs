using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSlidingScript : MonoBehaviour
{
    public int speed;
    public bool playerInputEnabled;

    private void Start()
    {
        playerInputEnabled = true;
        Cursor.visible = false;
    }

    void Update()
    {
        if (playerInputEnabled)
        {
            transform.Translate(Vector3.down * (Time.deltaTime * speed));
        }
    }
}
