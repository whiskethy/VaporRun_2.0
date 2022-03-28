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
	public GameObject speedLines;
	public float moveBackSpeed = 1.1f;
	public float playerMoveSpeed = 50f;
	public float gameMusicPitch = .65f;
	public bool gamePaused = false;
	private float timeStamp;
	private float timeBoosted;
	public float boostLength = 5f;

	public enum GAMESTATE{none,normal,boosted};
	public GAMESTATE currState = GAMESTATE.none;
	[Range (0, 5f)] public float speedIncreaseAmount = 1f;

	// Use this for initialization
	void Start () {
		currState = GAMESTATE.normal;
		scoreManager = GetComponent<ScoreManager>();
		distanceTraveled = GetComponent<DistanceTraveled>();

		audioManager = AudioManager.instance;

		if(audioManager == null)
		{
			Debug.Log("No audio manager found in scene!");
		}
		gamePaused = false;

		audioManager.PlaySound("Music");
		audioManager.AdjustSoundVolume("Music",1);
	}
	private void Update() {
		if(currState == GAMESTATE.boosted)
		{
			timeStamp+=Time.deltaTime;

			if(timeStamp >= timeBoosted)
			{
				unBoost();
			}
		}
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

	public void boostPowerUp()
	{
		currState = GAMESTATE.boosted;
		//scoreManager.AddPoints(100);

		moveBackSpeed = moveBackSpeed * 2;
		distanceTraveled.speed = moveBackSpeed;
		timeStamp = Time.time;
		timeBoosted = timeStamp + boostLength;
		speedLines.SetActive(true);
		//currState = GAMESTATE.normal;
		//moveBackSpeed = moveBackSpeed /2;
	}
	public void unBoost()
	{
		Debug.Log("hey");
		currState = GAMESTATE.normal;
		moveBackSpeed = moveBackSpeed / 2;
		distanceTraveled.speed = moveBackSpeed;
		speedLines.SetActive(false);
		//currState = GAMESTATE.normal;
		//moveBackSpeed = moveBackSpeed /2;
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
