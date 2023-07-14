using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    public GameObject followingTarget;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(followingTarget.transform.position.x + 5f, 0f, transform.position.z);

        if(transform.position.x >= 166f) 
        {
            transform.position = new Vector3(166f, 0f, transform.position.z);
        }
    }
}
