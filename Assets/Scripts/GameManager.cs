using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

	
	public GameObject player;
	public ObjectGenerator objectGenerator;
	public ScoreManager scoreManager;
	public DistanceTraveled distanceTraveled;
	public AudioManager audioManager;
	public float moveBackSpeed = 1.1f;
	public float playerMoveSpeed = 50f;
	public float gameMusicPitch = .65f;
	public bool gamePaused = false;
	[Range (0, 5f)] public float speedIncreaseAmount = 1f;

	// Use this for initialization
	void Start () {

		scoreManager = GetComponent<ScoreManager>();
		distanceTraveled = GetComponent<DistanceTraveled>();

		audioManager = AudioManager.instance;

		if(audioManager == null)
		{
			Debug.Log("No audio manager found in scene!");
		}
		gamePaused = false;

		audioManager.PlaySound("Music");
	}
	
	public void KillPlayer()
	{
		gamePaused = true;
		moveBackSpeed = 0f;
		player.GetComponent<PlayerDeath>().KillPlayer();

		scoreManager.SaveData();
		distanceTraveled.SaveData();

		Invoke("LoadDeathScene", .3f);
	}

	public void LoadDeathScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void IncreaseDifficulty()
	{
		moveBackSpeed += speedIncreaseAmount;
		distanceTraveled.speed = moveBackSpeed;
		Mathf.Clamp(moveBackSpeed, 1.0f, 20.0f);

		objectGenerator.IncreaseDifficulty();
	}
}
