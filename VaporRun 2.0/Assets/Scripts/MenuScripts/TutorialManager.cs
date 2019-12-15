using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public GameManager gameManager;
    public int counter = 0;
    public float moveBackSpeedHolder;
    public int tutsSeen = 0;
    public bool showNext = false;

    public Toggle tutorialToggle;
    private int tutorialOn;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        moveBackSpeedHolder = gameManager.moveBackSpeed;

        tutorialOn = PlayerPrefs.GetInt("ShowTutorial"); //1 = true

        if(tutorialOn == 0)
        {
            tutorialToggle.isOn = false;
        }
        if(tutorialOn == 1)
        {
           tutorialToggle.isOn = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(tutorialOn == 1)
        {
            //hide them all unless it's the current one
            for(int i = 0; i < popUps.Length; i++)
            {
                if(i==counter)
                {
                    popUps[i].SetActive(true);
                }
                else{
                    popUps[i].SetActive(false);
                }
            }
            
            if(counter == 0 && showNext == true)
            {
                Time.timeScale = 0f;
                if(tutsSeen == 1){
                    Time.timeScale = 1f;
                    showNext = false;
                    counter++;
                }
            }
            else if(counter == 1 && showNext == true)
            {
                Time.timeScale = 0f;
                if(tutsSeen == 2){
                    Time.timeScale = 1f;
                    showNext = false;
                    counter++;
                }
            }
            else if(counter == 2 && showNext == true)
            {
                Time.timeScale = 0f;
                if(tutsSeen == 3){
                    Time.timeScale = 1f;
                    showNext = false;
                    counter++;
                }
            }
        }
    
    }

    public void TutorialToggle(bool effectStatus)
    {
        if(effectStatus == true)
        {
            PlayerPrefs.SetInt("ShowTutorial", 1); //1 = true
        }
        if(effectStatus == false)
        {
            PlayerPrefs.SetInt("ShowTutorial", 0);
        }
        
    }

    public void TutorialSeen()
    {
        tutsSeen++;
    }
}
