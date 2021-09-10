using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour
{
    public int scoreToGive;
    private scoreManger thescoreManger;
    private AudioSource CoinPickSound;

    // Start is called before the first frame update
    void Start()
    {
        thescoreManger = FindObjectOfType<scoreManger>();
        CoinPickSound = GameObject.Find("CoinPickSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "thePlayer")
        {
            thescoreManger.AddScore(scoreToGive);
            gameObject.SetActive(false);

            if (CoinPickSound.isPlaying)
            {
                CoinPickSound.Stop();
            }
            CoinPickSound.Play();
        }
    }
}
