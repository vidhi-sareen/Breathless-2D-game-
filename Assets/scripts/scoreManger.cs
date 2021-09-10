using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scoreManger : MonoBehaviour
{

    public Text scoreText;
    public Text highscoreText;

    public float score;
    private float highscore;

    public float pointsPerSecond;
    public bool isScoreIncreasing;

    void Start()
    {
        isScoreIncreasing = true;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscore = PlayerPrefs.GetFloat("HighScore");
        }
    }

    void Update()
    {
        if(isScoreIncreasing)
            score += pointsPerSecond * Time.deltaTime;
        
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetFloat("HighScore", highscore);
        }
        scoreText.text = Mathf.Round(score).ToString();
        highscoreText.text = Mathf.Round(highscore).ToString();
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;

    }
}

