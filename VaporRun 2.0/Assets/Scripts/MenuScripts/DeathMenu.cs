using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class DeathMenu : MonoBehaviour
{
	public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
	public TextMeshProUGUI distanceTraveledText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI speedText;
    
	private void Start() {
		LoadData();	
	}

	public void ReloadGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
    public void ExitGame() {
    	Application.Quit();
 	}

	void LoadData()
	{
		if(scoreText)
        {
            scoreText.text = "Your Score: " + PlayerPrefs.GetInt("PlayerScore").ToString();
        }
        if(highScoreText)
        {
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
		if(distanceTraveledText)
        {
            distanceTraveledText.text = "Distance Traveled: " + PlayerPrefs.GetFloat("DistanceTraveled").ToString()+ "m";
        }
		if(timeText)
        {
            timeText.text = "Time Played: " + PlayerPrefs.GetFloat("Time").ToString()+ "s";
        }
		if(speedText)
        {
           speedText.text = "Max Velocity: " + PlayerPrefs.GetFloat("MaxSpeed").ToString()+ "m/s";
        }
	}
}
