using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{

	public GameObject mainMenuUI;
	public GameObject tutorialMenuUI;
	public GameObject optionsMenuUI;
	public TextMeshProUGUI highScoreText;

	private void Start() {
		LoadData();	
	}
    public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void ExitGame() {
    	Application.Quit();
 	}

	public void DisplayTutorial()
	{
		mainMenuUI.SetActive(false);
		tutorialMenuUI.SetActive(true);
	}
	
	public void HideTutorial()
	{
		tutorialMenuUI.SetActive(false);
		mainMenuUI.SetActive(true);
	}

	public void DisplayOptions()
	{
		mainMenuUI.SetActive(false);
		optionsMenuUI.SetActive(true);
	}
	
	public void HideOptions()
	{
		optionsMenuUI.SetActive(false);
		mainMenuUI.SetActive(true);
	}

	void LoadData()
	{
		
        if(highScoreText)
        {
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
		
	}

}
