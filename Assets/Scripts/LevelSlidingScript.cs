using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSlidingScript : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime);
    }
}
