using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.position.x <= -10) 
        {
            Destroy(gameObject);
        }
    }
}
