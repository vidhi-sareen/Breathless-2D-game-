using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject platformEndpoint;

    void Start()
    {
        platformEndpoint = GameObject.Find("PlatformEndPt");
    }

    
    void Update()
    {
        if(transform.position.x < platformEndpoint.transform.position.x)
        {
            //Destroy (gameObject);
            gameObject.SetActive(false);

        }
    }
}
