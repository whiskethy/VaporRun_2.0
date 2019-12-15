using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private GameManager gameManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int playerScore = 0;
    public int pointThreshold = 1000;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        scoreText.text = "Score: " + playerScore;
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
		UpdateScoreText();
        CheckHighScore();
		IncreaseDifficulty(playerScore);
        //    timer -= (int)timer;
        //}
    }

    public void AddPoints(int inPoints)
	{
		playerScore += inPoints * 10;
        UpdateScoreText();
        CheckHighScore();
		IncreaseDifficulty(playerScore);
	}

    private void CheckHighScore()
    {
        if(playerScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    public void IncreaseDifficulty(int playerScore)
	{
		if(playerScore > pointThreshold)
		{
			gameManager.IncreaseDifficulty();
			pointThreshold += 1000;
		}
	}

	void UpdateScoreText()
	{
		scoreText.text = "Score: " + playerScore;
	}

    public void SaveData()
    {
        PlayerPrefs.SetInt("PlayerScore", playerScore);
    }
}
