using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceTraveled : MonoBehaviour
{
    public TextMeshProUGUI distanceTraveledText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI speedText;
    private GameManager gameManager;
    float distanceTraveled = 0.0f;
    float time = 0f;
    public float speed = 0f;
    private float distanceThreshold = 1;
    
	

	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager>();
        speed = gameManager.moveBackSpeed;
	}

    // Update is called once per frame
    void Update()
    {
        distanceTraveled += speed * Time.fixedDeltaTime;

        if(distanceTraveled > distanceThreshold)
        {
            gameManager.scoreManager.playerScore += 1;
            distanceThreshold += 1;
        }

        time += Time.fixedDeltaTime;

        speedText.text = "V: " + speed.ToString("0") + "m/s";
        distanceTraveledText.text = "Dist: " +distanceTraveled.ToString("0") + "m";
        timeText.text = "Time: " + time.ToString("0") + "s";
    
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("DistanceTraveled", distanceTraveled);
        PlayerPrefs.SetFloat("Time", time);
        PlayerPrefs.SetFloat("MaxSpeed", speed);
    }
}
