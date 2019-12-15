//https://www.youtube.com/watch?v=YMj2qPq9CP8

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject menuScreen;
    public Slider slider;

    public void LoadLevel(int sceneIndex)
    {
        
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex); //loads in background and gives object with info about loading
        menuScreen.SetActive(false);
        loadingScreen.SetActive(true);

        while(!operation.isDone) //while not done loading
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            /*
                progress shows in 2 stages
                Loading = 0% - 90%
                Activation = 90%-100%

                isDone is when the Loading phase is done
            */

            yield return null; //wait a frame before updating progress again
        }
    }
}
