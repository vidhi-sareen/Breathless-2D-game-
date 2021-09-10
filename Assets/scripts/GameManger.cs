using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public Transform platformGenrator;
    private Vector3 platformstartpt;

    public CharacterController thePlayer;
    private Vector3 playerStartpt;

    public scoreManger ScoreManger;
    public AudioSource backgroundSound;
    public AudioSource deathSound;

    public GameObject gameOverScreen;
    public GameObject largeplatform;
    public GameObject mediumplatform;
    public GameObject smallplatform;

    //private PlatformDestroyer[] destroyers;
    
    void Start()
    {
        playerStartpt = thePlayer.transform.position;
        platformstartpt = platformGenrator.position;
        gameOverScreen.SetActive(false);
    }

    public void GameOver()
    {
        thePlayer.gameObject.SetActive(false);

        gameOverScreen.SetActive(true);
        ScoreManger.isScoreIncreasing = false;
        backgroundSound.Stop();
        deathSound.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        PlatformDestroyer[] destroyer = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0; i < destroyer.Length; i++)
        {
            destroyer[i].gameObject.SetActive(false);
        }
        smallplatform.SetActive(true);
        mediumplatform.SetActive(true);
        largeplatform.SetActive(true);
        thePlayer.transform.position = playerStartpt;
        platformGenrator.transform.position = platformstartpt;
        gameOverScreen.SetActive(false);
        thePlayer.gameObject.SetActive(true);
        backgroundSound.Play();
        ScoreManger.score = 0;
        ScoreManger.isScoreIncreasing = true;
    }

}
