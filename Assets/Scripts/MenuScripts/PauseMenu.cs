using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    //public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject tutorialMenuUI;
    public GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameManager.gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameManager.gamePaused = false;
        //gameManager.audioManager.AdjustSoundVolume("GameMusic", .70f);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameManager.gamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameManager.gamePaused = true;
        //gameManager.audioManager.AdjustSoundVolume("GameMusic", .35f);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameManager.gamePaused = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void DisplayTutorial()
	{
		tutorialMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
	}
	
	public void HideTutorial()
	{
		tutorialMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
	}
}
