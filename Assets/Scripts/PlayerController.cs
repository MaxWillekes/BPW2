using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.mousePosition);
        gameObject.transform.position = new Vector3(Input.GetAxisRaw("Mouse X"), -4.55f, 0);
    }
}
